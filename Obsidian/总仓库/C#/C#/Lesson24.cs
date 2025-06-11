using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson24 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 ILRuntime中的解释器用来干什么？
        //当ILRuntime通过Mono.Cecil库将DLL文件中的 IL 中间语言读取出来后
        //会利用已经写好的相关代码，将IL代码解释翻译，之后用于执行
        //它主要做了（ILIntepreter脚本）：
        //1.遍历方法体中的每一条指令
        //2.使用内部巨大的 switch case 用于处理IL中的每一条指令（判断不同的指令类型来处理对应逻辑）

        //在执行代码时，使用ILRuntime内部自己实现的运行栈来管理内存
        //ILRuntime中使用非托管内存，内存不会被GC管理，而是ILRuntime内部自己管理，通过指针直接对内存进行操作（脚本RuntimeStack）
        //其中使用自定义类 StackObject 来表达基础类型值
        #endregion

        #region 知识点二 ILRuntime中的内存布局
        //在ILRuntime实现的非托管 运行栈 中存储的对象主要就是StackObject对象
        //在该运行栈中，StackObject对象是依次排列的，我们只需要移动当前的栈指针就可以获取到栈中存储的各数据

        //                      **StackObject** (栈指针 - 1)
        //                         ObjectType
        //                           Value
        //                          ValueLow
        //  栈指针   ————>      **StackObject** (栈指针)
        //                         ObjectType
        //                           Value
        //                          ValueLow
        //                      **StackObject** (栈指针 + 1)
        //                         ObjectType
        //                           Value
        //                          ValueLow
        #endregion

        #region 知识点三 ILRuntime中方法指令的调用
        //1.按顺序将参数依次压栈
        //2.利用栈指针的移动获取到各参数进行处理
        //3.清理栈(将栈指针移动到底部，下方内容就认为会被释放了)

        //  参数1                  返回值
        //  参数2                  栈指针
        //  局部变量1    ——————>
        //  局部变量2
        //  栈指针
        #endregion

        #region 知识点四 关于CLR重定向
        //我们可以在ILIntepreter脚本中搜索callvirt指令（对对象调用后期绑定方法，并且将返回值推送到计算堆栈上）
        //该指令处理中，如果发现是CLR重定向，会调用对应绑定的委托函数
        #endregion

        #region 总结
        //ILRuntime的解释器就是 利用已经写好的相关代码，将IL代码解释翻译后进行执行
        //对于我们来说需要大致了解它的内存布局，以及方法指令是如何调用的
        //这样我们才能够看懂或书写CLR重定向相关的逻辑
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
