[Lesson6_CallFunction](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Lua/xLua/Lesson6_CallFunction.lua)
[LuaCallCSharp](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Scripts/LuaCallCS/LuaCallCSharp.cs)

![[Pasted image 20250531135228.png]]

1. **获取类型**： 使用 `typeof` 函数获取 C# 类的 `System.Type` 对象。
    ```lua
    local lesson6Type = typeof(CS.Lesson6)
    ```
    
2. **获取方法**： 使用 `GetMethod` 函数获取指定的重载方法。需要提供方法名和参数类型数组。
    ```lua
    local m1 = lesson6Type:GetMethod("Calc", {typeof(CS.System.Int32)})
    local m2 = lesson6Type:GetMethod("Calc", {typeof(CS.System.Single)})
    ```
    
3. **转换为 Lua 函数**： 使用 `xlua.tofunction` 将获取到的方法转换为 Lua 函数。这样可以在 Lua 中直接调用这些方法。
    ```lua
    local f1 = xlua.tofunction(m1)
    local f2 = xlua.tofunction(m2)
    ```
    
4. **调用 Lua 函数**： 调用转换后的 Lua 函数，并传入相应的参数。对于实例方法，第一个参数需要传入对象实例。
    ```lua
    --成员方法 第一个参数传对象
	--静态方法 不用传对象
    print(f1(obj, 10))    -- 调用 int 重载版本
    print(f2(obj, 10.2))  -- 调用 float 重载版本
    ```