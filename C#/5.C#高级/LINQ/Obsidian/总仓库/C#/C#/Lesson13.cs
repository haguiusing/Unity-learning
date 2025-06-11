using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson13 : MonoBehaviour
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

        #region ��ϰ CLR��ʲô��Unity����֮C#֪ʶ���䣩
        //CLR��Common Language Runtime��
        //������������ʱ������.Net Framework�Ļ�����
        //���е�.Net�������ǽ����ڴ�֮�ϵ�
        //����������ʵ���˿����ԺͿ�ƽ̨

        //����һ����ִ��ʱ�������Ĵ��룬�ṩ�ڴ����
        //�̹߳���ȵȺ��ķ��񣬾ͺ���һ��С�͵Ĳ���ϵͳһ��
        //��������İ�����Ϊ��.Net���������
        //�����ҪӦ�ó�����Ŀ�����ϵͳ���ܹ�����
        //�ͱ�������.Net�ṩ��CLR������֧��
        #endregion

        #region ֪ʶ��һ CLR�ض�����ʲô
        //CLR�ض�����Ҫ�����ڶ��ȸ������еĵ�һЩ��������"Ю��"
        //���ǽ�ԭ���ķ���"Ю��"�ˣ�����ʵ�ַ���������߼�
        //�ﵽ �ض����Ŀ��

        //˵�˻���
        //���ǿ���ͨ��CLR�ض��򣬽�ĳһ��������ִ�ж�λ�����ǵ��Զ����߼��У�������ִ��ԭ���ķ����߼�
        //�е�������д
        #endregion

        #region ֪ʶ��� CLR�󶨵����ú�ԭ��
        //Ĭ������£�ILRuntime�ȸ����̵���Unity������������ݶ���ͨ������������
        //������2��ȱ�㣺
        //1.���ܽϵͣ�������ñ�ֱ�ӵ���Ч�ʵ�
        //2.IL2CPP���ʱ���ױ��ü�

        //���ILRuntime�ṩ���Զ���������CLR�󶨵Ĺ���
        //���������ǣ�
        //1.����������ܣ���������ñ�Ϊ��ֱ�ӵ���
        //2.����IL2CPP�ü���������

        //ԭ��
        //CLR�󶨣����ǽ�����ILRuntime��CLR�ض��������ʵ�ֵ�
        //�����Ͼ��ǽ������ķ�������ض����������Զ���ķ���������

        //ע�⣺
        //ÿ�����Ǵ����������֮ǰ��Ҫ�ǵ�����CLR��
        #endregion

        #region ֪ʶ���� ��ν���CLR��
        //1. �� Samples\ILRuntime\2.1.0\Demo\Editor\ILRuntimeCLRBinding.cs ����
        //   �� InitILRuntime ������ע�����̳���ص��� �Լ� �������ݣ��Ժ�ὲ�⣩
        //2. ��� ����������>ILRuntime����>ͨ���Զ������ȸ�DLL����CLR��
        //   ��ʱ�Ϳ�����ILRuntimeCLRBinding.cs ���������õĵ���·���п������ɵİ󶨴���
        //3. �ڳ�ʼ���� ��ӣ�ILRuntime.Runtime.Generated.CLRBindings.Initialize(appDomain);

        //ע�⣺
        //�����CLR��ע��ǰ������CLR�ض����������
        //Ϊ�˱�֤�Զ�����ض����ܹ�����ʹ��
        //��ʼ��CLR��һ��Ҫ�������һ��
        //�����Ͳ���Ӱ���Լ���Ҫ�������ض���ȳ�ʼ��������
        #endregion

        #region ֪ʶ���� CLR��������������
        //������ILRuntime��ȥ����Unity�еķ���
        //���������CLR�󶨣�����ͨ������
        //������ˣ�����ֱ�ӵ���
        //���ǿ���ͨ�����Ժ��������ֳ����ܵ�����
        #endregion

        #region ֪ʶ���� �Զ���CLR�ض���
        //������Debug.Log����
        //�����ILRuntime�����е���Debug.Log
        //�������޷���ȡ���ȸ������еĽű����к������Ϣ��
        //���ǿ���ͨ��CLR�ض������ʽ��ȡ����Ϣ���ٴ�ӡ

        //���裺
        //1.����CLR�����Զ����ɵİ󶨴���
        //  �����ȡDebug�е�Log����
        //  ��������ض���
        //2.���ض����е���Debug.Log֮ǰ
        //  ��ȡDLL�ڵĶ�ջ��Ϣ ���ƴ�Ӵ�ӡ

        //ע�⣺
        //Ҫʹ��CLR�ض���ʱ����Ҫ��unsafe������ʹ��
        //����������Ҫ�ڶ����ض�������ʹ���ض������ĵط�����unsafe
        #endregion

        #region �ܽ�
        //CLR�󶨾�������CLR�ض���ԭ����Ҫ������õ����ݱ�Ϊֱ�ӵ���
        //���԰�������
        //1.����ILRuntime������
        //2.����IL2CPP���ʱ�ü�������Ҫ�õ�����
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ���ڲ���CLR�� ���������ĺ���
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    public static int TestFun(int i, int j)
    {
        return i + j;
    }
}
