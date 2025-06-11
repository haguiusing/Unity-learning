print("**********变量************")
--lua当中的简单变量类型
-- nil number string boolean
--lua中所有的变量申明 都不需要申明变量类型 他会自动的判断类型
--类似C# 里面的 var
--lua中的一个变量 可以随便赋值 ——自动识别类型
--通过 type 函数 返回值时string 我们可以得到变量的类型

--lua中使用没有声明过的变量 
--不会报错 默认值 是nil
print(b)

--nil 有点类似 C#中的null
print("**********nil************")
a = nil
print(a)
print(type(a))
print(type(type(a)))
--对于全局变量和 table，nil 还有一个"删除"作用，给全局变量或者 table 表里的变量赋一个 nil 值，等同于把它们删掉
--nil 作比较时应该加上双引号"：（不对）
--type(X)==nil  --报错false
--type(X)=="nil"  --报错true
if a == nil then
    print("a为空")
else
    print(a)
end

--number 所有的数值都是number
print("**********number************")
--number 类型 -- double（双精度）类型（默认类型可以修改 luaconf.h 里的定义）
a = 1
print(a)
print(type(a))
a = 1.2
print(a)
print(type(a))

print("**********string************")
--字符串的声明 使用单引号或者双引号包裹
--lua里 没有char
a = "12312"
print(a)
print(type(a))
a = '123'
print(a)
print(type(a))

--也可以用 2 个方括号 "[[]]" 来表示"一块"字符串。
html = [[
<html>
<head></head>
<body>
    <a href="http://www.runoob.com/">菜鸟教程</a>
</body>
</html>
]]
print(html)

--在对一个数字字符串上进行算术操作时，Lua 会尝试将这个数字字符串转成一个数字:
print("2" + 6)

--使用 # 来计算字符串的长度，放在字符串前面
len = "www.runoob.com"
print(#len)
print(#"www.runoob.com")

print("**********boolean************")
a = true
print(a)
a = false
print(a)
print(type(a))

--Lua 把 false 和 nil 看作是 false，其他的都为 true，数字 0 也是 true:
if false or nil then
    print("至少有一个是 true")
else
    print("false 和 nil 都为 false")
end

if 0 then
    print("数字 0 是 true")
else
    print("数字 0 为 false")
end

--复杂数据类型
--函数 function
--表 table
--数据结构 userdata
--协同程序 thread(线程)
