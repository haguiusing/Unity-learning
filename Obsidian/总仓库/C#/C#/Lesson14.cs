using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 复制之前的主入口调用
        ILRuntimeMgr.Instance.StartILRuntime(() => {
            //执行ILRuntime当中的一个静态函数
            //静态函数中 就是热更工程自己处理的逻辑了
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);
        });
        #endregion

        #region 知识点一 值类型绑定是什么
        //通过上节课我们知道
        //CLR绑定其实就是把ILRuntime中用到的Unity相关方法
        //进行CLR重定向，让本来要使用反射去执行的一些逻辑变成直接执行
        //这样可以大大提升我们的性能
        //那么值类型绑定，其实就是把Unity当中的一些常用值类型方法进行CLR绑定
        //比如Vector2、Vector3、Quaternion等
        //值类型绑定后
        //性能将得到大幅提升
        #endregion

        #region 知识点二 如何进行值类型绑定
        //1.手写值类型绑定类（示例工程中提供了Vector2、Vector3、Quaternion的，可以直接使用）
        //2.注册值类型绑定
        //  appDomain.RegisterValueTypeBinder(typeof(值类型), new 绑定类());
        //  在CLR绑定脚本中注册，在加载dll和pdb后注册

        //注意：
        //手写必须了解ILRuntime原理，之后会讲解
        #endregion

        #region 知识点三 性能优化体现
        //在ILRuntime热更工程中使用Unity中值类型进行计算
        //不进行值类型绑定的效率较低
        //进行值类型绑定后性能将大幅提升
        #endregion

        #region 总结
        //值类型绑定，就是把Unity当中的一些常用值类型方法进行CLR绑定
        //他可以大幅提高在热更新工程中使用Unity中值类型对象的效率
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
