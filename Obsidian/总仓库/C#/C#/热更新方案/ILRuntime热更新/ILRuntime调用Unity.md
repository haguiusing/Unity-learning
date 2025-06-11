主入口：![[ILRuntimeMain.cs]]
![[Lesson9.cs]]

就像在Unity开发中使用一样
引用命名空间后，直接使用即可
之所以我们能够直接使用
是因为热更工程已经引用了Unity对应的Dll文件

注意：
测试热更工程中 只关联引用了部分Unity相关dll
如果想要使用更多
只需要把对应Unity的Dll文件拷贝到热更工程中的UnityDlls文件夹中即可
再在热更工程中设置一下dll文件的引用
