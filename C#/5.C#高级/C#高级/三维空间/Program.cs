using System.Numerics;

namespace 三维空间
{
    internal class Program
    {
        //Vector是静态类，不能实例化，只能通过静态方法创建实例

        static Vector<int> intVectorL = new Vector<int>();
        static Vector<int> intVectorR = new Vector<int>();
        static Vector<int> intVector = new Vector<int>();

        static Vector<float> floatVectorL = new Vector<float>();
        static Vector<float> floatVectorR = new Vector<float>();
        static Vector<float> floatVector = new Vector<float>();

        static Vector<double> doubleVectorL = new Vector<double>();
        static Vector<double> doubleVectorR = new Vector<double>();
        static Vector<double> doubleVector = new Vector<double>();

        static Vector<long> longVectorL = new Vector<long>();
        static Vector<long> longVectorR = new Vector<long>();
        static Vector<long> longVector = new Vector<long>();

        static Vector<ushort> ushortVectorL = new Vector<ushort>();
        static Vector<ushort> ushortVectorR = new Vector<ushort>();
        static Vector<ushort> ushortVector = new Vector<ushort>();

        static Vector<byte> byteVectorL = new Vector<byte>();
        static Vector<byte> byteVectorR = new Vector<byte>();
        static Vector<byte> byteVector = new Vector<byte>();

        static Vector2 vector2 = new Vector2();
        static Vector2 vector2l = new Vector2();
        static Vector2 vector2r = new Vector2();

        static Vector3 vector3 = new Vector3();
        static Vector3 vector3l = new Vector3();
        static Vector3 vector3r = new Vector3();

        static Vector4 vector4 = new Vector4();
        static Vector4 vector4l = new Vector4();
        static Vector4 vector4r = new Vector4();

        static void Main(string[] args)
        {
            Console.WriteLine("三维空间");

            Vector.Add<int> (intVectorL, intVectorR);
            Vector2.Abs(vector2l);

            #region 向量方法
            //计算相关
            Vector.Abs<int>(intVectorL);   //求绝对值
            Vector.Add<int>(intVectorL, intVectorR);   //向量加法
            Vector.AndNot<int>(intVectorL, intVectorR);   //按位取反
            Vector.BitwiseAnd<int>(intVectorL, intVectorR);   //按位与
            Vector.BitwiseOr<int>(intVectorL, intVectorR);   //按位或
            Vector.Ceiling(doubleVectorL);   //向上取整
            Vector.Floor(doubleVectorL);   //向下取整
            Vector.Divide(doubleVectorL, doubleVectorR);   //向量除法
            Vector.Dot<int>(intVectorL, intVectorR);   //点乘
            Vector.Equals(vector2l, vector2r);   //相等 bool
            Vector.Equals<int>(intVectorL, intVectorR);   //相等
            Vector.Floor(doubleVectorL);   //向下取整
            Vector.GreaterThan(doubleVectorL, doubleVectorR);   //大于
            Vector.GreaterThan<int>(intVectorL, intVectorR);   //大于
            Vector.GreaterThanAll<int>(intVectorL, intVectorR);   //所有元素大于 bool
            Vector.GreaterThanAny<int>(intVectorL, intVectorR);   //存在元素大于 bool
            Vector.GreaterThanOrEqual(doubleVectorL, doubleVectorR);   //大于等于
            Vector.GreaterThanOrEqual<int>(intVectorL, intVectorR);   //大于等于
            Vector.GreaterThanOrEqualAll<int>(intVectorL, intVectorR);   //所有元素大于等于 bool
            Vector.GreaterThanOrEqualAny<int>(intVectorL, intVectorR);   //存在元素大于等于 bool
            Vector.LessThan(doubleVectorL, doubleVectorR);   //小于
            Vector.LessThan<int>(intVectorL, intVectorR);   //小于
            Vector.LessThanAll<int>(intVectorL, intVectorR);   //所有元素小于 bool
            Vector.LessThanAny<int>(intVectorL, intVectorR);   //存在元素小于 bool
            Vector.LessThanOrEqual(doubleVectorL, doubleVectorR);   //小于等于
            Vector.LessThanOrEqual<int>(intVectorL, intVectorR);   //小于等于
            Vector.LessThanOrEqualAll<int>(intVectorL, intVectorR);   //所有元素小于等于 bool
            Vector.LessThanOrEqualAny<int>(intVectorL, intVectorR);   //存在元素小于等于 bool
            Vector.Max<int>(intVectorL, intVectorR);   //求最大值
            Vector.Min<int>(intVectorL, intVectorR);   //求最小值
            Vector.Multiply<int>(intVectorL, intVectorR);   //向量乘法
            Vector.Narrow(intVectorL, intVectorR);   //向量缩减
            Vector.Negate<int>(intVectorL);   //求负值
            Vector.OnesComplement<int>(intVectorL);   //按位取反
            //Vector.ReferenceEquals(intVectorL, intVectorR);   //引用相等
            Vector.ShiftLeft(intVectorL, 1);   //向左移位
            Vector.ShiftRightArithmetic(intVectorL, 1);   //向右算术移位
            Vector.ShiftRightLogical(intVectorL, 1);   //向右逻辑移位
            Vector.SquareRoot<int>(intVectorL);   //求平方根
            Vector.Subtract<int>(intVectorL, intVectorR);   //向量减法
            Vector.Sum<int>(intVectorL);   //求和
            Vector.ToScalar<int>(intVectorL);   //向量转标量
            Vector.Widen(byteVector,out ushortVectorL, out ushortVectorR);   //向量扩展
            Vector.WidenLower(byteVector);   //向量扩展下
            Vector.WidenUpper(byteVector);   //向量扩展上
            Vector.Xor<int>(intVectorL, intVectorR);   //按位异或

            //条件相关
            Vector.ConditionalSelect(doubleVectorL, doubleVectorR, doubleVectorL);   //条件选择
            Vector.ConditionalSelect<int>(intVectorL, intVectorR, intVectorL);   //条件选择
            Vector.EqualsAll<int>(intVectorL, intVectorR);   //所有元素相等 bool
            Vector.EqualsAny<int>(intVectorL, intVectorR);   //存在元素相等 bool
            Vector.GetElement<int>(intVectorL, 0);   //获取元素
            Vector.WithElement<int>(intVectorL, 0, 1);   //设置元素

            //转换相关
            Vector.As<int, float>(intVectorL);   //向量类型转换
            Vector.AsVectorByte<int>(intVectorL);   //向量字节类型转换
            Vector.AsVectorDouble<int>(intVectorL);   //向量双精度类型转换
            Vector.AsVectorInt16<int>(intVectorL);   //向量短整型类型转换
            Vector.AsVectorInt32<int>(intVectorL);   //向量整型类型转换
            Vector.AsVectorInt64<int>(intVectorL);   //向量长整型类型转换
            Vector.AsVectorSByte<int>(intVectorL);   //向量字节类型转换
            Vector.AsVectorSingle<int>(intVectorL);   //向量单精度类型转换
            Vector.AsVectorNInt<int>(intVectorL);   //向量N整型类型转换
            Vector.AsVectorNUInt<int>(intVectorL);   //向量N无符号整型类型转换
            Vector.AsVectorUInt16<int>(intVectorL);   //向量无符号短整型类型转换
            Vector.AsVectorUInt32<int>(intVectorL);   //向量无符号整型类型转换
            Vector.AsVectorUInt64<int>(intVectorL);   //向量无符号长整型类型转换
            Vector.ConvertToDouble(longVectorL);   //整型向双精度转换
            Vector.ConvertToInt32(floatVectorL);   //单精度向整型转换
            Vector.ConvertToInt64(doubleVectorL);   //双精度向长整型转换
            Vector.ConvertToSingle(intVectorL);   //整型向单精度转换
            Vector.ConvertToUInt32(floatVectorL);   //长整型向无符号整型转换
            Vector.ConvertToUInt64(doubleVectorL);   //双精度向无符号长整型转换

            //指针相关
            //Vector.Load<int>(int*);   //加载向量,指针
            //Vector.LoadAligned<int>(int*);   //加载对齐向量,指针
            //Vector.LoadAlignedNonTemporal<int>(int*);   //加载对齐非临时向量,指针
            //Vector.Store<int>(ref intVector, int*);   //存储向量,指针
            //Vector.StoreAligned<int>(ref intVector, int*);   //存储对齐向量,指针
            //Vector.StoreAlignedNonTemporal<int>(ref intVector, int*);   //存储对齐非临时向量,指针
            //Vector.StoreUnsafe<int>(ref intVector, int*);   //存储向量,指针
            #endregion
        }
    }
}
