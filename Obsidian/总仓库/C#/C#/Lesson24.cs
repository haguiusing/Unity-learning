using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson24 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ILRuntime�еĽ�����������ʲô��
        //��ILRuntimeͨ��Mono.Cecil�⽫DLL�ļ��е� IL �м����Զ�ȡ������
        //�������Ѿ�д�õ���ش��룬��IL������ͷ��룬֮������ִ��
        //����Ҫ���ˣ�ILIntepreter�ű�����
        //1.�����������е�ÿһ��ָ��
        //2.ʹ���ڲ��޴�� switch case ���ڴ���IL�е�ÿһ��ָ��жϲ�ͬ��ָ�������������Ӧ�߼���

        //��ִ�д���ʱ��ʹ��ILRuntime�ڲ��Լ�ʵ�ֵ�����ջ�������ڴ�
        //ILRuntime��ʹ�÷��й��ڴ棬�ڴ治�ᱻGC��������ILRuntime�ڲ��Լ�����ͨ��ָ��ֱ�Ӷ��ڴ���в������ű�RuntimeStack��
        //����ʹ���Զ����� StackObject ������������ֵ
        #endregion

        #region ֪ʶ��� ILRuntime�е��ڴ沼��
        //��ILRuntimeʵ�ֵķ��й� ����ջ �д洢�Ķ�����Ҫ����StackObject����
        //�ڸ�����ջ�У�StackObject�������������еģ�����ֻ��Ҫ�ƶ���ǰ��ջָ��Ϳ��Ի�ȡ��ջ�д洢�ĸ�����

        //                      **StackObject** (ջָ�� - 1)
        //                         ObjectType
        //                           Value
        //                          ValueLow
        //  ջָ��   ��������>      **StackObject** (ջָ��)
        //                         ObjectType
        //                           Value
        //                          ValueLow
        //                      **StackObject** (ջָ�� + 1)
        //                         ObjectType
        //                           Value
        //                          ValueLow
        #endregion

        #region ֪ʶ���� ILRuntime�з���ָ��ĵ���
        //1.��˳�򽫲�������ѹջ
        //2.����ջָ����ƶ���ȡ�����������д���
        //3.����ջ(��ջָ���ƶ����ײ����·����ݾ���Ϊ�ᱻ�ͷ���)

        //  ����1                  ����ֵ
        //  ����2                  ջָ��
        //  �ֲ�����1    ������������>
        //  �ֲ�����2
        //  ջָ��
        #endregion

        #region ֪ʶ���� ����CLR�ض���
        //���ǿ�����ILIntepreter�ű�������callvirtָ��Զ�����ú��ڰ󶨷��������ҽ�����ֵ���͵������ջ�ϣ�
        //��ָ����У����������CLR�ض��򣬻���ö�Ӧ�󶨵�ί�к���
        #endregion

        #region �ܽ�
        //ILRuntime�Ľ��������� �����Ѿ�д�õ���ش��룬��IL������ͷ�������ִ��
        //����������˵��Ҫ�����˽������ڴ沼�֣��Լ�����ָ������ε��õ�
        //�������ǲ��ܹ���������дCLR�ض�����ص��߼�
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
