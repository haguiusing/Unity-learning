print("**************toLua访问C#的拓展方法******************")

--静态方法的调用 就是 类.方法名
Lesson4.Eat()

--成员方法
local obj = Lesson4()
--成员方法 一定用冒号！！！
obj:Speak("唐老狮我爱你")

--想要拓展方法使用成功 需要做一件特别的事儿
--CustomSetting文件有关
--需要在配置类中 加上
--_GT(typeof(Lesson4)).AddExtendType(typeof(Tools))
--才能正常使用
obj:Move()