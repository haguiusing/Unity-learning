using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson25 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 回顾自定义重定向流程
        //1.得到重定向类的Type
        //2.得到想要重定向方法的方法信息
        //3.使用AppDomain中的注册重定向方法RegisterCLRMethodRedirection
        //  进行重定向方法关联
        #endregion

        #region 知识点二 回顾ILRuntime中方法指令的调用
        //在执行代码时，ILRuntime内部自己实现了的运行栈来管理内存

        //  参数1                  返回值
        //  参数2      ——————>     
        //  栈指针    
        #endregion

        #region 知识点三 重定向函数的规则套路
        //1.通过解析器获取appdomain

        //2.获取栈底指针（根据函数参数数量决定减多少，用于之后返回）

        //3.获取函数参数

        //4.参数类型转换

        //5.释放对应栈指针内存

        //6.重定向处理
        //7.返回当前栈顶（栈指针位置）
        //  7-1：无返回值
        //  直接返回之前记录的栈底位置

        //  7-2: 有返回值
        //  如果是简单类型，直接设置后返回
        //  如果是复杂类型，使用PushObject方法
        #endregion

        #region 总结
        //当我们需要自己实现重定向函数时，我们只需要参考CLR绑定中生成的文档中的内容进行书写即可
        //只要我们大概了解了重定向函数的规则套路，我们自然能够看懂和写出我们需要的内容
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
