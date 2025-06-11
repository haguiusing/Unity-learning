# Code examples: Call JavaScript and C/C++/C# functions in Unity | 代码示例：在 Unity 中调用 JavaScript 和 C/C++/C# 函数

You can use code to perform interactions between **plug-ins**[](https://docs.unity3d.com/2023.2/Documentation/Manual/Plugins.html) [](https://docs.unity3d.com/2023.2/Documentation/Manual/Glossary.html#Plug-in) and your Unity code. The following examples show how to call various types of functions from JavaScript and C/C++/C# code in your Unity project.  
您可以使用代码在 Unity 代码之间 **plug-ins** 执行交互。以下示例演示如何在 Unity 项目中从 JavaScript 和 C/C++/C# 代码调用各种类型的函数。

## Call JavaScript code in Unity C# example | 在 Unity C# 示例中调用 JavaScript 代码

The following code is an example of JavaScript code that your Unity C# script can call functions from.  
以下代码是 Unity C# 脚本可以从中调用函数的 JavaScript 代码示例。
```js
mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  HelloString: function (str) {
    window.alert(UTF8ToString(str));
  },

  PrintFloatArray: function (array, size) {
    for(var i = 0; i < size; i++)
        console.log(HEAPF32[(array >> 2) + i]);
  },

  AddNumbers: function (x, y) {
    return x + y;
  },

  StringReturnValueFunction: function () {
    var returnStr = "bla";
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  BindWebGLTexture: function (texture) {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },

});
```
- 这段代码通过 `mergeInto` 将 JavaScript 函数注册到 `LibraryManager.library` 中。
- 这些函数可以被 WebAssembly 模块调用。

The following code is an example of Unity C# code that calls the functions defined in the JavaScript example.  
以下代码是调用 JavaScript 示例中定义的函数的 Unity C# 代码示例。
```cs
using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);

    void Start() {
        Hello();
        
        HelloString("This is a string.");
        
        float[] myArray = new float[10];
        PrintFloatArray(myArray, myArray.Length);
        
        int result = AddNumbers(5, 7);
        Debug.Log(result);
        
        Debug.Log(StringReturnValueFunction());
        
        var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        BindWebGLTexture(texture.GetNativeTexturePtr());
    }
}
```
- 使用 `DllImport` 属性，Unity C# 代码可以声明外部函数。
- 这些函数实际上是在 JavaScript 中定义的，通过 WebAssembly 的接口被调用。
### 原理：
#### WebAssembly 的生成和加载
1. **Unity WebGL 构建**：
    - 当你使用 Unity 构建一个 WebGL 项目时，Unity 会将 C# 脚本编译为 WebAssembly 模块。
    - 这个 WebAssembly 模块是一个 `.wasm` 文件，它包含了运行游戏所需的低级字节码。
    - Unity 的 WebGL 构建工具会将这个 `.wasm` 文件以及相关的 JavaScript 胶水代码（glue code）一起打包到最终的发布文件中。
2. **浏览器加载**：
    - 当用户在浏览器中打开 WebGL 项目时，浏览器会自动加载并解析 `.wasm` 文件。
    - 浏览器的 WebAssembly 运行时会将 `.wasm` 文件中的字节码加载到内存中，并将其编译为可执行代码。
#### JavaScript 和 WebAssembly 的交互
在上述代码中，JavaScript 和 WebAssembly 的交互是通过 Emscripten 提供的接口实现的。Emscripten 是一个工具链，它将 C/C++ 代码编译为 WebAssembly，并生成 JavaScript 胶水代码，以便在浏览器中运行。
##### JavaScript 代码
```js
mergeInto(LibraryManager.library, {
  Hello: function () {
    window.alert("Hello, world!");
  },
  // 其他函数...
});
```
- 这段代码通过 `mergeInto` 将 JavaScript 函数注册到 `LibraryManager.library` 中。
- `LibraryManager.library` 是一个特殊的对象，它允许 JavaScript 函数被 WebAssembly 模块调用。
##### Unity C# 代码
```cs
[DllImport("__Internal")]
private static extern void Hello();
```
- 在 Unity C# 代码中，使用 `[DllImport("__Internal")]` 属性声明了一个外部函数 `Hello`。
- `__Internal` 是一个特殊的标识符，表示这个函数是从当前的 WebAssembly 模块中调用的。
- 当 Unity 构建 WebGL 项目时，它会将这些声明的外部函数映射到 JavaScript 中的对应函数。
#### WebAssembly 的具体作用
1. **高效执行**：
    - WebAssembly 提供了高性能的代码执行环境。C# 代码被编译为 WebAssembly 字节码后，可以在浏览器中以接近原生代码的速度运行。
    - 这使得 Unity WebGL 项目能够高效地处理游戏逻辑、渲染和用户输入。
2. **与 JavaScript 交互**：
    - WebAssembly 模块可以通过 JavaScript 胶水代码与 JavaScript 代码进行交互。
    - JavaScript 代码可以调用 WebAssembly 模块中的函数，反之亦然。
    - 在上述示例中，JavaScript 函数被注册到 `LibraryManager.library` 中，然后通过 WebAssembly 模块被 Unity C# 代码调用。
#### 示例中的 WebAssembly 使用
在上述示例中，WebAssembly 的使用是隐式的，具体体现在以下几个方面：
- **C# 代码编译为 WebAssembly**：Unity 的 WebGL 构建工具会将 C# 脚本编译为 WebAssembly 字节码。
- **JavaScript 胶水代码**：Emscripten 生成的 JavaScript 胶水代码负责在浏览器中加载和初始化 WebAssembly 模块，并提供与 JavaScript 代码交互的接口。
- **调用 JavaScript 函数**：Unity C# 代码通过 `[DllImport("__Internal")]` 声明的外部函数调用 JavaScript 函数，这些调用最终通过 WebAssembly 模块和 JavaScript 胶水代码实现。

## Call C/C++/C# code in Unity C# scripts example | 在 Unity CC++ 脚本示例中调用 C/C++/C# 代码
The following code is an example C++ plug-in with simple functions that you can call in your Unity project.  
以下代码是一个示例 C++ 插件，其中包含可在 Unity 项目中调用的简单函数。
```c++
#include <stdio.h>

extern "C" void Hello ()
{
    printf("Hello, world!\n");
}

extern "C" int AddNumbers (int x, int y)
{
    return x + y;
}
```
- `extern "C"`：确保函数名称不会被 C++ 的名称修饰机制改变。
- `Hello` 和 `AddNumbers` 是两个简单的函数，分别用于打印消息和返回两个整数的和。

Then, use the following Unity C# code in your Unity project to call the C++ functions.  
然后，在 Unity 项目中使用以下 Unity C# 代码调用 C++ 函数。
```cs
using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    void Start() {
        Hello();
        
        int result = AddNumbers(5, 7);
        Debug.Log(result);  
    }
}
```
- `[DllImport("__Internal")]`：声明外部函数。`__Internal` 是一个特殊的标识符，表示这些函数位于 Unity 的内部模块中（例如 WebGL 构建中的 WebAssembly 模块）。
- `Hello` 和 `AddNumbers` 是声明的外部函数，它们分别对应 C++ 插件中的同名函数。
- 在 `Start` 方法中，调用这些外部函数，并将结果输出到 Unity 的调试控制台。
### 原理：
1. **C++ 插件的编译**：
    - C++ 插件需要被编译为一个动态链接库（DLL）文件。这个 DLL 文件包含了可以被其他程序调用的函数。
    - 在 Windows 上，DLL 文件是一个动态链接库；在 macOS 上，它是一个 `.dylib` 文件；在 Linux 上，它是一个 `.so` 文件。
2. **C++ 函数的导出**：
    - 为了使 C++ 函数可以被外部程序调用，它们需要被声明为 `extern "C"`。这确保了函数名称不会被 C++ 的名称修饰（name mangling）机制改变。
    - 例如：
        ```cpp
        extern "C" void Hello() {
            printf("Hello, world!\n");
        }
        ```
3. **平台调用（P/Invoke）**：
    - Unity 的 C# 脚本使用 `System.Runtime.InteropServices.DllImport` 属性来声明对 DLL 中函数的调用。
    - `DllImport` 属性告诉 C# 运行时，指定的函数位于某个 DLL 文件中，并且提供了函数的名称和调用约定。
4. **加载 DLL**：
    - 在运行时，Unity 会加载指定的 DLL 文件，并解析其中的函数地址。
    - 如果 DLL 文件未正确放置或函数名称不匹配，将会导致运行时错误。

## Additional resources  其他资源
- [Interaction with browser scripting  
    [与浏览器脚本交互](https://docs.unity3d.com/2023.2/Documentation/Manual/webgl-interactingwithbrowserscripting.html)
- [Set up your JavaScript plug-in  
    [设置 JavaScript 插件](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js.html)
- [Call JavaScript functions from Unity C# scripts  
    [从 Unity C# 脚本调用 JavaScript 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js-to-unity.html)
- [Call Unity C# script functions from JavaScript  
    [从 JavaScript 调用 Unity C# 脚本函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-unity-to-js.html)
- [Call C/C++/C# functions from Unity C# scripts  
    [从 Unity C++ 脚本调用 C/C++/C# 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browsers-c-to-unity.html)