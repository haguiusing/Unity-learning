using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson15 : MonoBehaviour
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

        #region ֪ʶ��һ ILRuntime���Ƽ�ֱ��ʹ��MonoBehaviour
        //ILRuntime��֧�����ȸ������п���̳�MonoBehaviour
        //1.ע�����̳�������
        //2.�Է��ͷ���AddComponent�����ض��򣨽�Ϊ���ӣ�

        //����
        //ILRuntime�����Ƽ�ͨ������̳�ֱ��ʹ��MonoBehaviour
        //�Ƽ��������Lua��һ��ʹ��MonoBehaviour
        //����������ͨ��ί�л��¼�����ʽ�ɷ��������ں��� �� �ȸ���

        //��Ҫԭ��
        //MonoBehaviour��һ����������࣬�ܶ�ײ��߼�����C++�д����
        //��������public�ֶε����л�����Inspector��������ʾ�Ĺ���
        //������ȸ�������ȥд���ײ�C++�߼��޷���ȡ���ȸ�������C#��ص���Ϣ
        #endregion

        #region ֪ʶ��� �ɷ��������ں�������ʽʹ��MonoBehaviour
        //����������ʵ��һ���ű�
        //�ýű�����ҪĿ�ľ����ɷ�MonoBehaviour���������ں������ȸ�������ʹ��
        #endregion

        #region �ܽ�
        //ILRuntime����Ȼ֧�ֿ���̳�MonoBehaviour
        //�������߲���������������
        //���ǿ���ͨ������Lua�ȸ�������
        //����������ʵ�������ɷ��������ں����ĵĹ����ű�
        //ͨ��ί�л��¼��ﵽ�������ں����ĵ���
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
