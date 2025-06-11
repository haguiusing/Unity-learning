using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 复习 启动ILRuntime 创建类对象
        ILRuntimeMgr.Instance.StartILRuntime(()=>{
            AppDomain appDomain = ILRuntimeMgr.Instance.appDomain;
            //得到IType 通过他实例化一个指定的热更新工程中的类对象 (Lesson3_Test)
            IType type = appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            object obj = ((ILType)type).Instantiate();

            //成员方法调用和静态方法调用几乎一样
            //区别就是需要先创建对象，将对象传入之前为null的地方
            //1.直接通过appdomain.Invoke("命名空间.类名", "方法名", 类对象, 参数列表)
            appDomain.Invoke("HotFix_Project.Lesson3_Test", "TestFun", obj, null);

            int i = (int)appDomain.Invoke("HotFix_Project.Lesson3_Test", "TestFun2", obj, 99);
            print(i);

            //2.通过类似反射的IMethod调用方法
            //  通过IType中的GetMethod方法，类似反射一样的获取对应类中的方法

            //得到对应方法的方法信息
            IMethod method1 = type.GetMethod("TestFun", 0);
            IMethod method2 = type.GetMethod("TestFun2", 1);

            //  2-1.通过appdomain.Invoke（IMethod对象, 类对象, 参数列表）
            appDomain.Invoke(method1, obj);

            i = (int)appDomain.Invoke(method2, obj, 88);
            print(i);

            //  2-2.通过更节约性能的GC Alloc方式（调用完后直接回收）调用，类似上节课的成员属性
            using(var method = appDomain.BeginInvoke(method1))
            {
                method.PushObject(obj);
                method.Invoke();
            }

            using (var method = appDomain.BeginInvoke(method2))
            {
                method.PushObject(obj);
                method.PushInteger(77);
                method.Invoke();
                i = method.ReadInteger();
                print(i);
            }
        });
        #endregion

        #region 知识点 成员方法调用
        //成员方法调用和静态方法调用几乎一样
        //区别就是需要先创建对象，将对象传入之前为null的地方
        //1.直接通过appdomain.Invoke("命名空间.类名", "方法名", 类对象, 参数列表)
        //2.通过类似反射的IMethod调用方法
        //  通过IType中的GetMethod方法，类似反射一样的获取对应类中的方法
        //  2-1.通过appdomain.Invoke（IMethod对象, 类对象, 参数列表）
        //  2-2.通过更节约性能的GC Alloc方式（调用完后直接回收）调用，类似上节课的成员属性
        #endregion

        #region 总结
        //三板斧调用（和静态方法调用区别就是，需要指明调用方法的对象）
        //1.appdomain.Invoke("命名空间.类名", "静态方法名", 对象, 参数列表)
        //2.appdomain.Invoke（IMethod对象, 对象, 参数列表）
        //3.无GC Alloc方式 using BeginInvoke push Invoke read -> ubpir方式
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
