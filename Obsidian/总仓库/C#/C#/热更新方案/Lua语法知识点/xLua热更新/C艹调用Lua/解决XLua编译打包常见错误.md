[解决XLua编译打包常见错误-CSDN博客](https://blog.csdn.net/sndybo/article/details/103238948)

## 1、UnityEngine_ResourcesWrap
Assets\XLua\Gen\UnityEngine_ResourcesWrap.cs(396,54): error CS0306: The type 'ReadOnlySpan\<int\>' may not be used as a type argument

## 2、UnityEngine_TransformWrap
Assets\XLua\Gen\UnityEngine_TransformWrap.cs(622,54): error CS0306: The type 'Span\<Vector3\>' may not be used as a type argument
[fix: 修复在 Unity 2022 下生成代码报 Span 无法作泛型参数的问题 by SlimeNull · Pull Request #1104 · Tencent/xLua](https://github.com/Tencent/xLua/pull/1104/commits/11f53f47c573c7da4ac39a3eef87cd541de6ec94)

