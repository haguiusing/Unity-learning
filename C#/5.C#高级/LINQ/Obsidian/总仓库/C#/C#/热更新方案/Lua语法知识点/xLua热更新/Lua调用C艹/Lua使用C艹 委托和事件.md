[Lesson7_CallDel](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Lua/xLua/Lesson7_CallDel.lua)[LuaCallCSharp](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Scripts/LuaCallCS/LuaCallCSharp.cs)

![[Pasted image 20250531141304.png]]
## 委托相关
### 加函数
如果第一次往委托中加函数，因为是nil 不能直接+，所以第一次 要先等=
Lua中没有复合运算符 不能+=
### 减函数
-
### 清空
```lua
--清空所有存储的函数
obj.del = nil
--清空过后得先等
obj.del = fun
```
### 调用
```lua
obj.del()  --直接调用
obj:DoDel()  --封装成员方法
```

## 事件相关
### 加函数
冒号事件名("+", 函数变量)
### 减函数
冒号事件名("-", 函数变量)
### 清空和调用
清事件 不能直接设空 需封装成员方法
```lua
obj:ClearEvent()
obj:DoEvent()
```
