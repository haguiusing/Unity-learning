print("**********复杂数据类型 talbe************")
--所有的复杂类型都是table（表）
--最简单构造表达式是{}，用来创建一个空表。也可以在表里添加一些数据，直接初始化表
--Lua 中的表（table）其实是一个"关联数组"（associative arrays），数组的索引可以是数字或者是字符串。
a = {}  --空表
a["key"] = "value"
key = 10
a[key] = 22
a[key] = a[key] + 11
for k, v in pairs(a) do
    print(k .. " : " .. v)
end
--key : value
--10 : 33

print("**********数组************")
a = {1,2,nil,3,"1231",true,nil}
--lua中 索引从1开始
print(a[1])  --1
print(a[5])  --1231
print(a[6])  --true
print(a[7])  --nil
--#是通用的获取长度的关键字
--在打印长度的时候 空被忽略
--如果表中（数组中）某一位变成nil 会影响#获取的长度
print(#a)  --2
print(table.getn(a))  --2
print(table.maxn(a))  --6
--指定table中所有正数key值中最大的key值. 如果不存在key值为正数的元素, 则返回0。

print("**********数组的遍历************")
--nil会影响#获取的长度
for i=1,#a do
	print(a[i]) --1 2
end

print("**********二维数组************")
a={{1,2,3},{4,5,6}}
print(a[1][1])  --1
print(a[1][2])  --2
print(a[1][3])  --3
print(a[2][1])  --4
print(a[2][2])  --5
print(a[2][3])  --6

print("**********二维数组的遍历************")
for i=1,#a do
	b=a[i]
	for j=1,#b do
		print(b[j])
	end
end

print("**********自定义索引************")
aa={[0]=1,2,3,[-1]=4,5}
print(aa[0])  --1
print(aa[-1])  --4
print(aa[1])  --2
print(aa[2])  --3
print(aa[3])  --5
print("aa:"..#aa)  --3,默认从索引1开始

print("-中间断1个数-")
bb={[1]=1,[2]=2,[4]=4,[6]=6}
for i=1,#bb do
	print(bb[i])  --1 2 nil 4 nil 6
end
print("bb:"..#bb)  --bb:6

print("-中间断2个数-")  --就获取不到了
bb={[1]=1,[2]=2,[5]=5,[6]=6}
for i=1,#bb do
	print(bb[i])  --1 2
end
print("bb:"..#bb)  --bb:2

print("**********数组元素的添加、删除、修改、重置************")
print"--添加--"
--添加nil会影响#
bb[#bb+1]=7
bb[#bb+1]=8
bb[#bb+2]=10

for i=1,#bb do
	print(bb[i]) --1 2 7 8 5 6 nil 10
end
print("bb:"..#bb)  --bb:8

print"--修改--"
bb[3]=3
bb[8]=nil

for i=1,#bb do
	print(bb[i]) --1 2 3 8 5 6
end
print("bb:"..#bb)  --bb:6

print"--重置--"
 --自定义索引和不自定义混用会导致#cc获取不到nil后面的数
cc={1,2,[4]=4,[5]=5,[7]=7,[8]=8}
for i=1,#cc do
	print(cc[i])  -- 1 2
end
print("cc:"..#cc)  --cc:2

cc={[1]=1,[2]=2,[4]=4,[5]=5,[7]=7,[8]=8,[10]=10,[12]=12}  --正确写法1
--cc={1,2,nil,4,5,nil,7,8}  --正确写法2
for i=1,#cc do
	print(cc[i])  --1,2,nil,4,5,nil,7,8,nil,10,nil,12
end
print("cc:"..#cc)  --cc:12

print"--删除--"
--在被删除的数组元素之前的nil，不会影响#bb
--在被删除的数组元素之后的nil，
--删除非空，会
table.remove( cc, 5 )  --删除
for i=1,#cc do
	print(cc[i])  --1,2,nil,4,5,nil,7,8
end
print("cc:"..#cc)  --cc:7
print(cc[7])  --8

dd={[a] = a,[b] = b}
table.remove(dd)  --没法删除
--for i,v in pairs(dd) do
--	print(i .. "_" .. k)
--end

a = { x = 1, y = { z = 2 } }
b = a
print("a.x=" .. a.x  .. " _ " .. "b.x=".. b.x)--a.x=1 _ b.x=1
print("a.y.z=" .. a.y.z  .. " _ " .."b.y.z=" .. b.y.z)--y.z=2 _ b.y.z=2

--浅拷贝
b.x = 5
b.y.z = 6
print("a.x=" .. a.x  .. " _ " .. "b.x=" ..b.x)--a.y.z=6 _ b.y.z=6
print("a.y.z=" .. a.y.z  .. " _ " .. "b.y.z=" .. b.y.z)--a.y.z=6 _ b.y.z=6

b = { x = 3, y = { z = 4 } }  --{}会新建独立的表
print("a.x=".. a.x  .. "_" .. "b.x="..b.x)--a.x=5_b.x=3
print("a.y.z=" .. a.y.z  .. " _ " .. "b.y.z=" .. b.y.z)--a.y.z=6 _ b.y.z=4

fruits = {"banana","orange","apple"}
-- 返回 table 连接后的字符串
print("连接后的字符串 ",table.concat(fruits))  --bananaorangeapple
-- 指定连接字符
print("连接后的字符串 ",table.concat(fruits,", "))  --banana, orange, apple
-- 指定索引来连接 table
print("连接后的字符串 ",table.concat(fruits,", ", 2,3))  --orange, apple

print(table.maxn(cc)) --11


local people = {
    {name = "Alice", age = 25},
    {name = "Bob", age = 30},
    {name = "Charlie", age = 20}
}

-- 自定义比较函数：按 age 降序排序
table.sort(people, function(a, b)
    return a.age > b.age
end)

for i, person in ipairs(people) do
    print(i, person.name, person.age)
end