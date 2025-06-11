print("**********协同程序************")
--thread（线程）
--在 Lua 里，最主要的线程是协同程序（coroutine）。
--它跟线程（thread）差不多，拥有自己独立的栈、局部变量和指令指针，
--可以跟其他协同程序共享全局变量和其他大部分东西。

--线程跟协程的区别：
--线程可以同时多个运行，而协程任意时刻只能运行一个，并且处于运行状态的协程只有被挂起（suspend）时才会暂停。

print("**********协程的创建************")
--常用方式
--coroutine.create()
--创建 coroutine，返回 coroutine， 参数是一个函数，当和 resume 配合使用的时候就唤醒函数调用
fun = function()
	print(123)
end
co = coroutine.create(fun) --写法1
--co = coroutine.create(function() --写法2
--	print(123)
--end)

--协程的本质是一个线程对象
print(co)
print(type(co)) --thread

--coroutine.wrap()
--创建 coroutine，返回一个函数，一旦你调用这个函数，就进入 coroutine，和 create 功能重复
co2 = coroutine.wrap(fun)
print(co2)
print(type(co2)) --function

--coroutine.create()	
--  创建coroutine，返回coroutine，
--  参数是一个函数，当和resume配合使用的时候就唤醒函数调用
--coroutine.wrap()
--	创建coroutine，返回一个函数，一旦你调用这个函数，就进入coroutine，
--  和create功能重复时候就唤醒函数调用

print("**********协程的运行************")
--第一种方式 对应的 是通过 create创建的协程
coroutine.resume(co)
--第二种方式 对应的 是通过 wrap创建的协程
co2()

print("**********协程的挂起************")
fun2 = function()
	local i = 1
	while true do
		print(i)
		i = i + 1
		--协程的挂起函数
		print(coroutine.status(co3))
		print(coroutine.running())
		coroutine.yield(i)  --挂起 coroutine，将 coroutine 设置为挂起状态 等待下一个resume
	end
end

co3 = coroutine.create(fun2)
--默认第一个返回值 是 协程是否启动成功
--第二个返回值 是 yield里面的返回值
isOk, tempI = coroutine.resume(co3)  --1 running thread: 00A21D68
print(isOk,tempI)  --true	2
isOk, tempI = coroutine.resume(co3)  --2 running thread: 00A21D68
print(isOk,tempI)  --true	3
isOk, tempI = coroutine.resume(co3)  --3 running thread: 00A21D68
print(isOk,tempI)  --true	4
-- 检查协程是否可以被挂起
--print(coroutine.isyieldable(co3)) -- 输出：true

co4 = coroutine.wrap(fun2)
--这种方式的协程调用 也可以有返回值 
--只是没有默认第一个返回值来协程是否启动成功
print("返回值 "..co4())  --返回值 2
print("返回值 "..co4())  --返回值 3
print("返回值 "..co4())  --返回值 4

print("**********协程的状态************")
--coroutine.status(协程对象)
--dead 结束
--suspended 暂停
--running 进行中
print(coroutine.status(co3))
print(coroutine.status(co))

print("**********正在运行的协程的线程号************")
--这个函数可以得到当前正在 运行的协程的线程号
coroutine.running()
print(coroutine.running())