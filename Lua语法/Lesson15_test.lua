--封装
Object = {}
Object.id = 1

function Object:object()
	local obj = {}
	self.__index = self
	setmetatable(obj,self)
	return obj
end

Object:object()
print(Object:object())
print(Object:object().id)

--继承
function Object:getClass(father)
	_G[father] = {}
	local obj = _G[father]
	self.__index = self
	obj.base = self
	setmetatable(obj,self)
end

Object:getClass("UIObject")
UIObject:object()
print(UIObject:object().id)

--多态!!!
Object:getClass("GameObject")
GameObject.posX = 0;
GameObject.posY = 0;
function GameObject:Move()
	self.posX = self.posX + 1
	self.posY = self.posY + 1
	print('X:'.. self.posX .. ' Y:' .. self.posY)
end

local p1 = GameObject:object()
p1:Move()

GameObject:getClass("Player")
function Player:Move()
	self.base.Move(self)
end

local p1 = Player:object()
p1:Move()
p1:Move()

local p2 = Player:object()
p2:Move()