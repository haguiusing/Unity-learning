
# Set up your JavaScript plug-in | 设置 JavaScript 插件
You can call functions from your JavaScript plug-ins in your Unity projects. Unity supports two JavaScript **plug-in**[](https://docs.unity3d.com/2023.2/Documentation/Manual/Plugins.html) [](https://docs.unity3d.com/2023.2/Documentation/Manual/Glossary.html#Plug-in) file types that let you add JavaScript code to your Unity project:  
您可以从 Unity 项目中的 JavaScript 插件调用函数。Unity 支持两种 JavaScript **plug-in** 文件类型，可用于将 JavaScript 代码添加到 Unity 项目中：
- `.jslib`
- `.jspre`

If you want to call functions from C++ plug-ins instead, refer to [Call C/C++/C# functions from Unity C# scripts](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browsers-c-to-unity.html).  
如果要改为从 C++ 插件调用函数，请参阅[从 Unity C# 脚本调用 C/C++/C# 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browsers-c-to-unity.html) 。

## Import your JavaScript files into your Unity project | 将 JavaScript 文件导入到 Unity 项目中
The recommended way to use browser JavaScript in your project is to add your JavaScript sources (`.jspre` and `.jslib` files) to your project, and then use those functions or libraries directly in your Unity C# script code.  
在项目中使用浏览器 JavaScript 的推荐方法是将 JavaScript 源（`.jspre` 和 `.jslib` 文件）添加到项目中，然后直接在 Unity C# 脚本代码中使用这些函数或库。

Place your JavaScript plug-in files in the `Assets/Plugin` folder.  
将 JavaScript 增效工具文件放在 `Assets/Plugin` 文件夹中。

## Call functions from the .jslib file type | 从 .jslib 文件类型调用函数
You can call functions from your `.jslib` plug-in files in your Unity C# or native **scripts**[](https://docs.unity3d.com/2023.2/Documentation/Manual/CreatingAndUsingScripts.html) [](https://docs.unity3d.com/2023.2/Documentation/Manual/Glossary.html#Scripts).  
您可以在 Unity C# 或本机 **scripts** 中从 `.jslib` 插件文件中调用函数。

The `.jslib` file type uses the `--js-library` Emscripten module. For more information, refer to the Emscripten documentation about the [–js-library Emscripten option](https://emscripten.org/docs/tools_reference/emcc.html#emcc-js-library).  
`.jslib` 文件类型使用 `--js-library` Emscripten 模块。有关更多信息，请参阅有关 [–js-library Emscripten 选项](https://emscripten.org/docs/tools_reference/emcc.html#emcc-js-library)的 Emscripten 文档。

The following code shows an example of a `.jslib` plug-in file with the ideal syntax that defines some functions (`Hello` and `HelloString`).  
下面的代码显示了一个 `.jslib` 插件文件的示例，该文件具有定义某些函数（`Hello` 和 `HelloString`）的理想语法。
```js
mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  HelloString: function (str) {
    window.alert(UTF8ToString(str));
  },
});
```

You can then call these functions in your Unity C# code:  
然后，您可以在 Unity C# 代码中调用这些函数：
```cs
using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    void Start() {
        Hello();
        HelloString("This is a string.");
    }
}
```

For a full example of code interactions between Unity C# and JavaScript functions, refer to [Code examples: Call JavaScript and C/C++/C# functions in Unity](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-code-example.html).  
有关 Unity C# 和 JavaScript 函数之间代码交互的完整示例，请参阅[代码示例：在 Unity 中调用 JavaScript 和 C/C++/C# 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-code-example.html) 。

For more information about interactions between Unity C# and JavaScript, refer to [Call JavaScript functions from Unity C# scripts](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js-to-unity.html#example-unity-code).  
有关 Unity C# 和 JavaScript 之间交互的更多信息，请参阅[从 Unity C# 脚本调用 JavaScript 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js-to-unity.html#example-unity-code) 。

## Include JavaScript libraries with the .jspre file type | 包括文件类型为 .jspre 的 JavaScript 库
Use the `.jspre` plug-in file type to include existing JavaScript libraries in your JavaScript code. You can’t use Unity code to interact with the `.jspre` files, but you can use them in the `.jslib` code.  
使用 `.jspre` 插件文件类型可在 JavaScript 代码中包含现有 JavaScript 库。您不能使用 Unity 代码与 `.jspre` 文件交互，但可以在 `.jslib` 代码中使用它们。

The `.jspre` file type uses the `--pre-js` Emscripten option. For more information, refer to the Emscripten documentation about the [–pre-js Emscripten option](https://emscripten.org/docs/tools_reference/emcc.html#emcc-pre-js).  
`.jspre` 文件类型使用 `--pre-js` Emscripten 选项。有关更多信息，请参阅有关 [–pre-js Emscripten 选项](https://emscripten.org/docs/tools_reference/emcc.html#emcc-pre-js)的 Emscripten 文档。

During the build process, Emscripten creates the `*.framework.js` file and copies the contents of the `.jspre` file into the start of the `*.framework.js` file. This process is useful because all the code is combined into one file so it’s easier to manage the files and the code benefits from Emscripten optimizations.  
在构建过程中，Emscripten 会创建 `*.framework.js` 文件，并将 `.jspre` 文件的内容复制到 `*.framework.js` 文件的开头。此过程非常有用，因为所有代码都合并到一个文件中，因此可以更轻松地管理文件，并且代码受益于 Emscripten 优化。

## Additional resources  其他资源
- [Interaction with browser scripting  
    [与浏览器脚本交互](https://docs.unity3d.com/2023.2/Documentation/Manual/webgl-interactingwithbrowserscripting.html)
- [Call JavaScript functions from Unity C# scripts  
    [从 Unity C# 脚本调用 JavaScript 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-js-to-unity.html)
- [Call Unity C# script functions from JavaScript  
    [从 JavaScript 调用 Unity C# 脚本函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-unity-to-js.html)
- [Call C/C++/C# functions from Unity C# scripts  
    [从 Unity C++ 脚本调用 C/C++/C# 函数](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browsers-c-to-unity.html)
- [Create callbacks between Unity C#, JavaScript, and C/C++/C# code  
    [在 Unity C#、JavaScript 和 C/C++/C# 代码之间创建回调](https://docs.unity3d.com/2023.2/Documentation/Manual/web-interacting-browser-example.html)