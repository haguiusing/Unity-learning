namespace Lesson15_日期和时间知识点一
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson15_日期和时间知识点一");
            #region 知识点一：目前学习时间和时间相关的内容
            //目前我们只在Unity当中学习过Time类
            //我们可以通过Time获取当前的游戏相关的时
            //比如帧间隔时间 游戏运行的时间和帧数等等内容

            //但是我们并没有学习与真实世界时间相关的小
            //比如如何得知当前时间的 年 月 日 时 分 秒
            //这节课我们将要学习的就是真实时间相关的内容
            #endregion

            #region 知识点二：目前学习时间和时间相关的内容
            //目前我们只在Unity当中学习过Time类
            //我们可以通过Time获取当前的游戏相关的时
            //比如帧间隔时间 游戏运行的时间和帧数等等内容

            //但是我们并没有学习与真实世界时间相关的小
            //比如如何得知当前时间的 年 月 日 时 分 秒
            //这节课我们将要学习的就是真实时间相关的内容
            #endregion

            #region 知识点三：一些关于时间的名词说明
            //1）时间单位转换
            //秒与毫秒: 1秒 = 1000毫秒
            //毫秒与微秒: 1毫秒 = 1000微秒
            //微秒与纳秒: 1微秒 = 1000纳秒

            //2）历法说明
            //格里高利历: 一般指公元，即公历纪年法，如2022年。

            //3）时间标准
            //格林尼治时间(GMT): 英国伦敦郊区的皇家格林尼治天文台的标准时间，因地球自转不规则且正在缓慢减速，已不再作为标准时间使用。
            //协调世界时(UTC): 又称世界统一时间、世界标准时间、国际协调时间，基于国际原子时间，通过加入闰秒来抵消地球自转变慢的影响，是当前世界调节时钟和时间的主要标准。

            //4）时间戳
            //定义: 从1970年1月1日（UNIX时间起点）到现在的时间间隔。
            //起源: 许多编程语言起源于UNIX系统，UNIX系统认为1970年1月1日0时是时间纪元。
            //原因: 最初计算机操作系统是32位，时间也用32位表示，32位能表示的最大十进制数是2147483647，约等于68年，因此选择1970年作为起点可以覆盖到计算机产生的年代。

            //5）时间戳的作用
            //数据存储: 有了时间戳的概念，在存储一些数据时更加方便。

            //6）时间戳的当前状态
            //当前操作系统: 现在是64位操作系统，能表示的数非常大，不存在68年的最大限制，但为保留传统，时间戳仍指从1970年1月1日到现在的时间。
            #endregion

            #region 知识点四：DateTime_具体的日期和时间 https://www.cnblogs.com/Pickuper/articles/2058880.html
            //命名空间：System
            //DateTime 是 C# 提供给我们处理日期和时间的结构体
            //DateTime 对象的默认值和最小值是 0001年1月1日00:00:00（午夜）
            //                      最大值可以是9999年12月31日晚上11:59:59
            #region DateTime初始化
            //主要参数:
            //  年、月、日、时、分、秒、毫秒
            //  ticks: 以格里高利历00:00:00.000年1月1日以来的100纳秒间隔数表示,一般是一个很大的数字
            //次要参数:
            //  DateTimeKind: 日期时间种类
            //  Local: 本地时间
            //  Utc: UTC时间
            //  Unspecified: 不指定
            //  Calendar: 日历
            //使用哪个国家的日历,一般在Unity开发中不使用
            DateTime dt = new DateTime(2022, 1, 1, 10, 10, 10, 100);

            //年、月、日、时、分、秒
            Console.WriteLine(dt.Year + "年" + dt.Month + "月" + dt.Day + "日" + dt.Hour + "时" + dt.Minute + "分" + dt.Second + "秒" + dt.Millisecond + "毫秒");

            //以格里高利历00:00:00.000年1月1日以来的100纳秒间隔数表示,一般是一个很大的数字
            Console.WriteLine(dt.Ticks);

            //一年的第多少天
            Console.WriteLine(dt.DayOfYear);

            //星期几
            Console.WriteLine(dt.DayOfWeek);
            #endregion

            #region 获取时间
            //当前时间日期
            DateTime nowTime = DateTime.Now;
            Console.WriteLine(nowTime.Minute);

            //返回今日日期
            DateTime nowTime2 = DateTime.Today;
            Console.WriteLine(nowTime2.Year + "年" + nowTime2.Month + "月" + nowTime2.Day);

            //返回UTC时间
            DateTime nowTimeUTC = DateTime.UtcNow;
            #endregion

            #region 计算时间
            //各种加时间
            DateTime nowTime3 = nowTime.AddDays(-1);
            Console.WriteLine(nowTime3.Day);
            #endregion

            #region 字符串输出
            Console.WriteLine(nowTime.ToString());
            Console.WriteLine(nowTime.ToShortTimeString());
            Console.WriteLine(nowTime.ToShortDateString());
            Console.WriteLine(nowTime.ToLongTimeString());
            Console.WriteLine(nowTime.ToLongDateString());

            Console.WriteLine(nowTime.ToString("D"));
            Console.WriteLine(nowTime.ToString("yyyy-MM-dd-ddd/HH-mm-ss"));

            #endregion

            #region 

            #endregion 字符串转DateTime 
            //字符串 转成 DateTime 成功的话
            //那么这个字符串的格式是有要求的 一定是最基本的_toString()转换出来的字符串才能转回去
            // 年/月/日 时:分:秒
            string str = nowTime.ToString();
            //str = nowTime.ToString("yyyy-MM-dd-ddd/HH-mm-ss");   //转换失败

            DateTime dt3;
            if (DateTime.TryParse(str, out dt3))
            {
                Console.WriteLine(dt3);
            }
            else
            {
                Console.WriteLine("转换失败");
            }

            #region 存储时间
            //存储时间 方式很多
            //1.可以直接存字符串
            //2.可以直接存ticks
            //3.可以直接存时间戳信息

            //存储时间戳的形式 更加节约
            #endregion

            #region DateTime方法
            DateTime.Compare(dt, nowTime);    //比较两个日期时间的大小
            DateTime.DaysInMonth(2022, 1);    //获取某年某月的天数
            DateTime.Equals(dt, nowTime);      //判断两个日期时间是否相等
            DateTime.FromBinary(123456789);   //将64位整数转换为DateTime
            DateTime.FromFileTime(123456789); //将文件时间转换为DateTime
            DateTime.FromFileTimeUtc(123456789); //将UTC文件时间转换为DateTime
            DateTime.FromOADate(123456789);   //将OADate转换为DateTime
            DateTime.IsLeapYear(2022);        //判断是否为闰年
            DateTime.Parse("2022-01-01 10:10:10"); //将字符串转换为DateTime
            DateTime.ParseExact("2022-01-01 10:10:10", "yyyy-MM-dd HH:mm:ss", null); //将字符串转换为DateTime
            DateTime.ReferenceEquals(dt, nowTime); //判断两个日期时间是否引用同一对象
            DateTime.SpecifyKind(nowTime, DateTimeKind.Utc); //指定DateTime的种类
            DateTime.TryParse("2022-01-01 10:10:10", out DateTime dt4); //尝试将字符串转换为DateTime
            //DateTime.TryParseExact("2022-01-01 10:10:10", "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None, out DateTime dt5); //尝试将字符串转换为DateTime
            #endregion
            #endregion

            #region 知识点五：TimeSpan_时间间隔
            //命名空间 System
            // TimeSpan 是 C# 提供给我们的时间跨度结构体
            // 用两个DateTime对象相减 可以得到该对象

            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1);
            Console.WriteLine(ts.TotalMinutes);
            Console.WriteLine(ts.TotalSeconds);
            Console.WriteLine(ts.TotalDays);
            Console.WriteLine(ts.TotalHours);
            Console.WriteLine(ts.Ticks);

            Console.WriteLine(ts.Days + ts.Hours + ts.Minutes + ts.Seconds + ts.Milliseconds);

            #region 初始化它来代表时间间隔
            TimeSpan ts2 = new TimeSpan(1, 0, 0, 0);
            DateTime timeNow = DateTime.Now + ts2;
            #endregion

            #region 用它相互计算
            TimeSpan ts3 = new TimeSpan(0, 1, 1, 1);
            TimeSpan ts4 = ts2 + ts3;
            #endregion

            #region 自带常量方便用于和ticks进行计算
            Console.WriteLine(ts4.Ticks / TimeSpan.TicksPerSecond);

            //NanosecondsPerTick = 100;       //每tick的纳秒数
            //TicksPerDay = 864000000000;     //每天的tick数
            //TicksPerHour = 36000000000;     //每小时的tick数
            //TicksPerMicrosecond = 10;       //每微秒的tick数
            //TicksPerMillisecond = 10000;    //每毫秒的tick数
            //TicksPerMinute = 600000000;     //每分钟的tick数
            //TicksPerSecond = 10000000;      //每秒的tick数    
            #endregion

            #region TimeSpan方法
            #endregion
            #endregion
        }
    }
}
