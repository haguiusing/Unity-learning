using ILRuntime.CLR.TypeSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson17 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 复制之前的主入口调用
        ILRuntimeMgr.Instance.StartILRuntime(() => {
            //执行ILRuntime当中的一个静态函数
            //静态函数中 就是热更工程自己处理的逻辑了
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);

            #region 知识点一 在热更工程中使用反射
            //按照反射的规则正常使用即可
            //和C#中反射没有任何区别
            #endregion

            #region 知识点二 在Unity工程中反射热更工程中内容
            //我们已在Lesson3创建对象时接触过 Unity反射创建ILRuntime中的对象

            //我们就使用了ILRuntime中的反射相关内容进行对象的创建
            //1.获取ILRuntime对应IType类型
            IType iType = ILRuntimeMgr.Instance.appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            //2.通过IType获取到对应的Type
            Type type = iType.ReflectionType;
            //3.通过反射获取各种内容来进行调用
            //3-1构造函数
            object obj = type.GetConstructor(new Type[0]).Invoke(null);
            print(obj);
            //3-2成员变量
            var testIInfo = type.GetField("testI");
            print(testIInfo.GetValue(obj));
            //3-3成员属性
            var strInfo = type.GetProperty("Str");
            strInfo.SetValue(obj, "897654");
            print(strInfo.GetValue(obj));
            //3-4成员方法
            var methodInfo = type.GetMethod("TestFun", new Type[0]);
            methodInfo.Invoke(obj, null);

            //注意：
            //在Unity中反射使用热更工程中类时
            //我们不能够使用
            //Activator.CreateInstance(type)
            //的形式去创建对象
            //这样会报错
            //想要在主工程中创建热更工程中的对象
            //必须使用我们之前间接过的三种方式
            #endregion

            #region 总结
            //Unity中反射使用ILRuntime热更工程中内容
            //1.IType type = appdomain.LoadedTypes["TypeName"];
            //  Type t = type.ReflectedType;
            //2.不能使用Activator.CreateInstance 或 new T() 创建实例
            //  只能通过Lesson3中的反射方式创建
            //  appdomain.Instantiate 或者
            //  type.GetConstructor 后 Invoke

            //ILRuntime热更工程中使用反射
            //和C#中使用反射一样
            #endregion
        });
        #endregion
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
