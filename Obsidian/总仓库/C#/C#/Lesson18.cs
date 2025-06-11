using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18 : MonoBehaviour
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

        #region 知识点一 ILRuntime中使用序列化库
        //序列化库在我们开发当中经常会用到
        //比如之前我们学过的 LitJson、Protobuf
        //但是这些库都是存在于主工程中的
        //那么当使用他们序列化反序列化热更工程中的对象时
        //他们是不能识别的
        //所以在ILRuntime中使用序列化库
        //需要对其进行修改
        //LitJson库获取：Demo工程中就有修改好的LitJson
        //Protobuf库获取：https://gitee.com/cyecp/protobuf-net

        //注意：
        //改写序列化库时，不能通过Activator来创建实例
        #endregion

        #region 知识点二 使用改好的LitJson库
        //1.初始化时注册
        //  LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(appDomain)
        //2.正常使用LitJson进行序列化反序列化
        //  序列化：JsonMapper.ToJson(对象)
        //  反学历恶化：JsonMapper.ToObject<类型>
        #endregion

        #region 知识点三 如何自己改相关库
        //1.正确创建热更类型的实例（利用之前反射相关的创建方式）
        //2.获取泛型容器类的真实热热更类型
        //3.序列化子对象
        //4.重定向泛型方法

        //去查看LitJson修改后的源码来分析加了哪些内容
        #endregion

        #region 总结
        //ILRuntime在使用第三方库时
        //为了能够正常的对热更工程中声明的类对象进行使用
        //我们往往需要对其进行修改
        //修改第三方库对于大家来说可能有一定难度
        //所以首先去ILRuntime的群和社区中去找找有没有别人做好的
        //如果没有再尝试自己修改
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
