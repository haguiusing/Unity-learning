print("**********特殊用法************")
print("**********多变量赋值************")
local a,b,c = 1,2,"123"
print(a)  --1
print(b)  --2
print(c)  --123
--多变量赋值 如果后面的值不够 会自动补空
a,b,c = 1,2 
print(a)  --1
print(b)  --2
print(c)  --nil
--多变量赋值 如果后面的值多了 会自动省略
a,b,c = 1,2,3,4,5,6
print(a)
print(b)
print(c)

print("**********多返回值************")
function Test()
	return 10,20,30,40
end
--多返回值时 你用几个变量接 就有几个值
--如果少了 就少接几个 如果多了 就自动补空
a,b,c = Test()
print(a)  --10
print(b)  --20
print(c)  --30

a,b,c,d,e = Test()
print(a)
print(b)
print(c)
print(d)
print(e)--nil

print("**********and or************")
--逻辑与 逻辑或
-- and or 他们不仅可以连接 boolean 任何东西都可以用来连接
-- 在lua中 只有 nil 和 false 才认为是假
-- "短路"——对于and来说  有假则假  对于or来说 有真则真
-- 所以 他们只需要判断 第一个 是否满足 就会停止计算了
print("**and**")
--A为真，选B；A为假，选A 
print( 1 and 2 )
print( 0 and 1)
print( nil and 1)
print( false and 2)
print( true and 3)
print("**or**")
--A为真，选A；A为假，选B 
print( true or 1 )
print( false or 1)
print( nil or 2)

--lua不支持三目运算符 
x = 1
y = 2
-- ? :
local res = (x>y) and x or y
print(res)  --2

--x=2,y=1
--(x>y) and x ——> true and x ——> x
-- x or y —— > 2 or 1 ——> x

--x=1,y=2
--(x>y) and x ——> false and x ——> (x>y)
-- (x>y) or y ——> y

local res = (x>y) and true or false
print(res)  --false

