print("**************toLua访问C#的重载方法******************")

local obj = Lesson6()

print(obj:Calc())
--toLua和xLua一样 对重载函数的精度支持不太好
--lua中只有Number一种数值类型 它会傻傻分不清
print(obj:Calc(1))
print(obj:Calc(1.2))
print(obj:Calc("123"))

--这里调用的 是非out参数的函数重载
print(obj:Calc(10, 1))
--在tolua中用out重载 有一个固定套路
--意味着我们在使用 Unity中的一些api中有out时 我们就可以用nil站位了
--toLua中对ref支持不太好 建议不要使用 特别是在重载函数时
print(obj:Calc(10, nil))
