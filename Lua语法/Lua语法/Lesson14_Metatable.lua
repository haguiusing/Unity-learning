print("**********元表************")
print("**********元表概念************")
--任何表变量都可以作为另一个表变量的元表
--任何表变量都可以有自己的元表（爸爸）
--当我们子表中进行一些特定操作时
--会执行元表中的内容
print("**********设置元表************")
myTable = {}   -- 普通表
meta = {} -- 元表
--设置元表函数
--第一个参数 子表/普通表（爸爸）
--第二个参数 元表
setmetatable(myTable, meta)  -- 把 meta 设为 mytable 的元表

--以上代码也可以直接写成一行：
--第一个{} 子表/普通表（爸爸）
--第二个{} 元表
mytable = setmetatable({},{})

--返回对象元表
--如果对象没有一个元表，则函数返回nil，
--否则函数会查询原表中是否有"__metatable"字段，
--如果有返回其关联值，如果没有则会返回所给对象的元表
print(getmetatable(myTable))  --table: 009F10A0
print(getmetatable(meta))  --nil
print(myTable)  --table: 00E70E50
print(meta)  --table: 009F10A0

print("**********特定操作************")
print("**********特定操作-__tostring************")
meta2 = {
	--当子表要被当做字符串使用时 会默认调用这个元表中的tostring方法
	__tostring = function(t)  --=__tostring = function(myTable)
		return t.name
	end
}
myTable2 = {
	name = "唐老狮2"
}
--设置元表函数
--第一个参数 子表
--第二个参数 元表（爸爸）
setmetatable(myTable2, meta2)

print(myTable2)  --唐老狮2

mytable = setmetatable({ 10, 20, 30 }, {
  __tostring = function(mytable)
    sum = 0
    for k, v in pairs(mytable) do
                sum = sum + v
        end
    return "表所有元素的和为 " .. sum
  end
})
print(mytable)  --表所有元素的和为 60

print("**********特定操作-__call************")
meta3 = {
	--当子表要被当做字符串使用时 会默认调用这个元表中的tostring方法
	__tostring = function(t)
		return t.name
	end,
	--当子表被当做一个函数来使用时 会默认调用这个__call中的内容
	--当希望传参数时 一定要记住 默认第一个参数 是调用者自己
	__call = function(a, b)
		print(a)  --"唐老狮2"  __tostring方法
		print(b)  --1  传入值
		print("唐老狮好爱你")  --唐老狮好爱你
	end
}
myTable3 = {
	name = "唐老狮2"
}
--设置元表函数
--第一个参数 子表（爸爸）
--第二个参数 元表
setmetatable(myTable3, meta3)
--把子表当做函数使用 就会调用元表的 __call方法
myTable3(1)
myTable3(myTable3,1)  --会调用两次'myTable3'，而'1'被忽略
--唐老狮好爱你
--唐老狮好爱你

print("**********特定操作-运算符重载************")
meta4 = {
	--相当于运算符重载 当子表使用+运算符时 会调用该方法
	--运算符+
	__add = function(t1, t2)
		return '加法：' .. t1.age + t2.age
	end,

	--运算符-
	__sub = function(t1, t2)
		return '减法：' .. t1.age - t2.age
	end,

	--运算符*
	__mul = function(t1, t2)
		return '乘法：' .. t1.age * t2.age
	end,

	--运算符/
	__div = function(t1, t2)
		return '除法：' .. t1.age / t2.age
	end,

	--运算符%
	__mod = function(t1, t2)
		return '取余：' .. t1.age % t2.age
	end,

	--运算符^
	__pow = function(t1, t2)
		return '幂运算：' .. t1.age ^ t2.age
	end,

	--运算符==
	__eq = function(t1, t2)
		return t1.age == t2.age
	end,

	--运算符<
	__lt = function(t1, t2)
		return t1.age < t2.age
	end,

	--运算符<=
	__le = function(t1, t2)
		return t1.age <= t2.age
	end,

	--运算符..
	__concat = function(t1, t2)
		return '..运算：' .. t1.age .. t2.age
	end

	--运算符- 正负取反、无效
	--__unm = function (t1)
	--	local x = -t1
	--	return x
	--end
}

myTable4 = {age = 1}
setmetatable(myTable4, meta4)
myTable5 = {age = 2}
setmetatable(myTable5, meta4)

print("**普通运算符**")
print(myTable4 + myTable5)--加法：3
print(myTable4 - myTable5)--减法：-1
print(myTable4 * myTable5)--乘法：2
print(myTable4 / myTable5)--除法：0.5
print(myTable4 % myTable5)--取余：1
print(myTable4 ^ myTable5)--幂运算：1

print("**条件运算符**")
--如果要用条件运算符 来比较两个对象
--这两个对象的元表一定要一致 才能准确调用方法
print(myTable4 == myTable5)--false
print(myTable4 < myTable5)--true
print(myTable4 > myTable5)--false
print(myTable4 <= myTable5)--true

print(myTable4 .. myTable5)--.运算：12
--local result = -t
--print(result.value)
local t = {value = 10}
local mt = {
    __unm = function(op)
        return {value = -op.value}---10  '取反运算：' ..
    end
}

setmetatable(t, mt)

local result = -t
print(result.value)  -- 输出: -10

print("**********特定操作-__index和__newIndex************")
print("**********__index************")
--当你通过键来访问 table 的时候，如果这个键没有值，
--那么Lua就会寻找该table的metatable（假定有metatable）中的__index 键。
print("**********__index包含一个表格************")
meta6Father = {
	age = 1
}
meta6Father.__index = meta6Father

meta6 = {
	--age = 1
	__index = {sex = 2}
}
--__index的赋值 写在表外面来初始化
meta6.__index = meta6
--一个table，无论在表内还是表外申明__index
--只执行最后申明的__index
--meta6.__index = {sex = 2} 
--meta6.__index = meta6

myTable6 = {}
setmetatable(meta6, meta6Father)
setmetatable(myTable6, meta6)
--得到元表的方法
print(getmetatable(meta6))  --meta6Father
print(meta6Father)
print(getmetatable(myTable6))  --meta6
print(meta6)
print(myTable6)  --头

--__index 当子表中 找不到某一个属性时 
--会到元表中 __index指定的表去找属性
print(myTable6.age)  --1
print(myTable6.sex)  --nil

--rawget 当我们使用它 会去找自己身上有没有这个变量
--myTable6.age = 1
print(rawget(myTable6, "age"))  --nil
print("**********__index包含一个函数************")
--如果__index包含一个函数的话，Lua就会调用那个函数，table和键会作为参数传递给函数。

--__index 元方法查看表中元素是否存在，如果不存在，返回结果为 nil；
--如果存在则由 __index 返回结果。
mytable = setmetatable({key1 = "value1"}, {
  __index = function(mytable, key)
    if key == "key2" then
      return "metatablevalue"
    else
      return nil
    end
  end
})

print(mytable.key1,mytable.key2)--value1	metatablevalue

print("**********__newindex************")
--newIndex 当赋值时，如果赋值一个不存在的索引
--那么会把这个值赋值到newindex所指的表中 不会修改自己
meta7 = {}
meta8 = {}
meta7.__newindex = meta8
myTable7 = {}
setmetatable(myTable7, meta7)
myTable7.age = 7
print(myTable7.age)  --nil
print(meta8.age)  --7
--rawset 该方法 会忽略newindex的设置 只会该自己的变量
rawset(myTable7, "age", 2)
print(myTable7.age)   --2

--__index与查找有关
--__newIndex与申明变量有关
--两者都是先查子表，再看元表，再查元表索引

--rawget方法忽略__index
--rawset方法忽略__newindex