using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson20 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 什么是寄存器模式
        //寄存器模式是 ILRuntime2.0 版引入的专用于优化大规模数值计算的执行模式
        //该模式通过ILRuntime自己的 编译器以及指令集(JIT Compiler) 将原始DLL的 微软中间语言(MSIL) 指令集转换成一个
        //自定义的基于寄存器的指令集，再进行解译执行

        //在ILRuntime中使用寄存器模式可以有效的提高性能，主要有以下特点
        //1.数值计算性能会大幅提升，包括for循环等需要数值计算的控制流
        //2.属性的调用开销，for循环里调用其他热更内方法的性能会有所提升

        //注意：如果一个方法即没有数值计算，也没有频繁调用热更内的的方法或者访问属性，只是调用系统或UnityAPI，那么不会产生任何优化
        //     甚至一些情况下性能还会低于传统模式
        #endregion

        #region 知识点二 开启寄存器模式
        //开启寄存器模式主要有两种方式：
        #region 1.全局开启
        //在初始化appdomain时 调用其有参构造new AppDomain(ILRuntimeJITFlags.JITOnDemand)
        //ILRuntimeJITFlags代表ILRuntime的 即时编译(JIT)模式

        //None：不启用寄存器模式

        //JITOnDemand: 按需即时编译(JIT)模式，
        //             使用该模式在默认的情况下会按照原始的方式运行，当该方法被反复执行时，会被标记为需要被JIT，
        //             并在后台线程完成JIT编译后切换到寄存器模式运行

        //JITImmediately(全局开启时不推荐)：立即JIT模式，使用该模式时，当方法被调用的瞬间即会被执行JIT编译，
        //                在第一次执行时即使用寄存器模式运行。
        //                JIT会在当前线程发生，因此如果方法过于复杂在第一次执行时可能会有较大的初始化时间

        //NoJIT： 禁用JIT模式，该方法在执行时会始终以传统方式执行

        //ForceInline(全局开启时不使用)：强制内联模式，该模式只对方法的Attribute生效，
        //                             标注该模式的方法在被调用时将会无视方法体内容大小，强制被内联
        #endregion

        #region 2.指定开启
        //在指定的类和方法前加上
        //[ILRuntimeJIT(寄存器模式)] 特性
        //自己指定那些类或方法将使用 哪种 寄存器模式

        //注意：在热更工程中使用该特性，我们需要引用ILRuntime库
        //     可以在项目工程文件中找到 Library\ScriptAssemblies\ILRuntime.dll 进行引用（将复制本地设置为false，避免生成时导出）
        #endregion
        #endregion

        #region 知识点三 寄存器模式使用建议
        //推荐使用2种模式：
        //1.在初始化AppDomain时，将寄存器模式指定为 JITOnDemand（按需即时编译(JIT)模式）
        //  ILRuntime会自己判断运行模式，在大多数情况下能达到不错的性能平衡

        //2.初始化AppDomain时，不指定寄存器模式，而是通过自己利用[ILRuntimeJIT(寄存器模式)]特性来指定精准控制想要优化处
        #endregion

        #region 总结
        //寄存器模式可以帮助我们进行性能优化
        //主要是用于优化大量数值计算逻辑
        //我们可以选择全局开启或者精准控制来达到优化目的

        //为了使用更方便，建议大家使用全局JITOnDemand模式 或者 通过特性自定义局部开启
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
