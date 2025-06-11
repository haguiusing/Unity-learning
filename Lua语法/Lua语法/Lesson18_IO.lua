print("**********文件 IO 库************")

--简单模式
--简单模式使用标准的 I/O 或使用一个当前输入文件和一个当前输出文件。
-- 以只读方式打开文件
file = io.open("testIO.lua", "r")
print(file)  --file (72231BD8)

-- 设置默认输入文件为 testIO.lua
io.input(file)

-- 输出文件第一行
print(io.read())  ----testIO.lua

-- 关闭打开的文件
io.close(file)

-- 以附加的方式打开只写文件
file = io.open("testIO.lua", "a")

-- 设置默认输出文件为 test.lua
io.output(file)

-- 在文件最后一行添加 Lua 注释
--io.write("--  testIO.lua 文件末尾注释")

-- 关闭打开的文件
io.close(file)

--完全模式
--需要在同一时间处理多个文件。我们需要使用 file:function_name 来代替 io.function_name 方法。
-- 以只读方式打开文件
file = io.open("testIO.lua", "r")

-- 输出文件第一行
print(file:read())

-- 关闭打开的文件
file:close()

-- 以附加的方式打开只写文件
file = io.open("testIO1.lua", "a")

-- 在文件最后一行添加 Lua 注释
file:write("--test")

-- 关闭打开的文件
file:close()
