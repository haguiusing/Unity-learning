[Lesson5_CallFunction](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Lua/xLua/Lesson5_CallFunction.lua)
[LuaCallCSharp](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Scripts/LuaCallCS/LuaCallCSharp.cs)

![[Pasted image 20250531134306.png]]

ref参数 
- C#需要传入一个已经初始化的变量
- Lua需要传入一个默认值 占位置

out参数 
- C#需要传入一个变量
- Lua不需要传占位置的值

混合使用时  综合上面的规则
ref需占位 out不用传