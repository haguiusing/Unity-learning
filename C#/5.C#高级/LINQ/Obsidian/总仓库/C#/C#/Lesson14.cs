using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14 : MonoBehaviour
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

        #region ֪ʶ��һ ֵ���Ͱ���ʲô
        //ͨ���Ͻڿ�����֪��
        //CLR����ʵ���ǰ�ILRuntime���õ���Unity��ط���
        //����CLR�ض����ñ���Ҫʹ�÷���ȥִ�е�һЩ�߼����ֱ��ִ��
        //�������Դ���������ǵ�����
        //��ôֵ���Ͱ󶨣���ʵ���ǰ�Unity���е�һЩ����ֵ���ͷ�������CLR��
        //����Vector2��Vector3��Quaternion��
        //ֵ���Ͱ󶨺�
        //���ܽ��õ��������
        #endregion

        #region ֪ʶ��� ��ν���ֵ���Ͱ�
        //1.��дֵ���Ͱ��ࣨʾ���������ṩ��Vector2��Vector3��Quaternion�ģ�����ֱ��ʹ�ã�
        //2.ע��ֵ���Ͱ�
        //  appDomain.RegisterValueTypeBinder(typeof(ֵ����), new ����());
        //  ��CLR�󶨽ű���ע�ᣬ�ڼ���dll��pdb��ע��

        //ע�⣺
        //��д�����˽�ILRuntimeԭ��֮��ὲ��
        #endregion

        #region ֪ʶ���� �����Ż�����
        //��ILRuntime�ȸ�������ʹ��Unity��ֵ���ͽ��м���
        //������ֵ���Ͱ󶨵�Ч�ʽϵ�
        //����ֵ���Ͱ󶨺����ܽ��������
        #endregion

        #region �ܽ�
        //ֵ���Ͱ󶨣����ǰ�Unity���е�һЩ����ֵ���ͷ�������CLR��
        //�����Դ��������ȸ��¹�����ʹ��Unity��ֵ���Ͷ����Ч��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
