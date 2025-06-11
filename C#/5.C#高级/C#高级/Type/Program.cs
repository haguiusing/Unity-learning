using System.Collections;
using System.Globalization;
using System.Reflection;

internal class Program
{
    //在C#中，Type 类是 System 命名空间中提供的一个类，它表示当前正在运行的程序中的类型。
    //每个加载的类型（无论是类、接口、结构、枚举还是委托）都有一个 Type 对象。

    //APT文档： https://learn.microsoft.com/zh-cn/dotnet/api/system.type?view=net-8.0
    private static void Main(string[] args)
    {
        Type t = typeof(String);
        ShowTypeInfo(t);  //输出类型信息

        int a = 42;
        GetTypeObject(a);//获取 Type 对象

        TypeAllmethods();//Type所有方法

        TypeAllExtensionMethods();   //Type所有扩展方法
    }

    private static void TypeAllExtensionMethods()
    {
        throw new NotImplementedException();
    }

    private static void TypeAllmethods()
    {
        Console.WriteLine("*******Type所有方法*******");
        //只记录参数最多的方法，举例常用的方法：
        TypeFilter myFilter = new TypeFilter(MyInterfaceFilter);  //自定义过滤器
        Object obj = new object();    //实例对象
        Object? obj_nullable = null;  //可空类型
        Object[] objArray = new Object[1];  //数组
        Object?[]? objectsArray_nullable = null;
        MemberTypes memberTypes_all = MemberTypes.All;  //所有成员类型
        BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;  //绑定标志
        //MemberFilter filter;
        MemberFilter? filter_nullable = null;  //可空类型
        Type type = typeof(Hashtable);  //类型对象
        Type? type_nullable = null;  //可空类型
        Type[] types = typeof(Hashtable).Assembly.GetTypes();  //类型数组
        Hashtable hashtableObj = new Hashtable();  //实例对象
        Type objType = hashtableObj.GetType();  //获取实例对象的 Type 对象
        MemberInfo memberInfo = hashtableObj.GetType().GetMember("Capacity")[0];  //获取成员信息
        ParameterModifier[]? modifiers = null;  //可空类型
        ParameterInfo[] parameterInfos = objType.GetConstructors()[0].GetParameters();  //获取构造函数的参数信息
        ParameterInfo parameterInfo = parameterInfos[0];  //获取参数信息
        ParameterInfo[] parameterInfos_all = objType.GetMethods()[0].GetParameters();  //获取方法的参数信息
        String? string_nullable = null;
        String[]? stringArray_nullable = null;
        Binder? binder_nullable = null;
        CultureInfo? cultureInfo_nullable = null;

        //bool Equals(object? o)/Equals(Type? o);
        //确定当前 Type 的基础系统类型是否与指定 Object 或 Type 的基础系统类型相同。
        //Equals(Type) 确定当前 Type 的基础系统类型是否与指定 Type 的基础系统类型相同。
        //Equals(Object) 确定当前 Type 的基础系统类型是否与指定 Object 的基础系统类型相同。
        Type a = typeof(System.String);
        Type b = typeof(System.Int32);
        bool Equals = a.Equals(b); //false

        //Type[] FindInterfaces(TypeFilter filter, object? filterCriteria);
        //返回表示接口（由当前 Type 所实现或继承）的筛选列表的 Type 对象数组。
        Type[] FindInterfaces = objType.FindInterfaces(myFilter, obj_nullable);

        //System.Reflection.MemberInfo[] FindMembers (System.Reflection.MemberTypes memberType, System.Reflection.BindingFlags bindingAttr, System.Reflection.MemberFilter? filter, object? filterCriteria);
        //返回指定成员类型的 MemberInfo 对象的筛选数组。
        MemberInfo[] FindMembers = objType.FindMembers(memberTypes_all, bindingFlags, filter_nullable, obj_nullable);

        //int GetArrayRank ();
        //获取数组中的维数。
        int GetArrayRank = typeof(int[,]).GetArrayRank();

        //System.Reflection.TypeAttributes GetAttributeFlagsImpl()
        //在派生类中重写时，实现 Attributes 属性，并获取枚举值的按位组合（它指示与 Type 关联的特性）。
        //TypeAttributes GetAttributeFlagsImpl = type.GetAttributeFlagsImpl();
        //protected

        //System.Reflection.ConstructorInfo? GetConstructor(BindingFlags, Binder, CallingConventions, Type[], ParameterModifier[])
        //用指定绑定约束和指定调用约定，搜索其参数与指定参数类型及修饰符匹配的构造函数。
        ConstructorInfo? GetConstructor = objType.GetConstructor(bindingFlags, null, new Type[] { typeof(int) }, null);

        //System.Reflection.ConstructorInfo? GetConstructorImpl(BindingFlags, Binder, CallingConventions, Type[], ParameterModifier[])
        //当在派生类中重写时，使用指定的绑定约束和指定的调用约定搜索其参数与指定的自变量类型和修饰符匹配的构造函数。
        //ConstructorInfo? GetConstructorImpl = objType.GetConstructorImpl(bindingFlags, null, CallingConventions.Any, new Type[] { typeof(int) }, null);
        //protected

        //System.Reflection.ConstructorInfo[] GetConstructors(BindingFlags)
        //当在派生类中重写时，使用指定 Type 搜索为当前 BindingFlags 定义的构造函数。
        ConstructorInfo[] GetConstructors = objType.GetConstructors(bindingFlags);

        //object[] GetCustomAttributes (Type attributeType, bool inherit);
        //在派生类中重写时，返回应用于此成员并由 Type 标识的自定义属性的数组。
        object[] GetCustomAttributes = objType.GetCustomAttributes(true);

        //System.Collections.Generic.IList<System.Reflection.CustomAttributeData> GetCustomAttributesData ();
        //返回 CustomAttributeData 对象列表，这些对象表示已应用到目标成员的特性相关数据。
        IList<CustomAttributeData> CustomAttributeData = objType.GetCustomAttributesData();

        //System.Reflection.MemberInfo[] GetDefaultMembers ();
        //搜索为设置了 Type 的当前 DefaultMemberAttribute 定义的成员。
        MemberInfo[] GetDefaultMembers = objType.GetDefaultMembers();

        //Type? GetElementType ();
        //当在派生类中重写时，返回当前数组、指针或引用类型包含的或引用的对象的 Type。
        Type? GetElementType = typeof(int[]).GetElementType();

        //string? GetEnumName (object value);
        //返回当前枚举类型中具有指定值的常数的名称。
        string? GetEnumName = typeof(ConsoleColor).GetEnumName(ConsoleColor.Red);

        //Type GetEnumUnderlyingType ();
        //返回当前枚举类型的基础类型。
        Type GetEnumUnderlyingType = typeof(ConsoleColor).GetEnumUnderlyingType();

        //Array GetEnumValues ();
        //返回当前枚举类型中各个常数的值组成的数组。
        Array GetEnumValues = typeof(ConsoleColor).GetEnumValues();

        //Array GetEnumValuesAsUnderlyingType ();
        //检索此枚举类型的基础类型常量的值数组。
        Array GetEnumValuesAsUnderlyingType = typeof(ConsoleColor).GetEnumValuesAsUnderlyingType();

        //System.Reflection.EventInfo? GetEvent (string name, System.Reflection.BindingFlags bindingAttr);
        //当在派生类中重写时，使用指定绑定约束，返回表示指定事件的 EventInfo 对象。
        EventInfo? GetEvent = objType.GetEvent("TextChanged", bindingFlags);

        //System.Reflection.EventInfo[] GetEvents (System.Reflection.BindingFlags bindingAttr);
        //当在派生类中重写时，使用指定绑定约束，返回由当前 Type 声明或继承的所有公共事件。
        EventInfo[] GetEvents = objType.GetEvents(bindingFlags);

        //System.Reflection.FieldInfo? GetField (string name, System.Reflection.BindingFlags bindingAttr);
        //使用指定绑定约束搜索指定字段。
        FieldInfo? GetField = objType.GetField("myField", bindingFlags);

        //扩展方法
        //System.Reflection.FieldInfo[] GetFields (System.Reflection.BindingFlags bindingAttr);
        //当在派生类中重写时，使用指定绑定约束，返回当前 Type 的所有公共字段。
        FieldInfo[] GetFields = objType.GetFields(bindingFlags);

        //Type[] GetFunctionPointerCallingConventions ();
        //在派生类中重写时，返回当前函数指针 Type的调用约定。
        Type[] GetFunctionPointerCallingConventions = typeof(delegate* unmanaged[Stdcall]<int, int>).GetFunctionPointerCallingConventions();

        //Type[] GetFunctionPointerParameterTypes ();
        //在派生类中重写时，返回当前函数指针 Type的参数类型。
        Type[] GetFunctionPointerParameterTypes = typeof(delegate* unmanaged[Stdcall]<int, int>).GetFunctionPointerParameterTypes();

        //Type GetFunctionPointerReturnType ();
        //在派生类中重写时，返回当前函数指针 Type的返回类型。
        Type GetFunctionPointerReturnType = typeof(delegate* unmanaged[Stdcall]<int, int>).GetFunctionPointerReturnType();

        //Type[] GetGenericArguments ();
        //返回表示封闭式泛型类型的类型参数或泛型类型定义的类型参数的 Type 对象的数组。
        Type[] GetGenericArguments = typeof(List<>).GetGenericArguments();

        //Type[] GetGenericParameterConstraints ();
        //返回表示当前泛型类型参数约束的 Type 对象的数组。
        Type[] GetGenericParameterConstraints = typeof(List<int>).GetGenericParameterConstraints();

        //Type GetGenericTypeDefinition ();
        //返回一个表示可用于构造当前泛型类型的泛型类型定义的 Type 对象。
        Type GetGenericTypeDefinition = typeof(List<int>).GetGenericTypeDefinition();

        //int GetHashCode ();
        //返回此实例的哈希代码。
        int GetHashCode = typeof(Hashtable).GetHashCode();

        //Type? GetInterface (string name, bool ignoreCase);
        //当在派生类中重写时，搜索指定的接口，指定是否要对接口名称执行不区分大小写的搜索。
        Type? GetInterface = objType.GetInterface("IDeserializationCallback", true);

        //System.Reflection.InterfaceMapping GetInterfaceMap (Type interfaceType);
        //返回指定接口类型的接口映射。
        InterfaceMapping GetInterfaceMap = objType.GetInterfaceMap(typeof(IDisposable));

        //Type[] GetInterfaces ();
        //当在派生类中重写时，获取由当前 Type 实现或继承的所有接口。
        Type[] GetInterfaces = objType.GetInterfaces();

        //System.Reflection.MemberInfo[] GetMember (string name, System.Reflection.MemberTypes type, System.Reflection.BindingFlags bindingAttr);
        //使用指定绑定约束搜索指定成员类型的指定成员。
        MemberInfo[] GetMember = objType.GetMember("myField", MemberTypes.Field, bindingFlags);

        //System.Reflection.MemberInfo[] GetMembers (System.Reflection.BindingFlags bindingAttr);
        //当在派生类中重写时，使用指定绑定约束，搜索为当前 Type 定义的成员。
        MemberInfo[] GetMembers = objType.GetMembers(bindingFlags);

        //System.Reflection.MemberInfo GetMemberWithSameMetadataDefinitionAs (System.Reflection.MemberInfo member);
        //MemberInfo在与指定的 MemberInfo匹配的当前 Type 上搜索 。
        MemberInfo GetMemberWithSameMetadataDefinitionAs = objType.GetMemberWithSameMetadataDefinitionAs(memberInfo);

        //System.Reflection.MethodInfo? GetMethod (string name, int genericParameterCount, System.Reflection.BindingFlags bindingAttr, System.Reflection.Binder? binder, System.Reflection.CallingConventions callConvention, Type[] types, System.Reflection.ParameterModifier[]? modifiers);
        //使用指定的绑定约束和指定的调用约定搜索其参数与指定泛型参数计数、参数类型及修饰符匹配的指定方法。
        MethodInfo? GetMethod = objType.GetMethod("MyMethod", 0, bindingFlags, null, CallingConventions.Any, types, modifiers);

        //System.Reflection.MethodInfo? GetMethodImpl (string name, int genericParameterCount, System.Reflection.BindingFlags bindingAttr, System.Reflection.Binder? binder, System.Reflection.CallingConventions callConvention, Type[]? types, System.Reflection.ParameterModifier[]? modifiers);
        //当在派生类中重写时，使用指定的绑定约束和指定的调用约定搜索其参数与指定泛型参数计数、参数类型和修饰符匹配的指定方法。
        //MethodInfo? GetMethodImpl = objType.GetMethodImpl("MyMethod", 0, bindingFlags, null, CallingConventions.Any, types, modifiers);
        //protected

        //System.Reflection.MethodInfo[] GetMethods (System.Reflection.BindingFlags bindingAttr);
        //当在派生类中重写时，使用指定绑定约束，搜索为当前 Type 定义的方法。
        MethodInfo[] GetMethods = objType.GetMethods(bindingFlags);

        //Type? GetNestedType (string name, System.Reflection.BindingFlags bindingAttr);
        //当在派生类中重写时，使用指定绑定约束搜索指定嵌套类型。
        Type? GetNestedType = objType.GetNestedType("MyNestedType", bindingFlags);

        //Type[] GetNestedTypes (System.Reflection.BindingFlags bindingAttr);
        //当在派生类中重写时，使用指定绑定约束搜索嵌套在当前 Type 中的类型。
        Type[] GetNestedTypes = objType.GetNestedTypes(bindingFlags);

        //Type[] GetOptionalCustomModifiers ();
        //在派生类中重写时，返回当前 Type的可选自定义修饰符。
        Type[] GetOptionalCustomModifiers = typeof(int).MakeByRefType().GetOptionalCustomModifiers();

        //System.Reflection.PropertyInfo[] GetProperties (System.Reflection.BindingFlags bindingAttr);
        //当在派生类中重写时，使用指定绑定约束，搜索当前 Type 的属性。
        PropertyInfo[] GetProperties = objType.GetProperties(bindingFlags);

        //System.Reflection.PropertyInfo? GetProperty (string name, System.Reflection.BindingFlags bindingAttr, System.Reflection.Binder? binder, Type? returnType, Type[] types, System.Reflection.ParameterModifier[]? modifiers);
        //使用指定的绑定约束，搜索参数与指定的自变量类型及修饰符匹配的指定属性。
        PropertyInfo? GetProperty = objType.GetProperty("MyProperty", bindingFlags, null, type_nullable, types, modifiers);

        //System.Reflection.PropertyInfo? GetPropertyImpl (string name, System.Reflection.BindingFlags bindingAttr, System.Reflection.Binder? binder, Type? returnType, Type[]? types, System.Reflection.ParameterModifier[]? modifiers);
        //当在派生类中重写时，使用指定的绑定约束搜索其参数与指定的参数类型和修饰符匹配的指定属性。
        //PropertyInfo? GetPropertyImpl = objType.GetPropertyImpl("MyProperty", bindingFlags, null, type_nullable, types, modifiers);
        //protected

        //Type[] GetRequiredCustomModifiers ();
        //在派生类中重写时，返回当前 Type所需的自定义修饰符。
        Type[] GetRequiredCustomModifiers = typeof(int).MakeByRefType().GetRequiredCustomModifiers();

        //Type? GetType (string typeName, Func<System.Reflection.AssemblyName,System.Reflection.Assembly?>? assemblyResolver, Func<System.Reflection.Assembly?,string,bool,Type?>? typeResolver, bool throwOnError, bool ignoreCase);
        //获取具有指定名称的类型，指定是否执行区分大小写的搜索，在找不到类型时是否引发异常，（可选）提供自定义方法以解析程序集和该类型。
        Type? GetType = Type.GetType("System.Int32", null, null, false, false);

        //Type[] GetTypeArray (object[] args);
        //获取指定数组中对象的类型。
        Type[] GetTypeArray = Type.GetTypeArray(objArray);

        //TypeCode GetTypeCode (Type? type);
        //获取指定 Type 的基础类型代码。
        TypeCode GetTypeCode = Type.GetTypeCode(typeof(int));

        //TypeCode GetTypeCodeImpl ();
        //返回此 Type 实例的基础类型代码。
        //TypeCode GetTypeCodeImpl = typeof(int).GetTypeCodeImpl();
        //protected

        //[System.Runtime.Versioning.SupportedOSPlatform("windows")]
        //Type? GetTypeFromCLSID (Guid clsid, string? server, bool throwOnError);
        //从指定服务器获取与指定类标识符 (CLSID) 关联的类型，指定在加载该类型时如果发生错误是否引发异常。
        Type? GetTypeFromCLSID = Type.GetTypeFromCLSID(Guid.NewGuid(), null, false);

        //Type? GetTypeFromHandle (RuntimeTypeHandle handle);
        //获取由指定类型句柄引用的类型。
        Type? GetTypeFromHandle = Type.GetTypeFromHandle(typeof(int).TypeHandle);

        //[System.Runtime.Versioning.SupportedOSPlatform("windows")]
        //Type? GetTypeFromProgID (string progID, string? server, bool throwOnError);
        //从指定服务器获取与指定程序标识符 (progID) 关联的类型，指定如果在加载该类型时发生错误是否引发异常。
        Type? GetTypeFromProgID = Type.GetTypeFromProgID("ProgID", string_nullable, false);

        //RuntimeTypeHandle GetTypeHandle (object o);
        //获取指定对象的 Type 的句柄。
        RuntimeTypeHandle typeHandle = Type.GetTypeHandle(obj);

        //bool HasElementTypeImpl ();
        //当在派生类中重写时，实现 HasElementType 属性，确定当前 Type 是否包含另一类型或对其引用；即，当前 Type 是否是数组、指针或由引用传递。
        //bool isHasElementTypeImpl = Type.HasElementTypeImpl();
        //protected

        //bool HasSameMetadataDefinitionAs (System.Reflection.MemberInfo other);
        //表示类型声明：类类型、接口类型、数组类型、值类型、枚举类型、类型参数、泛型类型定义，以及开放或封闭构造的泛型类型。(继承自 MemberInfo)
        bool isHasSameMetadataDefinitionAs = type.HasSameMetadataDefinitionAs(memberInfo);

        //object? InvokeMember (string name, System.Reflection.BindingFlags invokeAttr, System.Reflection.Binder? binder, object? target, object?[]? args, System.Reflection.ParameterModifier[]? modifiers, System.Globalization.CultureInfo? culture, string[]? namedParameters);
        //当在派生类中重写时，使用指定的绑定约束并匹配指定的参数列表、修饰符和区域性，调用指定成员。
        object? InvokeMember = type.InvokeMember("InvokeMember", bindingFlags, binder_nullable, obj_nullable, objectsArray_nullable, modifiers, cultureInfo_nullable, stringArray_nullable);

        //bool IsArrayImpl ();
        //在派生类中重写时，实现 IsArray 属性并确定 Type 是否为数组。
        //bool isIsArrayImpl = typeof(int[]).IsArrayImpl();
        //protected

        //bool IsAssignableFrom (Type? c);
        //确定指定类型 c 的实例是否能分配给当前类型的变量。
        bool isIsAssignableFrom = typeof(int).IsAssignableFrom(typeof(long));

        //bool IsAssignableTo (Type? targetType);
        //确定当前类型是否可分配给指定 targetType 的变量。
        bool isIsAssignableTo = typeof(int).IsAssignableTo(typeof(long));

        //bool IsByRefImpl ();
        //在派生类中重写时，实现 IsByRef 属性并确定Type 是否通过引用传递。
        //bool isIsByRefImpl = typeof(int).MakeByRefType().IsByRefImpl();
        //protected

        //bool IsCOMObjectImpl ();
        //当在派生类中重写时，实现 IsCOMObject 属性并确定 Type 是否为 COM 对象。
        //bool isIsCOMObjectImpl = typeof(int).IsCOMObjectImpl();
        //protected

        //bool IsContextfulImpl ();
        //实现 IsContextful 属性并确定 Type 在上下文中是否可以被承载。
        //bool isIsContextfulImpl = typeof(int).IsContextfulImpl();
        //protected

        //bool IsDefined (Type attributeType, bool inherit);
        //在派生类中重写时，指示是否将指定类型或其派生类型的一个或多个特性应用于此成员。(继承自 MemberInfo)
        bool isIsDefined = type.IsDefined(typeof(ObsoleteAttribute), false);

        //bool IsEnumDefined (object value);
        //返回一个值，该值指示当前的枚举类型中是否存在指定的值。
        bool isIsEnumDefined = typeof(ConsoleColor).IsEnumDefined(ConsoleColor.Red);

        //bool IsEquivalentTo (Type? other);
        //确定两个 COM 类型是否具有相同的标识，以及是否符合类型等效的条件。
        bool isIsEquivalentTo = typeof(int).IsEquivalentTo(typeof(long));

        //bool IsInstanceOfType (object? o);
        //确定指定的对象是否是当前 Type 的实例。
        bool isIsInstanceOfType = typeof(int).IsInstanceOfType(obj);

        //bool IsMarshalByRefImpl ();
        //实现 IsMarshalByRef 属性并确定 Type 是否按引用来进行封送。
        //bool isIsMarshalByRefImpl = typeof(int).IsMarshalByRefImpl();
        //protected

        //bool IsPointerImpl ();
        //在派生类中重写时，实现 IsPointer 属性并确定 Type 是否为指针。
        //bool isIsPointerImpl = typeof(int).MakePointerType().IsPointerImpl();
        //protected

        //bool IsPrimitiveImpl ();
        //在派生类中重写时，实现 IsPrimitive 属性并确定 Type 是否为基元类型之一。
        //bool isIsPrimitiveImpl = typeof(int).IsPrimitiveImpl();
        //protected

        //bool IsSubclassOf (Type c);
        //确定当前 Type 是否派生自指定的 Type。
        bool isIsSubclassOf = typeof(int).IsSubclassOf(typeof(long));

        //bool IsValueTypeImpl ();
        //实现 IsValueType 属性并确定 Type 是否是值类型；即，它不是值类或接口。
        //bool isIsValueTypeImpl = typeof(int).IsValueTypeImpl();
        //protected

        //Type MakeArrayType ();
        //返回 Type 对象，该对象表示当前类型的一维数组（下限为零）。
        Type MakeArrayType = typeof(int).MakeArrayType();

        //Type MakeArrayType (int rank);
        //返回 Type 对象，该对象表示一个具有指定维数的当前类型的数组。
        Type MakeArrayType_rank = typeof(int).MakeArrayType(2);

        //Type MakeByRefType ();
        //返回表示作为 Type 参数（在 Visual Basic 中为 ref 参数）传递时的当前类型的 ByRef 对象。
        Type MakeByRefType = typeof(int).MakeByRefType();

        //Type MakeGenericMethodParameter (int position);
        //返回一个签名类型对象，该对象可以传递到 Type[] 方法的 GetMethod 数组参数中以表示泛型参数引用。
        Type MakeGenericMethodParameter = Type.MakeGenericMethodParameter(0);

        //Type MakeGenericSignatureType (Type genericTypeDefinition, params Type[] typeArguments);
        //创建一个泛型签名类型，该类型允许第三方重新实现反射，从而完全支持在查询类型成员时使用签名类型。
        Type MakeGenericSignatureType = Type.MakeGenericSignatureType(typeof(List<>), typeof(int));

        //Type MakeGenericType (params Type[] typeArguments);
        //替代由当前泛型类型定义的类型参数组成的类型数组的元素，并返回表示结果构造类型的 Type 对象。
        Type MakeGenericType = typeof(List<>).MakeGenericType(typeof(int));

        //Type MakePointerType ();
        //返回表示指向当前类型的指针的 Type 对象。
        Type MakePointerType = typeof(int).MakePointerType();

        //object MemberwiseClone ();
        //创建当前 Object 的浅表副本。(继承自 Object)
        //object objClone = obj.MemberwiseClone();
        //protected

        //[System.Obsolete("ReflectionOnly loading is not supported and throws PlatformNotSupportedException.", DiagnosticId="SYSLIB0018", UrlFormat="https://aka.ms/dotnet-warnings/{0}")]
        //Type? ReflectionOnlyGetType (string typeName, bool throwIfNotFound, bool ignoreCase);
        //已过时.获取具有指定名称的 Type，指定是否执行区分大小写的搜索，以及在找不到类型时是否引发异常。 该类型只为反射加载，而不为执行加载。
        Type? ReflectionOnlyGetType = Type.ReflectionOnlyGetType("System.Int32", false, false);

        //string ToString ();
        //返回表示当前 String 的名称的 Type。
        string ToString = typeof(int).ToString();
    }

    public static bool MyInterfaceFilter(Type typeObj, Object? criteriaObj)
    {
        if (typeObj.ToString() == criteriaObj?.ToString())
            return true;
        else
            return false;
    }

    private static void GetTypeObject(int a)
    {
        Console.WriteLine("*******Type所有属性*******");
        //方法1：object中的 GetType()可以获取对象的Type
        Type t = a.GetType();

        //方法2：Type.GetTypeFromHandle()可以获取Type对象
        Type t1 = typeof(int);

        //方法3：Type.GetType()可以获取Type对象
        Type t2 = Type.GetType("System.Int32");

        //Type? GetType(string typeName, Func<AssemblyName, Assembly?>? assemblyResolver, Func<Assembly?, string, bool, Type?>? typeResolver, bool throwOnError, bool ignoreCase);
        //typeName 类型String
        //要获取的类型的名称。 如果提供了 typeResolver 参数，则类型名称可以为 typeResolver 能够解析的任何字符串。 assemblyResolver如果提供了参数或使用了标准类型解析，typeName则必须是程序集限定的名称(请参阅 AssemblyQualifiedName) ，除非类型位于当前正在执行的程序集或 mscorlib.dll / System.Private.CoreLib.dll 中，在这种情况下，足以提供由其命名空间限定的类型名称。

        //assemblyResolver 类型Func<AssemblyName, Assembly>
        //一个方法，它定位并返回 typeName 中指定的程序集。 以 assemblyResolver 对象形式传递给 AssemblyName 的程序集名称。 如果 typeName 不包含程序集的名称，则不调用 assemblyResolver。 如果未提供 assemblyResolver，则执行标准程序集解析。

        //警告：不要从未知或不受信任的调用方传递方法。 此操作可能会导致恶意代码特权提升。 仅使用你提供或者熟悉的方法。

        //typeResolver 类型Func<Assembly, String, Boolean, Type>
        //一个方法，它在由 typeName 或标准程序集解析返回的程序集中定位并返回 assemblyResolver 所指定的类型。 如果未提供任何程序集，则该方法可以提供一个程序集。 该方法还采用一个参数以指定是否执行不区分大小写的搜索；ignoreCase 的值传递给该参数。

        //警告：不要从未知或不受信任的调用方传递方法。

        //throwOnError 类型Boolean
        //如果为 true，则在找不到该类型时引发异常；如果为 false，则返回 null。 指定 false 还会取消某些其他异常条件，但并不取消所有条件。 请参见“异常”部分。

        //ignoreCase 类型Boolean
        //对 true 执行的搜索不区分大小写，则为 typeName；对 false 执行的搜索区分大小写，则为 typeName。
    }

    /// <summary>
    /// 输出类型信息
    /// </summary>
    /// <param name="t"></param>
    private static void ShowTypeInfo(Type t)
    {
        //public abstract Assembly Assembly { get; }  命名空间:System.Reflection
        //获取当前类型所属的程序集。
        Console.WriteLine("Type Assembly: {0}", t.Assembly.FullName);

        //public abstract string AssemblyQualifiedName { get; }  命名空间:System
        //获取当前类型在程序集中的完全限定名称,其中包括从中加载 Type 的程序集的名称。
        Console.WriteLine("Type AssemblyQualifiedName: {0}", t.AssemblyQualifiedName);

        //public abstract TypeAttributes Attributes { get; }  命名空间:System.Reflection.TypeAttributes
        //获取当前类型属性。
        Console.WriteLine("Type Attributes: {0}", t.Attributes);

        //public abstract Type BaseType { get; }  命名空间:System
        //获取当前类型基类型。
        Console.WriteLine("Type Base Type: {0}", t.BaseType);

        //public abstract bool ContainsGenericParameters { get; }  命名空间:System
        //获取当前类型是否包含泛型参数。
        Console.WriteLine("Type Contains Generic Parameters: {0}", t.ContainsGenericParameters);

        //public abstract IEnumerable<CustomAttributeData> CustomAttributes { get; }  命名空间:System.Reflection
        //获取当前类型自定义特性。
        Console.WriteLine("Type Custom Attributes: {0}", t.CustomAttributes);

        //public abstract MethodBase DeclaringMethod { get; }  命名空间:System.Reflection
        //获取当前类型声明的方法。
        //Console.WriteLine("Type Declaring Method: {0}", t.DeclaringMethod);
        //https://learn.microsoft.com/zh-cn/dotnet/api/system.type.declaringmethod?view=net-8.0#system-type-declaringmethod

        //public abstract Type DeclaringType { get; }  命名空间:System
        //获取当前类型声明的类型。
        Console.WriteLine("Type Declaring Type: {0}", t.DeclaringType);

        //public abstract Binder DefaultBinder { get; }  命名空间:System.Reflection
        //获取默认绑定器。
        //Console.WriteLine("Type Default Binder: {0}", t.DefaultBinder);
        //https://learn.microsoft.com/zh-cn/dotnet/api/system.type.defaultbinder?view=net-8.0#system-type-defaultbinder

        //public abstract string FullName { get; }  命名空间:System
        //获取当前类型完全限定名称。
        Console.WriteLine("Type Full Name: {0}", t.FullName);

        //public abstract GenericParameterAttributes GenericParameterAttributes { get; }  命名空间:System.Reflection
        //获取当前泛型参数的属性。
        //Console.WriteLine("Type Generic Parameter Attributes: {0}", t.GenericParameterAttributes);
        //https://learn.microsoft.com/zh-cn/dotnet/api/system.type.genericparameterattributes?view=net-8.0#system-type-genericparameterattributes

        //public abstract int GenericParameterPosition { get; }  命名空间:System
        //获取当前泛型参数的位置。
        //Console.WriteLine("Type Generic Parameter Position: {0}", t.GenericParameterPosition);
        //https://learn.microsoft.com/zh-cn/dotnet/api/system.type.genericparameterposition?view=net-8.0#system-type-genericparameterposition

        //public abstract Type[] GenericTypeArguments { get; }  命名空间:System
        //获取当前泛型类型参数的类型数组。
        //Console.WriteLine("Type Generic Type Arguments: {0}", t.GenericTypeArguments);
        //https://learn.microsoft.com/zh-cn/dotnet/api/system.type.generictypearguments?view=net-8.0#system-type-generictypearguments

        //public abstract Guid GUID { get; }  命名空间:System
        //获取当前类型全局唯一标识符。
        Console.WriteLine("Type GUID: {0}", t.GUID);

        //public abstract bool HasElementType { get; }  命名空间:System
        //获取当前类型是否有元素类型。
        Console.WriteLine("Type Has Element Type: {0}", t.HasElementType);

        //public abstract bool IsAbstract { get; }  命名空间:System
        //获取当前类型是否为抽象类型。
        Console.WriteLine("Type Is Abstract: {0}", t.IsAbstract);

        //public abstract bool IsAnsiClass { get; }  命名空间:System
        //获取当前类型是否为 ANSI 类。
        Console.WriteLine("Type Is ANSI Class: {0}", t.IsAnsiClass);

        //public abstract bool IsArray { get; }  命名空间:System
        //获取当前类型是否为数组类型。
        Console.WriteLine("Type Is Array: {0}", t.IsArray);

        //public abstract bool IsAutoClass { get; }  命名空间:System
        //获取当前类型是否为自动类。
        Console.WriteLine("Type Is Auto Class: {0}", t.IsAutoClass);

        //public abstract bool IsAutoLayout { get; }  命名空间:System
        //获取当前类型是否为自动布局。
        Console.WriteLine("Type Is Auto Layout: {0}", t.IsAutoLayout);

        //public abstract bool IsByRef { get; }  命名空间:System
        //获取当前类型是否为引用类型。
        Console.WriteLine("Type Is By Ref: {0}", t.IsByRef);

        //public abstract bool IsByRefLike { get; }  命名空间:System
        //获取当前类型是否为引用类型。
        Console.WriteLine("Type Is By Ref Like: {0}", t.IsByRefLike);

        //public abstract bool IsClass { get; }  命名空间:System
        //获取当前类型是否为类类型。
        Console.WriteLine("Type Is Class: {0}", t.IsClass);

        //public abstract bool IsCollectible { get; }  命名空间:System
        //获取当前类型是否可回收。
        Console.WriteLine("Type Is Collectible: {0}", t.IsCollectible);

        //public abstract bool IsCOMObject { get; }  命名空间:System
        //获取当前类型是否为 COM 对象。
        Console.WriteLine("Type Is COM Object: {0}", t.IsCOMObject);

        //public abstract bool IsConstructedGenericType { get; }  命名空间:System
        //获取当前类型是否为构造的泛型类型。
        Console.WriteLine("Type Is Constructed Generic Type: {0}", t.IsConstructedGenericType);

        //public abstract bool IsContextful { get; }  命名空间:System
        //获取当前类型是否为上下文类型。
        Console.WriteLine("Type Is Contextful: {0}", t.IsContextful);

        //public abstract bool IsEnum { get; }  命名空间:System
        //获取当前类型是否为枚举类型。
        Console.WriteLine("Type Is Enum: {0}", t.IsEnum);

        //public abstract bool IsExplicitLayout { get; }  命名空间:System
        //获取当前类型是否为显式布局。
        Console.WriteLine("Type Is Explicit Layout: {0}", t.IsExplicitLayout);

        //public abstract bool IsFunctionPointer { get; }  命名空间:System
        //获取当前类型是否为函数指针类型。
        Console.WriteLine("Type Is Function Pointer: {0}", t.IsFunctionPointer);

        //public abstract bool IsGenericMethodParameter { get; }  命名空间:System
        //获取当前类型是否为泛型方法参数。
        Console.WriteLine("Type Is Generic Method Parameter: {0}", t.IsGenericMethodParameter);

        //public abstract bool IsGenericParameter { get; }  命名空间:System
        //获取当前类型是否为泛型参数。
        Console.WriteLine("Type Is Generic Parameter: {0}", t.IsGenericParameter);

        //public abstract bool IsGenericType { get; }  命名空间:System
        //获取当前类型是否为泛型类型。
        Console.WriteLine("Type Is Generic Type: {0}", t.IsGenericType);

        //public abstract bool IsGenericTypeDefinition { get; }  命名空间:System
        //获取当前类型是否为泛型类型定义。
        Console.WriteLine("Type Is Generic Type Definition: {0}", t.IsGenericTypeDefinition);

        //public abstract bool IsGenericTypeParameter { get; }  命名空间:System
        //获取当前类型是否为泛型类型参数。
        Console.WriteLine("Type Is Generic Type Parameter: {0}", t.IsGenericTypeParameter);

        //public abstract bool IsImport { get; }  命名空间:System
        //获取当前类型是否为导入类型。
        Console.WriteLine("Type Is Import: {0}", t.IsImport);

        //public abstract bool IsInterface { get; }  命名空间:System
        //获取当前类型是否为接口类型。
        Console.WriteLine("Type Is Interface: {0}", t.IsInterface);

        //public abstract bool IsLayoutSequential { get; }  命名空间:System
        //获取当前类型是否为顺序布局。
        Console.WriteLine("Type Is Layout Sequential: {0}", t.IsLayoutSequential);

        //public abstract bool IsMarshalByRef { get; }  命名空间:System
        //获取当前类型是否为 Marshal-by-reference 类型。
        Console.WriteLine("Type Is Marshal By Ref: {0}", t.IsMarshalByRef);

        //public abstract bool IsNested { get; }  命名空间:System
        //获取当前类型是否为嵌套类型。
        Console.WriteLine("Type Is Nested: {0}", t.IsNested);

        //public abstract bool IsNestedAssembly { get; }  命名空间:System
        //获取当前类型是否为嵌套程序集类型。
        Console.WriteLine("Type Is Nested Assembly: {0}", t.IsNestedAssembly);

        //public abstract bool IsNestedFamANDAssem { get; }  命名空间:System
        //获取当前类型是否为嵌套和封闭的程序集类型。
        Console.WriteLine("Type Is Nested Fam AND Assem: {0}", t.IsNestedFamANDAssem);

        //public abstract bool IsNestedFamily { get; }  命名空间:System
        //获取当前类型是否为嵌套的家族类型。
        Console.WriteLine("Type Is Nested Family: {0}", t.IsNestedFamily);

        //public abstract bool IsNestedFamORAssem { get; }  命名空间:System
        //获取当前类型是否为嵌套或封闭的程序集类型。
        Console.WriteLine("Type Is Nested Fam OR Assem: {0}", t.IsNestedFamORAssem);

        //public abstract bool IsNestedPrivate { get; }  命名空间:System
        //获取当前类型是否为嵌套私有类型。
        Console.WriteLine("Type Is Nested Private: {0}", t.IsNestedPrivate);

        //public abstract bool IsNestedPublic { get; }  命名空间:System
        //获取当前类型是否为嵌套公共类型。
        Console.WriteLine("Type Is Nested Public: {0}", t.IsNestedPublic);

        //public abstract bool IsNotPublic { get; }  命名空间:System
        //获取当前类型是否为非公共类型。
        Console.WriteLine("Type Is Not Public: {0}", t.IsNotPublic);

        //public abstract bool IsPointer { get; }  命名空间:System
        //获取当前类型是否为指针类型。
        Console.WriteLine("Type Is Pointer: {0}", t.IsPointer);

        //public abstract bool IsPrimitive { get; }  命名空间:System
        //获取当前类型是否为原始类型。
        Console.WriteLine("Type Is Primitive: {0}", t.IsPrimitive);

        //public abstract bool IsPublic { get; }  命名空间:System
        //获取当前类型是否为公共类型。
        Console.WriteLine("Type Is Public: {0}", t.IsPublic);

        //public abstract bool IsSealed { get; }  命名空间:System
        //获取当前类型是否为密封类型。
        Console.WriteLine("Type Is Sealed: {0}", t.IsSealed);

        //public abstract bool IsSecurityCritical { get; }  命名空间:System
        //获取当前类型是否为安全关键类型。
        Console.WriteLine("Type Is Security Critical: {0}", t.IsSecurityCritical);

        //public abstract bool IsSecuritySafeCritical { get; }  命名空间:System
        //获取当前类型是否为安全安全关键类型。
        Console.WriteLine("Type Is Security Safe Critical: {0}", t.IsSecuritySafeCritical);

        //public abstract bool IsSecurityTransparent { get; }  命名空间:System
        //获取当前类型是否为安全透明类型。
        Console.WriteLine("Type Is Security Transparent: {0}", t.IsSecurityTransparent);

        //public abstract bool IsSerializable { get; }  命名空间:System
        //获取当前类型是否为可序列化类型。
        Console.WriteLine("Type Is Serializable: {0}", t.IsSerializable);

        //public abstract bool IsSignatureType { get; }  命名空间:System
        //获取当前类型是否为签名类型。
        Console.WriteLine("Type Is Signature Type: {0}", t.IsSignatureType);

        //public abstract bool IsSpecialName { get; }  命名空间:System
        //获取当前类型是否为特殊名称类型。
        Console.WriteLine("Type Is Special Name: {0}", t.IsSpecialName);

        //public abstract bool IsSZArray { get; }  命名空间:System
        //获取当前类型是否为单维数组类型。
        Console.WriteLine("Type Is SZ Array: {0}", t.IsSZArray);

        //public abstract bool IsTypeDefinition { get; }  命名空间:System
        //获取当前类型是否为类型定义。
        Console.WriteLine("Type Is Type Definition: {0}", t.IsTypeDefinition);

        //public abstract bool IsUnicodeClass { get; }  命名空间:System
        //获取当前类型是否为 Unicode 类。
        Console.WriteLine("Type Is Unicode Class: {0}", t.IsUnicodeClass);

        //public abstract bool IsUnmanagedFunctionPointer { get; }  命名空间:System
        //获取当前类型是否为非托管函数指针类型。
        Console.WriteLine("Type Is Unmanaged Function Pointer: {0}", t.IsUnmanagedFunctionPointer);

        //public abstract bool IsValueType { get; }  命名空间:System
        //获取当前类型是否为值类型。
        Console.WriteLine("Type Is Value Type: {0}", t.IsValueType);

        //public abstract bool IsVariableBoundArray { get; }  命名空间:System
        //获取当前类型是否为可变绑定数组类型。
        Console.WriteLine("Type Is Variable Bound Array: {0}", t.IsVariableBoundArray);

        //public abstract bool IsVisible { get; }  命名空间:System
        //获取当前类型是否为可见类型。
        Console.WriteLine("Type Is Visible: {0}", t.IsVisible);

        //public abstract MemberTypes MemberType { get; }  命名空间:System.Reflection
        //获取当前类型成员类型。
        Console.WriteLine("Type Member Type: {0}", t.MemberType);

        //public abstract int MetadataToken { get; }  命名空间:System
        //获取当前类型元数据标记。
        Console.WriteLine("Type Metadata Token: {0}", t.MetadataToken);

        //public abstract Module Module { get; }  命名空间:System.Reflection
        //获取当前类型所属的模块。
        Console.WriteLine("Type Module: {0}", t.Module);

        //public abstract string Name { get; }  命名空间:System
        //获取当前类型名称。
        Console.WriteLine("Type Name: {0}", t.Name);

        //public abstract string Namespace { get; }  命名空间:System
        //获取当前类型命名空间。
        Console.WriteLine("Type Namespace: {0}", t.Namespace);

        //public abstract Type ReflectedType { get; }  命名空间:System
        //获取当前类型反射类型。
        Console.WriteLine("Type Reflected Type: {0}", t.ReflectedType);

        //public abstract StructLayoutAttribute StructLayoutAttribute { get; }  命名空间:System.Runtime.InteropServices
        //获取当前类型结构布局属性。
        Console.WriteLine("Type Struct Layout Attribute: {0}", t.StructLayoutAttribute);

        //public abstract RuntimeTypeHandle TypeHandle { get; }  命名空间:System
        //获取当前类型运行时类型句柄。
        Console.WriteLine("Type Type Handle: {0}", t.TypeHandle);

        //public abstract ConstructorInfo TypeInitializer { get; }  命名空间:System.Reflection
        //获取当前类型类型初始化器。
        Console.WriteLine("Type Type Initializer: {0}", t.TypeInitializer);

        //public abstract Type UnderlyingSystemType { get; }  命名空间:System
        //获取当前类型底层系统类型。
        Console.WriteLine("Type Underlying System Type: {0}", t.UnderlyingSystemType);
    }
}