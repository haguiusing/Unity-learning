using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 回顾上节课知识点 复制对应代码
        ILRuntimeMgr.Instance.StartILRuntime(() =>
        {
            //这里面做的事情 是在加载完了dll和pdb文件后做的
            ILRuntime.Runtime.Enviorment.AppDomain appDomain = ILRuntimeMgr.Instance.appDomain;
            IType type = appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            object obj = ((ILType)type).Instantiate(new object[] { "234" });
            print(obj);

            //1.获取方法信息
            //  通过IType中的GetMethod方法，类似反射一样的获取对应类中的方法
            //  规则：get_属性名 为对应属性获取
            //        set_属性名 为对应属性的赋值
            IMethod getStr = type.GetMethod("get_Str", 0);
            IMethod setStr = type.GetMethod("set_Str", 1);

            //2.调用方法
            //  有两种方式
            //  2-1:通过appdomain.Invoke（方法名，调用对象，参数）调用
            //去获取属性
            string str = appDomain.Invoke(getStr, obj).ToString();
            print(str);
            //去设置属性
            appDomain.Invoke(setStr, obj, "666");
            str = appDomain.Invoke(getStr, obj).ToString();
            print(str);

            //  2-2:通过更节约性能的无GC Alloc（调用完后直接回收）方式调用
            //    using (var method = appDomain.BeginInvoke(methodName))
            //    {
            //          method.PushObject(obj);//传入执行该方法的对象
            //          method.Push.....(1000);//传入指定类型参数
            //          method.Invoke();//执行方法
            //          method.Read....()//获取指定类型返回值
            //    }
            using(var method = appDomain.BeginInvoke(getStr))
            {
                method.PushObject(obj);//传入执行该方法的对象
                method.Invoke();//执行方法
                str = method.ReadValueType<string>();
                print(str);
            }
            using(var method = appDomain.BeginInvoke(setStr))
            {
                method.PushObject(obj);//传入执行该方法的对象
                string tempStr = "9999";
                method.PushValueType<string>(ref tempStr);
                method.Invoke();
            }

            using (var method = appDomain.BeginInvoke(getStr))
            {
                method.PushObject(obj);//传入执行该方法的对象
                method.Invoke();//执行方法
                str = method.ReadValueType<string>();
                print(str);
            }
        });
        #endregion

        #region 知识点二 Unity无法跨域直接获取、修改ILRuntime中成员变量
        //ILRuntime中并没有提供让Unity直接获取或修改成员变量的方案
        //我们只能通过在ILRuntime中封装属性的形式来达到目的
        #endregion

        #region 知识点三 调用ILRuntime中的成员属性方法
        //1.获取方法信息
        //  通过IType中的GetMethod方法，类似反射一样的获取对应类中的方法
        //  规则：get_属性名 为对应属性获取
        //        set_属性名 为对应属性的赋值

        //2.调用方法
        //  有两种方式
        //  2-1:通过appdomain.Invoke（方法名，调用对象，参数）调用

        //  2-2:通过更节约性能的无GC Alloc（调用完后直接回收）方式调用
        //    using (var method = appDomain.BeginInvoke(methodName))
        //    {
        //          method.PushObject(obj);//传入执行该方法的对象
        //          method.Push.....(1000);//传入指定类型参数
        //          method.Invoke();//执行方法
        //          method.Read....()//获取指定类型返回值
        //    }

        //注意：
        //每次修改热更工程后代码，一定要重新生成
        #endregion

        #region 总结
        //1.ILRuntime不能直接获取、修改热更工程中对象的成员变量，需要用成员属性封装一次
        //2.ILRuntime中获取属性的get和set方法规则为：get_属性名、set_属性名
        //3.调用属性方法有两种方式
        //  1:通过appdomain.Invoke（方法名，调用对象，参数）调用
        //  2:通过更节约性能的无GC Alloc（调用完后直接回收）方式调用
        //    using (var method = appDomain.BeginInvoke(methodName))
        //    {
        //          method.PushObject(obj);//传入执行该方法的对象
        //          method.Push.....(1000);//传入指定类型参数
        //          method.Invoke();//执行方法
        //          method.Read....()//获取指定类型返回值
        //    }
        //  其中虽然方式二写起来复杂，但是更加节约性能，推荐使用，可以尝试进行封装
        #endregion
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
