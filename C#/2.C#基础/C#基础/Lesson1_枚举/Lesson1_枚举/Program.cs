using System;

namespace Lesson1_枚举
{
    #region 知识点一：基本概念

    #region 1.枚举是什么
    // 枚举且一个比较特别的存在
    //它是一个被命名的整形常量的集合/
    //一般用它来表示 状态 类型 等等
    #endregion

    #region 2.申明枚举 和 申明枚举变量
    // 注意: 申明枚举 和 申明枚举变量 且两个概念
    //申明枚举:     相当于是 创建一个自定义的收举类型
    //申明校举变量: 使用申明的自定义枚举类型 创建一个枚举变量
    #endregion

    #region 3.申明枚举语法
    // 枚举名 以E或者E_开头 作为我们的命名规范
    //enun E_自定义枚举名
    //{
    //   自定义枚举项名字，//枚举中包要的 整形常量第一个默认值是0 下面会依次案加
    //   自定义收举项名字1，//1
    //   自定义枚举项名字2，//2
    //}

    enum E_自定义权举名
    {
        自定义枚举顺名字 = 5,   //第一个枚举项的默认值 变成5了
        自定交枚举项名字1,      // 6
        自定义收举项名字2 = 100,
        自定艾枚举项名字3,      //101
        自定义枚举项名字4,      //12
    }

    #endregion

    #endregion

    #region 知识点二：在哪里申明枚举
    //1.namespace语句块中 (常用)
    //2.class语句块中 struct语句块中了
    //注意:枚举不能在质数语句快中中明!!!
    enum E_MonsterType
    {
        Normal,//e
        Boss,//1
    }

    enum E_PlayerType
    {
        Main,
        Other,
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("枚举");

            #region 知识点三：枚举的使用
            //声明枚举变量
            //自定义的枚举类型 变量名 = 自定义枚举类型.枚举项
            E_PlayerType playerType = E_PlayerType.Main;
            if (playerType == E_PlayerType.Main)
            {
                Console.WriteLine("主玩家逻辑");
            }  
            else if (playerType == E_PlayerType.Other)
            {
                Console.WriteLine("其它玩家逻辑");
            }
                
            //枚举和switch是天生一对
            E_MonsterType monsterType = E_MonsterType.Boss;
            switch (monsterType)
            {
                case E_MonsterType.Normal:
                    //Console.wrsteLine(“普通怪物逻辑”);
                    //break;
                case E_MonsterType.Boss: 
                    Console.WriteLine("Boss逻辑");
                    break;
                default:
                    break;
            }


                E_PlayerType PlayerType = E_PlayerType.Main;
            switch (PlayerType)
            {
                case E_PlayerType.Main:
                    Console.WriteLine("主玩家逻辑");
                    break;

                case E_PlayerType.Other:
                    Console.WriteLine("其他玩家逻辑");
                    break;

                default:
                    Console.WriteLine("无法判断玩家");
                    break;
            }

            #endregion

            #region 知识点四：枚举的类型转换
            //1.枚举和int互转
            int i =(int)playerType; 
            Console.WriteLine(i);
            //int 转枚举
            playerType = 0;
            
            // 2.校举和string相互转换
            string str = playerType.ToString();
            Console.WriteLine(str);

            //把string转成枚举呢
            //Parse后 第一个参数 : 你要转为的是哪个 枚类型 第二个参数: 用于转换的对应权举项的字符准
            //转换完毕后 是一个通用的类型 我们需要用括号强强转成我们想要的目标收举类型
            playerType = (E_PlayerType)Enum.Parse(typeof(E_PlayerType), "Other");
            Console.WriteLine(playerType);

            #endregion

            #region 知识点五：枚举的作用
            //在游戏开发中，对象很多时 会有许多的状态
            //比如玩家 有一个动作状态 我们需要用一个变量或需
            //综合考虑 可能会使用 int 来表示他的状态
            // 1 行走 2 特机 3 跑步 4 跳跃。。等等

            // 枚举可以帮助我们 清晰的分清是状志的含义
            #endregion

        }
    }
}