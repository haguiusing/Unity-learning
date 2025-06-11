using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson46_EditorApplication : MonoBehaviour
{
    void Start()
    {
        #region ֪ʶ��һ EditorApplication��������������ʲô�ģ�

        //���� Unity �༭���е�һ�������࣬����Ҫ�ṩ��һЩ�ͱ༭��������ص�һЩ����
        //���� �༭���¼����������š���ͣ�ȣ������������жϣ��Ƿ������С���ͣ�С������У�
        //     �༭�����벥��ģʽ���˳�����ģʽ �ȵȹ���

        #endregion

        #region ֪ʶ��� �����Զ���������ڽ���֪ʶ����

        #endregion

        #region ֪ʶ���� ����API

        //1.�����༭���¼�
        //  EditorApplication.update��ÿ֡�����¼������������ڱ༭����ִ��һЩ�߼�
        //  EditorApplication.hierarchyChanged���㼶��ͼ�仯�¼����������еĶ������仯ʱ����
        //  EditorApplication.projectChanged����Ŀ�仯�¼�������Ŀ�е���Դ�����仯ʱ����
        //  EditorApplication.playModeStateChanged���༭������״̬�仯ʱ����
        //  EditorApplication.pauseStateChanged���༭����ͣ״̬�仯ʱ����

        //2.����༭�������������
        //  EditorApplication.isPlaying���жϵ�ǰ�Ƿ�����Ϸ����״̬��
        //  EditorApplication.isPaused���жϵ�ǰ��Ϸ�Ƿ�����ͣ״̬��
        //  EditorApplication.isCompiling���ж�Unity�༭���Ƿ����ڱ������
        //  EditorApplication.isUpdating���ж�Unity�༭���Ƿ�����ˢ��AssetDatabase

        //3.��ȡUnityӦ�ó���·�����
        //  EditorApplication.applicationContentsPath��Unity��װĿ¼Data·��
        //  EditorApplication.applicationPath��Unity��װĿ¼��ִ�г���·��

        //4.���÷���
        //  EditorApplication.Exit(0)���˳�Unity�༭��
        //  EditorApplication.ExitPlaymode()���˳�����ģʽ���л����༭ģʽ
        //  EditorApplication.EnterPlaymode()�����벥��ģʽ

        #endregion

        #region ֪ʶ���� ��������

        //�ٷ��ĵ�
        //EditorApplication�� https://docs.unity3d.com/2022.3/Documentation/ScriptReference/EditorApplication.html
        //EditorSceneManager��https://docs.unity3d.com/2022.3/Documentation/ScriptReference/SceneManagement.EditorSceneManager.html

        #endregion
    }
}
