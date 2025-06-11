using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson22 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 C#的运行机制
        //该知识点在 Unity进阶之C#知识补充 中详细讲解过
        //C# 通过C#编译器 生成 对应的 CIL（通用中间语言）
        //然后通过 CLR（公共语言运行时）将 CIL 解释翻译 为
        //最终的机器码，运行在平台上

        //那么我们生成DLL文件，其中存储的就是我们的 CIL 中间语言
        //我们可以通过 反编译工具 ILSpy 来查看对应的 IL 中间代码

        //ILSpy获取地址：https://github.com/icsharpcode/ILSpy
        //IL的汇编代码中有很多的指令信息
        //如果想要学习他们，可以前往微软官网查看具体的IL汇编指令的作用
        //https://learn.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-7.0
        #endregion

        #region 知识点二 ILRuntime实现热更新的基础——Mono.Cecil库
        //在第一节课搭建环境时，我们就提到过Mono.Cecil库
        //它是一个第三方库，主要作用有：
        //1.读取C#编译的DLL
        //2.可以读取到DLL中的类型和方法元信息
        //3.可以读取方法体中IL汇编指令
        //4.可以读取PDB调试符号表文件
        //5.可以修改DLL中的元信息和方法体内容并写回DLL
        //由于它的这些功能，所以被广泛的应用于各种热更方案中
        //比如xlua和tolua
        //而ILRuntime也是基于它来完成我们的热更功能的

        //ILRuntime自己实现了
        //1.解释器：ILRuntime基于Mono.Cecil 获取 DLL 文件中的 IL 代码，将他们基于自己的规则翻译并执行
        //         ILRuntime实现的解释器相当于就是一个基于C#的解释执行引擎

        //2.类型系统：用于表示原始工程和热更工程中的各种类型、方法、成员、实例对象等等信息
        //           相当于，ILRuntime帮助我们利用它内部的解释器,将我们实现的代码解释翻译为了自己的一套类型规则
        //           在真正执行代码时，都是基于ILRuntime自己的类型系统中的规则来执行的
        #endregion

        #region 总结
        //ILRuntime借助Mono.Cecil库来读取DLL中的IL汇编码
        //然后通过内置的IL解译执行虚拟机来执行DLL中的代码
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
