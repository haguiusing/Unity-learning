using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotFix_Project
{
    class TestLesson11 : Lesson11_Test
    {
        public override int ValuePor 
        { 
            get => valueProtected; 
            set => valueProtected = value; 
        }

        public override void TestFun(string str)
        {
            base.TestFun(str);
            Debug.Log("TestFun2:" + str);
        }


        public override void TestAbstract(int i)
        {
            Debug.Log("TestAbstract:" + i);
        }

        public void Speak()
        {
            Debug.Log("Speak");
        }
    }
}
