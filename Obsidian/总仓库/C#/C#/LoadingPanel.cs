using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    //������
    public Image imgPro;
    //��ǰ������Ϣ˵��
    public Text txtInfo;

    // Start is called before the first frame update
    void Start()
    {
        imgPro.rectTransform.sizeDelta = new Vector2(0, 50);
        txtInfo.text = "��Դ������";
    }

    //��һ����Ҫȥ������Դ�������ϵ�AB��
    public void BeginUpdate()
    {
        //��һ��ί�� ������ AB�����ظ��½����� �����߼���
        //�ڶ���ί�� ������ ���µ�ǰ������Ϣ��
        ABUpdateMgr.Instance.CheckUpdate(ABUpdateOverDoSomthing, (info) =>
        {
            txtInfo.text = info;
        }, (nowNum, maxNum)=> {
            imgPro.rectTransform.sizeDelta = new Vector2(nowNum / maxNum * 1600, 50);
        });
    }

    //�ڶ���AB��������Ϻ� ��Ҫȥ����ILRuntime��ʼ����ص��߼�
    public void ABUpdateOverDoSomthing(bool isOver)
    {
        if(!isOver)
        {
            txtInfo.text = "AB�����ظ��³��������������ӻ���ϵ������";
            return;
        }

        txtInfo.text = "��Դ���ؽ���";
        //ILRuntime�ĳ�ʼ�����
        ILRuntimeMgr.GetInstance().StartILRuntime(() =>
        {
            //ILRuntime������ݼ��ؽ��� �Ϳ���ִ����Ϸ�߼���
            txtInfo.text = "��Ϸ��ʼ�����";
            //�ȸ�����߼�ִ��
            ILRuntimeMgr.GetInstance().appDomain.Invoke("HotFix_Project.ILRuntimeMain", "StartILRuntime", null, null);

        }, (info)=> {
            txtInfo.text = info;
        });
    }
}
