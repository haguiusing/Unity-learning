using System;

namespace MathClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MathClass");

            #region Math
            //涵盖了从简单的绝对值计算到三角函数、指数函数等更复杂的数学运算

            // 常量
            //E	表示由常量指定的自然对数基数，e。
            //PI 表示圆的周长与其直径的比率，由常量指定，π。
            //Tau  表示一个轮次的弧度数，由常量 τ 指定。

            // 简单
            Math.Abs(-10); //返回绝对值  10
            Math.BigMul(10, -20); //返回两个 32 位有符号整数的乘积  -200
            Math.BitDecrement(10); //返回减 1 后的值  9
            Math.BitIncrement(10); //返回加 1 后的值  11
            Math.Cbrt(27); //返回指定数字的立方根  3
            Math.Ceiling(3.4); //返回大于或等于指定数字的最小整数  4
            Math.Clamp(-2, 0, 10); //返回指定数字的夹取值  0
            Math.CopySign(3, -2); //返回具有 x 的大小和 y 的符号的数字  -3
            Math.DivRem(10, 3);   //返回两个指定数字的商和余数  (3, 1)
            Math.DivRem(10, 3, out int remainder); //返回两个指定数字的商和余数  1
            Math.Equals(10, 20); //返回两个指定数字是否相等  bool
            Math.Floor(3.4); //返回小于或等于指定数字的最大整数  3
            Math.FusedMultiplyAdd(1, 2, 3); //返回两个指定数字的乘积与第三个数字相加的结果  5
            Math.IEEERemainder(10, 3); //返回两个指定数字的余数  1
            Math.Max(10, 20); //返回两个指定数字中的最大值  20
            Math.MaxMagnitude(-100, 20); //返回两个指定数字的绝对值中较大的那个  -100
            Math.Min(10, 20); //返回两个指定数字中的最小值  10
            Math.MinMagnitude(-10, -20); //返回两个指定数字的绝对值中较小的那个  -10
            Math.ReciprocalEstimate(2); //返回指定数字的倒数（分子分母互换）的估计值  0.5
            Math.ReciprocalSqrtEstimate(0.25); //返回指定数字的倒数的平方根的估计值  2  
            Math.Round(3.4); //返回四舍五入的指定数字  3
            Math.ScaleB(10, 2); //返回指定数字乘以 2 的指定次幂的值  40
            Math.Sign(-3); //返回指定数字的符号  -1
            Math.Sqrt(16); //返回指定数字的平方根  4
            Math.Truncate(3.4); //返回小于或等于指定数字的整数部分  3
            //它们在功能上等同于正数。 不同之处在于它们如何处理负数。
            Math.Floor(2.5);// = 2
            Math.Truncate(2.5);// = 2


            Math.Floor(-2.5);// = -3
            Math.Truncate(-2.5);// = -2

            // 三角函数
            Math.Acos(0.5); //返回反余弦值  1.0471975511965976
            Math.Acosh(3); //返回反双曲余弦值  1.762747174039086
            Math.Asin(0.5); //返回反正弦值  0.5235987755982988    
            Math.Asinh(3); //返回反双曲正弦值  1.0986122886681096
            Math.Atan(0.5); //返回反正切值  0.4636476090008061
            Math.Atan2(1, 2); //返回给定 X 和 Y 坐标值的反正切值  0.4636476090008061 
            Math.Atanh(0.5); //返回反双曲正切值  0.5493061443340548
            Math.Cos(0); //返回指定角度的余弦值  1
            Math.Cosh(0); //返回指定双曲余弦值  1        
            Math.Sin(30); //返回指定角度的正弦值  0.5
            Math.SinCos(30); //返回指定角度的正弦值和余弦值  (0.5, 0.8660254037844386)
            Math.Sinh(0); //返回指定双曲正弦值  0

            Console.WriteLine(Math.Tan(45));
            // 指数函数
            Math.Exp(2); //返回指定底数的指数值  7.38905609893065
            Math.ILogB(2); //返回指定数字的以 2 为底的对数值  2
            Math.Log(Math.E); //返回指定底数的对数值  1
            Math.Log10(100); //返回以 10 为底的对数值  2
            Math.Log2(1024); //返回以 2 为底的对数值  10

            //幂函数
            Math.Pow(2, 3); //返回指定基数和指数的幂值  8

            Math.Tan(45); //返回指定角度的正切值  1.6197751905438615
            Math.Tanh(3); //返回指定双曲正切值   0.9950547536867305

            //Math.ReferenceEquals(null, null); //返回两个对象是否引用同一对象  bool

            #endregion

            #region MathF
            //与 Math类(大多采用double类型) 类似，但提供了一些针对 float 类型的数学函数。

            //Unity的Math类和MathF类还提供了插值函数Lerp等
            //D:\Obsidian Unity\Unity\Unity四部曲\Assets\Scripts\Unity基础\3D数学\Lesson1_Mathf.cs
            #endregion
        }
    }
}
