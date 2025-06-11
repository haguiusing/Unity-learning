using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 复习 启动ILRuntime
        ILRuntimeMgr.Instance.StartILRuntime(()=>{
            //加载完了热更新相关的dll和pdb后 再去执行热更代码
            //静态方法调用有两种方式
            //1.直接通过appdomain.Invoke("命名空间.类名", "静态方法名", null, 参数列表)
            //  调用静态方法
            AppDomain appDomain = ILRuntimeMgr.Instance.appDomain;
            appDomain.Invoke("HotFix_Project.Lesson3_Test", "TestStaticFun", null, null);

            int i = (int)appDomain.Invoke("HotFix_Project.Lesson3_Test", "TestStaticFun2", null, 99);
            print(i);

            //2.通过类似反射的IMethod调用方法
            //  通过IType中的GetMethod方法，类似反射一样的获取对应类中的方法
            //  2-1.通过appdomain.Invoke（IMethod对象, null, 参数列表）
            //获取对应类 的 Itype
            IType type = appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            //获取对应方法的信息
            IMethod method1 = type.GetMethod("TestStaticFun", 0);
            IMethod method2 = type.GetMethod("TestStaticFun2", 1);
            //通过方法信息 IMethod 调用对应方法
            appDomain.Invoke(method1, null, null);

            i = (int)appDomain.Invoke(method2, null, 88);
            print(i);

            //  2-2.通过更节约性能的无GC Alloc方式（调用完后直接回收）调用，类似上节课的成员属性
            //    using (var method = appDomain.BeginInvoke(methodName))
            //    {
            //          method.Push.....(1000);//传入指定类型参数
            //          method.Invoke();//执行方法
            //          method.Read....()//获取指定类型返回值
            //    }
            using(var method = appDomain.BeginInvoke(method1))
            {
                method.Invoke();
            }
            using (var method = appDomain.BeginInvoke(method2))
            {
                method.PushInteger(77);
                method.Invoke();
                i = method.ReadInteger();
                print(i);
            }
        });
        #endregion

        #region 知识点 静态方法调用
        //静态方法调用有两种方式
        //1.直接通过appdomain.Invoke("命名空间.类名", "静态方法名", null, 参数列表)
        //  调用静态方法

        //2.通过类似反射的IMethod调用方法
        //  通过IType中的GetMethod方法，类似反射一样的获取对应类中的方法
        //  2-1.通过appdomain.Invoke（IMethod对象, null, 参数列表）
        //  2-2.通过更节约性能的无GC Alloc方式（调用完后直接回收）调用，类似上节课的成员属性
        //    using (var method = appDomain.BeginInvoke(methodName))
        //    {
        //          method.Push.....(1000);//传入指定类型参数
        //          method.Invoke();//执行方法
        //          method.Read....()//获取指定类型返回值
        //    }
        #endregion

        #region 总结
        //静态方法调用的规则和成员属性方法调用规则基本类似
        //三板斧调用
        //1.appdomain.Invoke("命名空间.类名", "静态方法名", null, 参数列表)
        //2.appdomain.Invoke（IMethod对象, null, 参数列表）
        //3.无GC Alloc方式 using BeginInvoke push Invoke read -> ubpir方式

        //注意：
        //建议大家都使用类似反射的IMethod来调用方法
        //并且使用更节约性能的无GC Alloc方式来调用
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
