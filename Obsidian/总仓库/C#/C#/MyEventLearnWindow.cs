using System;
using UnityEditor;
using UnityEngine;

public class MyEventLearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MyEventLearnWindow")]
    private static void OpenMyEventLearnWindow()
    {
        MyEventLearnWindow win = EditorWindow.GetWindow<MyEventLearnWindow>("Eventѧϰ����");
        win.Show();
    }

    private void OnGUI()
    {
        //1.��ȡ��ǰ�¼�
        //  Event.current
        Event eventCurrent = Event.current;

        //2.alt���Ƿ���
        //  Event.current.alt
        if (eventCurrent.alt)
            Debug.Log("alt��������");

        //3.shift���Ƿ���
        //  Event.current.shift
        if (eventCurrent.shift)
            Debug.Log("shift��������");

        //4.ctrl���Ƿ���
        //  Event.current.control
        if (eventCurrent.control)
            Debug.Log("control��������");

        //5.�Ƿ�������¼�
        //  Event.current.isMouse
        if (eventCurrent.isMouse)
        {
            Debug.Log("�������¼�");

            //6.�ж���������Ҽ�
            //  Event.current.button (0,1,2 �ֱ���� ��,��,�� �������2������������갴��)
            Debug.Log(eventCurrent.button);

            //7.���λ��
            //  Event.current.mousePosition
            Debug.Log("���λ��" + eventCurrent.mousePosition);
        }

        //8.�ж��Ƿ��Ǽ�������
        //  Event.current.isKey
        if (eventCurrent.isKey)
        {
            Debug.Log("��������¼�");

            //9.��ȡ����������ַ�
            //  Event.current.character
            Debug.Log(eventCurrent.character);

            //10.��ȡ���������Ӧ��KeyCode
            //  Event.current.keyCode
            //Debug.Log(eve.keyCode);
            switch (eventCurrent.keyCode)
            {
                case KeyCode.Space:
                    Debug.Log("�ո������");
                    break;
            }
        }

        //11.�ж���������
        //  Event.current.type
        //  EventTypeö�ٺ����Ƚϼ���
        //  EventType���г��õ� ��갴��̧����ק�����̰���̧��ȵ�����
        //  һ�������� ���ж� ���� ���� ����̧������صĲ���

        //12.�Ƿ�������д ��Ӧ������caps���Ƿ���
        //  Event.current.capsLock
        if (eventCurrent.capsLock)
            Debug.Log("��Сд��������");
        else
            Debug.Log("��Сд�����ر�");

        //13.Windows����Command���Ƿ���
        //  Event.current.command
        if (eventCurrent.command)
            Debug.Log("PC win������ �� Mac Command������");

        //14.�����¼� �ַ���
        //  Event.current.commandName
        //  ���������ж��Ƿ񴥷��˶�Ӧ�ļ����¼�
        //  ����ֵ��
        //  Copy:����
        //  Paste:ճ��
        //  Cut:����
        if (eventCurrent.commandName == "Copy")
        {
            Debug.Log("������ctrl + c");
        }

        if (eventCurrent.commandName == "Paste")
        {
            Debug.Log("������ctrl + v");
        }

        if (eventCurrent.commandName == "Cut")
        {
            Debug.Log("������ctrl + x");
        }

        //15.������ƶ�����
        //  Event.current.delta

        //Debug.Log(eve.delta);

        //16.�Ƿ��ǹ��ܼ�����
        //  Event.current.functionKey
        //  ���ܼ�ָС�����е� �����, page up, page down, backspace�ȵ�
        if (eventCurrent.functionKey)
            Debug.Log("�й��ܰ�������");

        //17.С�����Ƿ���
        //  Event.current.numeric
        if (eventCurrent.numeric)
            Debug.Log("С�����Ƿ���");

        //18.������ϼ���ͻ
        //  Event.current.Use()
        //  �ڴ������Ӧ�����¼��󣬵��ø÷�����������ֹ�¼������ɷ������ú�Unity�����༭���¼��߼���ͻ
        eventCurrent.Use();
    }
}
