# Call JavaScript functions from Unity C# scripts | 从 Unity C# 脚本调用 JavaScript 函数
You can use functions from your JavaScript **plug-ins**[](https://docs.unity3d.com/2023.2/Documentation/Manual/Plugins.html) [](https://docs.unity3d.com/2023.2/Documentation/Manual/Glossary.html#Plug-in) in your Unity C# code. It can be useful to use JavaScript code in Unity because you might need to communicate with other elements on your web page or Web APIs.  
您可以在 Unity C# 代码中使用 JavaScript **plug-ins** 中的函数。在 Unity 中使用 JavaScript 代码可能很有用，因为您可能需要与网页或 Web API 上的其他元素进行通信。

To learn about the file types and how to set up a JavaScript plug-in for interaction with Unity **scripts**[](https://docs.unity3d.com/2023.2/Documentation/Manual/CreatingAndUsingScripts.html) [](https://docs.unity3d.com/2023.2/Documentation/Manual/Glossary.html#Scripts), refer to [Set up your JavaScript plug-in](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js.html). To learn how to interact with C/C++/C# plug-ins instead, refer to [Call C/C++/C# functions from Unity C# scripts](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browsers-c-to-unity.html).  
要了解文件类型以及如何设置 JavaScript 插件以与 Unity **scripts** 交互，请参阅[设置 JavaScript 插件](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js.html) 。要了解如何与 C/C++/C# 插件交互，请参阅[从 Unity C# 脚本调用 C/C++/C# 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browsers-c-to-unity.html) 。

|Topic  主题|Description  描述|
|---|---|
|[Pass different variables from JavaScript to Unity  <br>将不同的变量从 JavaScript 传递到 Unity](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js-to-unity.html#pass-different-variables)|Tips on how to pass different variables between Unity and JavaScript.  <br>有关如何在 Unity 和 JavaScript 之间传递不同变量的提示。|
|[Execute build code in its own scope  <br>在自己的范围内执行构建代码](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js-to-unity.html#make-code-visible)|Tips on how to improve visibility of code between Unity and JavaScript.  <br>有关如何在 Unity 和 JavaScript 之间提高代码可见性的提示。|
|[Example Unity C# code that calls JavaScript functions  <br>调用 JavaScript 函数的 Unity C# 代码示例](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js-to-unity.html#example-unity-code)|This example code shows how to call JavaScript functions in Unity.  <br>此示例代码演示如何在 Unity 中调用 JavaScript 函数。|
|[Use Unity plug-ins as a reference  <br>使用 Unity 插件作为参考](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js-to-unity.html#plugin-ref)|Shows a list of plug-ins included with Unity you can use as a reference.  <br>显示 Unity 附带的可用作参考的插件列表。|

## Pass different variables from JavaScript to Unity | 将不同的变量从 JavaScript 传递到 Unity
To integrate JavaScript with Unity, you need efficient communication between the two. Use the following tips on how to pass various types of data from JavaScript to Unity.  
要将 JavaScript 与 Unity 集成，您需要在两者之间进行有效的通信。使用以下提示了解如何将各种类型的数据从 JavaScript 传递到 Unity。

### Numeric types | 数值类型
You can pass simple numeric types to JavaScript in function parameters without converting them.  
您可以在函数参数中将简单的数字类型传递给 JavaScript，而无需转换它们。

For example, this function in JavaScript: `js AddNumbers: function (x, y) { return x + y; },`  
例如，JavaScript 中的以下函数： `js AddNumbers: function (x, y) { return x + y; },`

accepts the integer values from C# without conversions:  
接受 C# 中的整数值，而不进行转换：
```
int result = AddNumbers(5, 7);
```

You can pass other data types as a pointer in the Emscripten heap. The Emscripten heap is just a large array in JavaScript memory.  
您可以将其他数据类型作为 Emscripten 堆中的指针传递。Emscripten 堆只是 JavaScript 内存中的一个大数组。

### Strings | 字符串
To convert a string to a JavaScript string, use the `UTF8ToString` helper function.  
要将字符串转换为 JavaScript 字符串，请使用 `UTF8ToString` 帮助程序函数。
```
var stringMessage = UTF8ToString("Hello World");
```

To return a string value, call `_malloc` to allocate some memory and the `stringToUTF8` helper function to write a JavaScript string to the memory. If the string is a return value, then the **IL2CPP**[](https://docs.unity3d.com/2023.2/Documentation/Manual/IL2CPP.html) [](https://docs.unity3d.com/2023.2/Documentation/Manual/Glossary.html#IL2CPP) runtime automatically frees up the memory for you.  
要返回字符串值，请调用 `_malloc` 来分配一些内存，并调用 `stringToUTF8` 帮助程序函数将 JavaScript 字符串写入内存。如果字符串是返回值，则 **IL2CPP** 运行时会自动为您释放内存。
```
 var returnStr = "Hello World";
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
```

### Arrays | 数组
For arrays of primitive types, Emscripten provides different `ArrayBufferViews` into its heap for different sizes of integer, unsigned integer or floating point representations of memory: `HEAP8`, `HEAPU8`, `HEAP16`, `HEAPU16`, `HEAP32`, `HEAPU32`, `HEAPF32`, `HEAPF64`.  
对于原始类型的数组，Emscripten 在其堆中为不同大小的整数、无符号整数或浮点内存表示形式提供不同的 `ArrayBufferView`：`HEAP8`、`HEAPU8`、`HEAP16`、`HEAPU16`、`HEAP32`、`HEAPU32`、`HEAPF32` `HEAPF64`。

The following function loops through the `HEAPF32` array and outputs the values at each index.  
以下函数循环访问 `HEAPF32` 数组并输出每个索引处的值。
```
PrintFloatArray: function (array, size) {
    for(var i = 0; i < size; i++)
    console.log(HEAPF32[(array >> 2) + i]);
  },
```

### Textures | 纹理
To access a texture in **WebGL**[](https://docs.unity3d.com/2023.2/Documentation/Manual/webgl-gettingstarted.html) [](https://docs.unity3d.com/2023.2/Documentation/Manual/Glossary.html#WebGL), Emscripten provides the `GL.textures` array which maps native texture IDs from Unity to WebGL texture objects. You can call WebGL functions on Emscripten’s WebGL context, `GLctx`.  
为了访问 **WebGL** 中的纹理，Emscripten 提供了 `GL.textures` 数组，该数组将本机纹理 ID 从 Unity 映射到 WebGL 纹理对象。您可以在 Emscripten 的 WebGL 上下文 `GLctx` 上调用 WebGL 函数。

For example, the following function binds a WebGL texture from the GL texture array to a 2D texture.  
例如，以下函数将 GL 纹理数组中的 WebGL 纹理绑定到 2D 纹理。
```
 BindWebGLTexture: function (texture) {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },
```

## Execute build code in its own scope | 在自己的范围内执行构建代码

It is recommended that you execute all build code in its own scope. If you have your code in its own scope, you can embed your content on a page without causing conflicts with the embedding page code, and you can embed more than one build on the same page.  
建议您在其自己的范围内执行所有构建代码。如果您的代码位于其自己的范围内，则可以将内容嵌入到页面上，而不会与嵌入页面代码发生冲突，并且可以在同一页面上嵌入多个内部版本。

### Code in .jslib plug-ins | .jslib 插件中的代码

If you have all your JavaScript code in the form of `.jslib` plug-ins inside your project, then this JavaScript code will run inside the same scope as the compiled build and your code should work the same way as in previous versions of Unity. Some of the objects and functions directly visible from the JavaScript plug-in code include: * `Module` * `SendMessage` * `HEAP8` * `ccall`  
如果项目中的所有 JavaScript 代码都以 `.jslib` 插件的形式存在，则此 JavaScript 代码将在与已编译版本相同的范围内运行，并且您的代码应以与以前版本的 Unity 中相同的方式运行。从 JavaScript 插件代码中直接可见的一些对象和函数包括：* `模块` * `发送消息` * `堆 8` * `ccall`

### Call JavaScript functions from global scope | 从全局范围调用 JavaScript 函数
If you want to call the internal JavaScript functions from the global scope of the embedded page, in your Web template `index.html`, you must use the `unityInstance` variable.  
如果要从嵌入页面的全局范围调用内部 JavaScript 函数，则必须在 Web `模板 index.html` 中使用 `unityInstance` 变量。

Use `unityInstance` after the Unity engine instantiation succeeds, for example:  
在 Unity 引擎实例化成功后使用 `unityInstance`，例如：
```
  var MyGameInstance = null;
  script.onload = () => {
    createUnityInstance(canvas, config, (progress) => { /*...*/ }).then((unityInstance) => {
      MyGameInstance = unityInstance;
```

Then, you can use `MyGameInstance.SendMessage()` to send a message to the build, or use `MyGameInstance.Module` to access the build module object.  
然后，您可以使用 `MyGameInstance.SendMessage（）` 向构建发送消息，或使用 `MyGameInstance.Module` 访问构建模块对象。

## Example Unity C# code that calls JavaScript functions | 调用 JavaScript 函数的 Unity C# 代码示例
The following JavaScript code creates a function named `Hello`. For this example, use this code in your JavaScript plug-in so you can call it in your Unity C# scripts.  
以下 JavaScript 代码创建一个名为 `Hello` 的函数。在此示例中，请在 JavaScript 插件中使用此代码，以便可以在 Unity C# 脚本中调用它。
```
mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },
});
```

Then, use this C# code in your Unity project to call the `Hello` function from your JavaScript code:  
然后，在 Unity 项目中使用以下 C# 代码从 JavaScript 代码调用 `Hello` 函数：
```
using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void Hello();

    void Start() {
        Hello();
    }
}
```

For a larger code example with varied function types, refer to [Code examples: Call JavaScript and C/C++/C# functions in Unity](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-code-example.html).  
有关具有不同函数类型的大型代码示例，请参阅[代码示例：在 Unity 中调用 JavaScript 和 C/C++/C# 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-code-example.html) 。

## Use Unity plug-ins as a reference | 使用 Unity 插件作为参考
There are several plug-ins in the Unity installation folder that you can use as reference:  
Unity 安装文件夹中有几个插件可以用作参考：
- `PlaybackEngines/WebGLSupport/BuildTools/lib`
- `PlaybackEngines/WebGLSupport/BuildTools/Emscripten/src/library*`

## Additional resources  其他资源
- [Interaction with browser scripting  
    [与浏览器脚本交互](https://docs.unity3d.com/2023.2/Documentation/Manual/webgl-interactingwithbrowserscripting.html)
- [Set up your JavaScript plug-in  
    [设置 JavaScript 插件](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js.html)
- [Call Unity C# script functions from JavaScript  
    [从 JavaScript 调用 Unity C# 脚本函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-unity-to-js.html)
- [Call C/C++/C# functions from Unity C# scripts  
    [从 Unity C++ 脚本调用 C/C++/C# 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browsers-c-to-unity.html)
- [Create callbacks between Unity C#, JavaScript, and C/C++/C# code  
    [在 Unity C#、JavaScript 和 C/C++/C# 代码之间创建回调](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-example.html)