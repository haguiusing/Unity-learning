using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 在ILRuntime热更工程中新建一个类
        //只需要在ILRuntime的工程中新建一个类即可
        //并为该类声明几个构造函数重载
        #endregion

        #region 知识点二 在Unity中跨域调用ILRuntime中的类
        //需要让ILRuntime重新生成最新的dll和pdb文件
        
        ILRuntimeMgr.Instance.StartILRuntime(() =>
        {
            //这里面做的事情 是在加载完了dll和pdb文件后做的
            ILRuntime.Runtime.Enviorment.AppDomain appDomain = ILRuntimeMgr.Instance.appDomain;
            //方式一：appdomain中的Instantiate方法
            //       参数一：类的命名空间.类名
            //       参数二：参数列表
            object obj = appDomain.Instantiate("HotFix_Project.Lesson3_Test");
            print(obj);
            obj = appDomain.Instantiate("HotFix_Project.Lesson3_Test", new object[] { "123" });
            print(obj);

            //方式二：appdomain中LoadedTypes字典获取IType类型后，强转为ILType后调用Instantiate方法
            //       该方式类似反射
            IType type = appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            obj = ((ILType)type).Instantiate();
            print(obj);

            obj = ((ILType)type).Instantiate(new object[] { "234" });
            print(obj);

            //方式三：通过方式二中得到的IType对象，再去得到它的构造函数进行实例化
            //       该方式类似反射
            ConstructorInfo info = type.ReflectionType.GetConstructor(new Type[0]);
            obj = info.Invoke(null);
            print(obj);

            info = type.ReflectionType.GetConstructor(new Type[] { typeof(string)});
            obj = info.Invoke(new object[] { "11111"});
            print(obj);


            //更推荐方式2，因为之后在调用对象方法变量时，通过方式2更方便
        });
        #endregion

        #region 总结
        //Unity中实例化ILRuntime中类对象主要有三种方式
        //1.appdomain中的Instantiate方法
        //2.appdomain中LoadedTypes字典获取IType类型后, 强转为ILType后调用Instantiate方法
        //3.appdomain中LoadedTypes字典获取IType类型后, 再去获取它的构造函数信息用于实例化对象

        //推荐使用方式2或者3，因为他们都需要先获取IType，之后调用对象中成员时更方便
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
