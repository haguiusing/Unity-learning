print("**********面向对象************")
print("**********封装************")
--面向对象 类 其实都是基于 table来实现
--元表相关的知识点
-- 基类Object 定义一个"类"（实际上是一个表）和一个属性id
Object = {}
Object.id = 1

function Object:Test()
	print(self.id)
end

-- 添加封装：隐藏属性
--冒号 是会自动将调用这个函数的对象 作为第一个参数传入的写法
function Object:new()
	--self 代表的是 我们默认传入的第一个参数
	--对象就是变量 返回一个新的变量
	--返回出去的内容 本质上就是表对象
	local obj = {}
	--元表知识 __index 当找自己的变量 找不到时 就会去找元表当中__index指向的内容
	self.__index = self
	setmetatable(obj, self)
	obj.name = name
    obj.age = age
	return obj
end

function Object:setName(name)
    self.name = name  -- 提供方法来修改 name
end

function Object:getName()
    return self.name  -- 提供方法来获取 name
end

local myObj = Object:new()
print(myObj) --table: 00BA9B18 
--调用Object:new()，self为Object，myObj = 返回值obj 即以Object为元表的obj表
print(myObj.id)  --1
myObj:Test()  --1
--对空表中 local obj = {} 申明一个新的属性 叫做id
myObj.id = 2  
print(myObj.id)  --2 存在myObj中
print(Object.id)  --1
myObj:Test()  --2 传入myObj

myObj:setName("名字1")
myObj.name = "名字2"
print(myObj.name)  --名字2
print(myObj.getName)  --function: 00A2C028
print(myObj:getName())    --名字2

print("**********继承************")
--C# class 类名 : 继承类
--写一个用于继承的方法 Object为基类
function Object:subClass(className)
	-- _G知识点 是总表 所有声明的全局标量 都以键值对的形式存在其中
	-- 在全局表 _G 中创建一个新类
	_G[className] = {}
	local obj = _G[className]
	--写相关继承的规则
	--用到元表

	--设置元表的 __index 为当前类，以便子类可以访问父类的方法和属性
	self.__index = self
	--子类 定义个base属性 base属性代表父类
	obj.base = self
	-- 设置子类的元表为父类
	setmetatable(obj, self)
end
--print(_G)
--_G["a"] = 1
--_G.b = "123"
--print(a)
--print(b)

Object:subClass("Person")  --子类 Person

local p1 = Person:new()
print(p1.id)  -- 输出 1（继承自 Object）
p1.id = 100
print(p1.id)  -- 输出 100（覆盖了继承的 id）
p1:Test()     -- 输出 100（调用父类的 Test 方法）

Object:subClass("Monster")  --子类 Monster
local m1 = Monster:new()
print(m1.id)  -- 输出 1（继承自 Object）
m1.id = 200
print(m1.id)  -- 输出 200（覆盖了继承的 id）
m1:Test()     -- 输出 200（调用父类的 Test 方法）

print("**********多态************")
--相同行为 不同表象 就是多态
--相同方法 不同执行逻辑 就是多态
Object:subClass("GameObject")
GameObject.posX = 0;
GameObject.posY = 0;
function GameObject:Move()
	self.posX = self.posX + 1
	self.posY = self.posY + 1
	print(self.posX .." ".. self.posY)
	--print("GameObject")
end

GameObject:subClass("Player")
function Player:Move()
	print("Player")

	--base 指的是 GameObject 表（类）
	--这种方式调用 相当于是把基类表 作为第一个参数传入了方法中
	--避免把基类表 传入到方法中 这样相当于就是公用一张表的属性了
	--self.base:Move()
	--我们如果要执行父类逻辑 我们不要直接使用冒号调用
	--要通过.调用 然后自己传入第一个参数 
	self.base.Move(self)
end

local p1 = Player:new()
p1:Move()  --1  1
p1:Move()  --2  2
--目前这种写法 有坑 不同对象使用的成员变量 居然是相同的成员变量
--不是自己的
local p2 = Player:new()
p2:Move()  --1  1

