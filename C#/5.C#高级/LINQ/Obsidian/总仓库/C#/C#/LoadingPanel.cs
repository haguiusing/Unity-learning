using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    //进度条
    public Image imgPro;
    //当前加载信息说明
    public Text txtInfo;

    // Start is called before the first frame update
    void Start()
    {
        imgPro.rectTransform.sizeDelta = new Vector2(0, 50);
        txtInfo.text = "资源加载中";
    }

    //第一：需要去更新资源服务器上的AB包
    public void BeginUpdate()
    {
        //第一个委托 是用于 AB包下载更新结束后 处理逻辑的
        //第二个委托 是用于 更新当前加载信息的
        ABUpdateMgr.Instance.CheckUpdate(ABUpdateOverDoSomthing, (info) =>
        {
            txtInfo.text = info;
        }, (nowNum, maxNum)=> {
            imgPro.rectTransform.sizeDelta = new Vector2(nowNum / maxNum * 1600, 50);
        });
    }

    //第二：AB包更新完毕后 需要去处理ILRuntime初始化相关的逻辑
    public void ABUpdateOverDoSomthing(bool isOver)
    {
        if(!isOver)
        {
            txtInfo.text = "AB包下载更新出错，请检查网络连接或联系服务商";
            return;
        }

        txtInfo.text = "资源加载结束";
        //ILRuntime的初始化相关
        ILRuntimeMgr.GetInstance().StartILRuntime(() =>
        {
            //ILRuntime相关内容加载结束 就可以执行游戏逻辑了
            txtInfo.text = "游戏初始化完毕";
            //热更相关逻辑执行
            ILRuntimeMgr.GetInstance().appDomain.Invoke("HotFix_Project.ILRuntimeMain", "StartILRuntime", null, null);

        }, (info)=> {
            txtInfo.text = info;
        });
    }
}
