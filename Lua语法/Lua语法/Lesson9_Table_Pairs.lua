print("**********迭代器遍历************")
--迭代器遍历 主要是用来遍历表的
--#得到长度 其实并不准确 一般不要用#来遍历表

a = {[0] = 1, 2, [-1]=3, 4, 5, [5] = 6}

array = {"Google", "Runoob", "Runoob"}
array["Runoob"] = 1

--泛型 for 迭代器
--泛型 for 在自己内部保存迭代函数，实际上它保存三个值：迭代函数、状态常量、控制变量。
print("**********ipairs迭代器遍历************")
--ipairs
--ipairs遍历 只会从1开始，步进1，只能遍历数组部分 往后遍历的 小于等于0的值得不到
--只能找到连续索引的 键 如果中间断序了 它也无法遍历出后面的内容
for i,k in ipairs(a) do
	print("ipairs遍历键值"..i.."_"..k)  --2 4 5
end

for key,value in ipairs(array) 
do
   print(key, value)
end
--1	Google
--2	Runoob
--3	Runoob

print("**********ipairs迭代器遍历键************")
for i in ipairs(a) do
	print("ipairs遍历键"..i)  --1 2 3
end

print("**********pairs迭代器遍历************")
--它能够把所有的键都找到 通过键可以得到值
for i,v in pairs(a) do
	print("pairs遍历键值"..i.."_"..v)  --1_2  2_4  3_5 0_1 -1_3 5_6
end

for key,value in pairs(array) 
do
   print(key, value)
end
--1	Google
--2	Runoob
--3	Runoob
--Runoob	1

print("**********pairs迭代器遍历键************")
for i in pairs(a) do
	print("pairs遍历键"..i)
end

--无状态的迭代器
--无状态的迭代器是指不保留任何状态的迭代器，因此在循环中我们可以利用无状态迭代器避免创建闭包花费额外的代价。
--每一次迭代，迭代函数都是用两个变量（状态常量和控制变量）的值作为参数被调用，一个无状态的迭代器只利用这两个值可以获取下一个元素。
--这种无状态迭代器的典型的简单的例子是 ipairs，它遍历数组的每一个元素，元素的索引需要是数值。

--多状态的迭代器
--很多情况下，迭代器需要保存多个状态信息而不是简单的状态常量和控制变量，最简单的方法是使用闭包，
--还有一种方法就是将所有的状态信息封装到 table 内，将 table 作为迭代器的状态常量，
--因为这种情况下可以将所有的信息存放在 table 内，所以迭代函数通常不需要第二个参数。
