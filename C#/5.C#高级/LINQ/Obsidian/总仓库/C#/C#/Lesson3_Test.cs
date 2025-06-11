using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotFix_Project
{
    class Lesson3_Test
    {
        public int testI;

        private string str;
        public Lesson3_Test()
        {

        }

        public Lesson3_Test(string str)
        {
            this.str = str;
        }


        //Lesson4
        public string Str
        {
            get
            {
                return str;
            }
            set
            {
                str = value;
            }
        }

        //Lesson5
        public static void TestStaticFun()
        {
            Debug.Log("无参静态方法");
        }

        public static int TestStaticFun2(int i)
        {
            Debug.Log("有参静态方法" + i);

            return i + 10;
        }

        //Lesson6
        public void TestFun()
        {
            Debug.Log("无参无返回值 成员方法调用");
        }

        public int TestFun2(int i)
        {
            Debug.Log("有参有返回值 成员方法调用");
            return 10 + i;
        }

        //Lesson7
        public void TestFun(int i)
        {
            Debug.Log("重载函数1" + i);
        }

        public void TestFun(float f)
        {
            Debug.Log("重载函数2" + f);
        }

        //Lesson8
        public float TestFun3(int i, ref List<int> list, out float f)
        {
            f = .5f;
            list.Add(5);
            for (int j = 0; j < list.Count; j++)
                Debug.Log(list[j]);

            return i + list.Count + f;
        }
    }
}
