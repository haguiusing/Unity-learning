using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ����֮ǰ������ڵ���
        ILRuntimeMgr.Instance.StartILRuntime(() => {
            //ִ��ILRuntime���е�һ����̬����
            //��̬������ �����ȸ������Լ�������߼���
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);
        });
        #endregion

        #region ֪ʶ��һ ILRuntime��ʹ�����л���
        //���л��������ǿ������о������õ�
        //����֮ǰ����ѧ���� LitJson��Protobuf
        //������Щ�ⶼ�Ǵ������������е�
        //��ô��ʹ���������л������л��ȸ������еĶ���ʱ
        //�����ǲ���ʶ���
        //������ILRuntime��ʹ�����л���
        //��Ҫ��������޸�
        //LitJson���ȡ��Demo�����о����޸ĺõ�LitJson
        //Protobuf���ȡ��https://gitee.com/cyecp/protobuf-net

        //ע�⣺
        //��д���л���ʱ������ͨ��Activator������ʵ��
        #endregion

        #region ֪ʶ��� ʹ�øĺõ�LitJson��
        //1.��ʼ��ʱע��
        //  LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(appDomain)
        //2.����ʹ��LitJson�������л������л�
        //  ���л���JsonMapper.ToJson(����)
        //  ��ѧ���񻯣�JsonMapper.ToObject<����>
        #endregion

        #region ֪ʶ���� ����Լ�����ؿ�
        //1.��ȷ�����ȸ����͵�ʵ��������֮ǰ������صĴ�����ʽ��
        //2.��ȡ�������������ʵ���ȸ�����
        //3.���л��Ӷ���
        //4.�ض����ͷ���

        //ȥ�鿴LitJson�޸ĺ��Դ��������������Щ����
        #endregion

        #region �ܽ�
        //ILRuntime��ʹ�õ�������ʱ
        //Ϊ���ܹ������Ķ��ȸ���������������������ʹ��
        //����������Ҫ��������޸�
        //�޸ĵ���������ڴ����˵������һ���Ѷ�
        //��������ȥILRuntime��Ⱥ��������ȥ������û�б������õ�
        //���û���ٳ����Լ��޸�
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
