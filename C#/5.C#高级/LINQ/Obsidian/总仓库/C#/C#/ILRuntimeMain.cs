using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotFix_Project
{
    public delegate void MyILRuntimeDel1();
    public delegate int MyILRuntimeDel2(int i, int j);

    class ILRuntimeMain
    {
        /// <summary>
        /// 把逻辑处理权交给热更工程
        /// 它是一个启动函数
        /// </summary>
        public static void Start()
        {
            #region Lesson9
            //Lesson9 ILRuntime调用Unity相关内容
            //GameObject obj = new GameObject("ILRuntime创建的空物体");
            //obj.transform.position = new Vector3(10, 10, 10);
            //Debug.Log(obj.transform.position);
            //Rigidbody rigidBody = obj.AddComponent<Rigidbody>();
            //rigidBody.mass = 9999;
            //obj.AddComponent<Lesson9_Test>();
            #endregion

            #region Lesson10
            //Lesson10
            //在ILRuntime中申明委托成员 关联自己工程中的函数
            //MyUnityDel1 fun = Fun1;
            //fun();

            //MyUnityDel2 fun2 = Fun2;
            //int result = fun2(5, 6);
            //Debug.Log(result);

            //在Unity中声明委托成员 关联ILRuntime工程中的函数
            //使用自定义委托
            //Lesson10 lesson10 = Camera.main.GetComponent<Lesson10>();
            //lesson10.fun = Fun1;
            //lesson10.fun();

            //lesson10.fun2 = Fun2;
            //result = lesson10.fun2(7, 7);
            //Debug.Log(result);

            //使用Action或者Func
            //lesson10.funAction = Fun1;
            //lesson10.funAction();
            //lesson10.funFunc = Fun2;
            //result = lesson10.funFunc(8, 8);
            //Debug.Log(result);


            //MyILRuntimeDel1 funIL = Fun1;
            //funIL();

            //MyILRuntimeDel2 funIL2 = Fun2;
            //result = fun2(1, 1);
            //Debug.Log(result);
            #endregion

            #region Lesson11
            //TestLesson11 t = new TestLesson11();
            //t.TestAbstract(99);
            //t.TestFun("哈哈哈");
            //t.valuePublic = 100;
            #endregion

            #region Lesson12
            //TestLesson12 t = new TestLesson12();
            //t.Speak();
            #endregion

            #region Lesson13
            //得到当前系统时间
            //System.DateTime currentTime = System.DateTime.Now;
            //for (int i = 0; i < 100000; i++)
            //{
            //    Lesson13.TestFun(i, i);
            //}
            //Debug.Log("花费的时间：" + (System.DateTime.Now - currentTime).TotalMilliseconds + "ms");
            #endregion

            #region Lesson14
            //System.DateTime currentTime = System.DateTime.Now;
            //Vector3 v1 = new Vector3(123, 54, 567);
            //Vector3 v2 = new Vector3(342, 678, 123);
            //float dot = 0;
            //for (int i = 0; i < 100000; i++)
            //{
            //    dot += Vector3.Dot(v1, v2);
            //}

            //Vector2 v3 = new Vector2(12, 56);
            //Vector2 v4 = new Vector2(123123, 45345);
            //for (int i = 0; i < 100000; i++)
            //{
            //    dot += Vector3.Dot(v3, v4);
            //}

            //Debug.Log("值类型计算花费的时间：" + (System.DateTime.Now - currentTime).TotalMilliseconds + "ms");
            #endregion

            #region Lesson15
            //GameObject obj = new GameObject();
            //ILRuntimeMono mono = obj.AddComponent<ILRuntimeMono>();
            ////由于Awake执行时机的特殊性 我们可以在添加了对应脚本后直接执行初始化相关逻辑即可
            ////无需通过事件或者委托的形式去触发它
            //Debug.Log("Awake");
            ////mono.awakeEvent += () =>
            ////{
            ////    Debug.Log("Awake");
            ////};
            //mono.startEvent += () =>
            //{
            //    Debug.Log("Start");
            //};

            //mono.updateEvent += () =>
            //{
            //    Debug.Log("Update");
            //};
            #endregion

            #region Lesson16
            //Lesson16 lesson16 = Camera.main.GetComponent<Lesson16>();
            //lesson16.StartCoroutine(Lesson16Test());

            //Lesson16Test2();
            #endregion

            #region Lesson18
            //Lesson18_Test test = new Lesson18_Test();
            //test.testI = 99;
            //test.testStr = "唐老狮";
            //test.listTest = new List<int>() { 1,2,3,4,5};
            //test.dicTest = new Dictionary<string, int>() { { "1", 99}, { "2", 88 }, { "3", 77 } };

            ////序列化Json字符串
            //string str = JsonMapper.ToJson(test);
            //Debug.Log(str);
            ////反序列化
            //Lesson18_Test test2 = JsonMapper.ToObject<Lesson18_Test>(str);
            //Debug.Log(test2.testI);
            //Debug.Log(test2.testStr);
            #endregion

            #region Lesson19
            //如果想要断点调试 那么必须保证 Unity工程或者项目已经启动了 才能附加进行调试
            //一定要先运行了游戏 在去附加调试
            Debug.Log("12331");
            #endregion
        }

        public static void Fun1()
        {
            Debug.Log("IL_Fun1");
        }

        public static int Fun2(int a, int b)
        {
            Debug.Log("IL_Fun2");
            return a + b;
        }

        public static IEnumerator Lesson16Test()
        {
            Debug.Log(0);
            yield return new WaitForSeconds(1f);
            Debug.Log(1);
            yield return new WaitForSeconds(1f);
            Debug.Log(2);
            yield return new WaitForSeconds(1f);
            Debug.Log(3);
        }

        public static async void Lesson16Test2()
        {
            Debug.Log(0);
            await Task.Delay(1000);
            Debug.Log(1);
            await Task.Delay(1000);
            Debug.Log(2);
            await Task.Delay(1000);
            Debug.Log(3);
        }

    }
}
