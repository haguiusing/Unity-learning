using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson45_PrefabUtility : MonoBehaviour
{
    void Start()
    {
        #region ֪ʶ��һ PrefabUtility��������ʲô

        //���� Unity �༭���е�һ��������
        //�ṩ��һЩ���ڴ��� Prefab��Ԥ������Ԥ���壩�ķ���
        //��Ҫ���ܰ��� ʵ����Ԥ���塢����Ԥ���塢�޸�Ԥ���� �ȵ�

        //ֻҪ���ж�Ԥ����������������
        //�������ڱ༭���������κεط��������ʹ��

        #endregion

        #region ֪ʶ��� �����Զ���������ڽ���֪ʶ����

        #endregion

        #region ֪ʶ���� ����API

        //1.��̬����Ԥ���� ·����Assets/...��ʼ
        //  PrefabUtility.SaveAsPrefabAsset(GameObject����, ·��);

        //2.����Ԥ������󣨲������ڴ�����һ�������޸ģ����Ԥ������ص��ڴ��У�
        //  ·����Assets/...��ʼ
        //  PrefabUtility.LoadPrefabContents(·��)
        //  �ͷż��ص�Ԥ�������
        //  PrefabUtility.UnloadPrefabContents(GameObject����)
        //  ע�⣺������������Ҫ���ʹ�ã������˾�Ҫд��

        //3.�޸�����Ԥ���� 
        //  PrefabUtility.SavePrefabAsset(Ԥ�������, out bool �Ƿ񱣴�ɹ�);
        //  �������AssetDatabase.LoadAssetAtPathʹ��

        //4.ʵ����Ԥ����
        //  PrefabUtility.InstantiatePrefab(Object����)

        #endregion

        #region ֪ʶ���� ��������

        //�ٷ��ĵ���https://docs.unity3d.com/2022.3/Documentation/ScriptReference/PrefabUtility.html

        #endregion
    }
}
