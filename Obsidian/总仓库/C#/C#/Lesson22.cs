using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson22 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ C#�����л���
        //��֪ʶ���� Unity����֮C#֪ʶ���� ����ϸ�����
        //C# ͨ��C#������ ���� ��Ӧ�� CIL��ͨ���м����ԣ�
        //Ȼ��ͨ�� CLR��������������ʱ���� CIL ���ͷ��� Ϊ
        //���յĻ����룬������ƽ̨��

        //��ô��������DLL�ļ������д洢�ľ������ǵ� CIL �м�����
        //���ǿ���ͨ�� �����빤�� ILSpy ���鿴��Ӧ�� IL �м����

        //ILSpy��ȡ��ַ��https://github.com/icsharpcode/ILSpy
        //IL�Ļ��������кܶ��ָ����Ϣ
        //�����Ҫѧϰ���ǣ�����ǰ��΢������鿴�����IL���ָ�������
        //https://learn.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-7.0
        #endregion

        #region ֪ʶ��� ILRuntimeʵ���ȸ��µĻ�������Mono.Cecil��
        //�ڵ�һ�ڿδ����ʱ�����Ǿ��ᵽ��Mono.Cecil��
        //����һ���������⣬��Ҫ�����У�
        //1.��ȡC#�����DLL
        //2.���Զ�ȡ��DLL�е����ͺͷ���Ԫ��Ϣ
        //3.���Զ�ȡ��������IL���ָ��
        //4.���Զ�ȡPDB���Է��ű��ļ�
        //5.�����޸�DLL�е�Ԫ��Ϣ�ͷ��������ݲ�д��DLL
        //����������Щ���ܣ����Ա��㷺��Ӧ���ڸ����ȸ�������
        //����xlua��tolua
        //��ILRuntimeҲ�ǻ�������������ǵ��ȸ����ܵ�

        //ILRuntime�Լ�ʵ����
        //1.��������ILRuntime����Mono.Cecil ��ȡ DLL �ļ��е� IL ���룬�����ǻ����Լ��Ĺ����벢ִ��
        //         ILRuntimeʵ�ֵĽ������൱�ھ���һ������C#�Ľ���ִ������

        //2.����ϵͳ�����ڱ�ʾԭʼ���̺��ȸ������еĸ������͡���������Ա��ʵ������ȵ���Ϣ
        //           �൱�ڣ�ILRuntime���������������ڲ��Ľ�����,������ʵ�ֵĴ�����ͷ���Ϊ���Լ���һ�����͹���
        //           ������ִ�д���ʱ�����ǻ���ILRuntime�Լ�������ϵͳ�еĹ�����ִ�е�
        #endregion

        #region �ܽ�
        //ILRuntime����Mono.Cecil������ȡDLL�е�IL�����
        //Ȼ��ͨ�����õ�IL����ִ���������ִ��DLL�еĴ���
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
