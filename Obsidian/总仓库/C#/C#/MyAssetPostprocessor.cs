using UnityEditor;
using UnityEngine;

public class MyAssetPostprocessor : AssetPostprocessor
{
    //�������
    //  ����������Դ֮ǰ���ã������޸�����ĵ�������
    void OnPreprocessTexture()
    {
        //1.��Դ�����������ã��Ե������Դ����ͳһ���ã�
        Debug.Log("�������ûص�" + assetPath); // �����ǰ���ڴ����������Դ��·��

        TextureImporter improter = assetImporter as TextureImporter; // ��ȡ��ǰ���ڴ������Դ�ĵ�������ת��ΪTextureImporter����
        improter.textureType = TextureImporterType.Sprite; // ���õ������������ΪSprite
        improter.mipmapEnabled = false; // ����mipmap����Ϊspriteͨ������Ҫmipmap
    }

    //  ����������Դ֮����ã�������Ե����Ϊ����к������� �޸������ʽ���ߴ硢ѹ���ȵ�
    void OnPostprocessTexture(Texture2D texture)
    {
        //2.��Դ��������Ե������Դ����ͳһ��Ԥ����
        Debug.Log("�������ص�" + texture.name); // �����������������

        // ʹ��EditorUtility.CompressTexture����ѹ������ETC_RGB4��ʽ������ѹ��������ΪFast
        EditorUtility.CompressTexture(texture, TextureFormat.ETC_RGB4, TextureCompressionQuality.Fast);
    }

    //ģ�����
    //  ����ģ����Դ֮ǰ���ã������޸�ģ�͵ĵ�������
    void OnPreprocessModel()
    {
        // ��ȡ��ǰ���ڴ������Դ�ĵ�������ת��ΪModelImporter����
        ModelImporter improter = assetImporter as ModelImporter;
        // ��������Զ�ģ�͵ĵ������ý����޸ģ��������������Ż�ѡ����߼��㷽ʽ��
    }

    //  ����ģ����Դ֮����ã�������Ե����Ϊ����к������� �޸����񡢲��ʡ�������
    void OnPostprocessModel(GameObject obj)
    {
        // ����ģ�ͺ󣬿�����������к�������Ϊģ�����Ĭ�ϲ��ʡ�������ײ���������������õ�
    }

    //��Ƶ���
    //  ������Ƶ��Դ֮ǰ���ã������޸���Ƶ�ĵ�������
    void OnPreprocessAudio()
    {
        // ��ȡ��ǰ���ڴ������Դ�ĵ�������ת��ΪAudioImporter����
        AudioImporter improter = assetImporter as AudioImporter;
        // ��������Զ���Ƶ�ĵ������ý����޸ģ�����������Ƶѹ����ʽ���������͵�
    }

    //  ������Ƶ��Դ֮����ã�������Ե����Ϊ����к������� �޸���Ƶ��ʽ��������
    void OnPostprocessAudio(AudioClip clip)
    {
        // ������Ƶ�󣬿�����������к������������Ƶ��������Ӧ����ƵЧ����������Ƶ���ݵ�
    }
}
