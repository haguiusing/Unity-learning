print("**********多脚本执行************")
print("**********全局变量和本地变量************")
--全局变量
a = 1
b = "123"

--Lua允许在循环中申明变量
for i = 1,2 do
	c = "唐老狮"
end
print(c)  --唐老狮

--本地（局部）变量的关键字 local
for i = 1,2 do  --循环两次
	local d = "唐老狮"
	print("循环中的d"..d)  --循环中的d唐老狮
end
print(d)  --nil

fun = function()
	local tt = "123123123"
end
fun()
print(tt)  --nil
local tt2 = "555"
print(tt2)  --555

print("**********多脚本执行************")
--关键字 require("脚本名")
require('Test')  --Test测试  456
print(testA)  --123
print(testLocalA)  --nil
  
print("**********脚本卸载************")
--如果是require加载执行的脚本 加载一次过后不会再被执行
require("Test")  --不执行
--package.loaded["脚本名"]
--返回值是boolean 意思是 该脚本是否被执行
print(package.loaded["Test"])  --456
--卸载已经执行过的脚本
package.loaded["Test"] = nil
print(package.loaded["Test"])  --nil

--require 执行一个脚本时  可以在脚本最后返回一个外部希望获取的内容
local testLA = require("Test")  --Test测试  456
print('返回一个外部希望获取的内容 ' .. testLA)  --返回一个外部希望获取的内容 456

print("**********大G表************")
--_G表是一个总表(table) 他将我们申明的所有全局的变量都存储在其中
for k,v in pairs(_G) do
	print(k,v)
end
--本地变量 加了local的变量时不会存到大_G表中