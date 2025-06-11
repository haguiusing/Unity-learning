using UnityEditor;
using UnityEngine;

public class MyAssetPostprocessor : AssetPostprocessor
{
    //纹理相关
    //  导入纹理资源之前调用，允许修改纹理的导入设置
    void OnPreprocessTexture()
    {
        //1.资源导入批量设置（对导入的资源进行统一设置）
        Debug.Log("纹理设置回调" + assetPath); // 输出当前正在处理的纹理资源的路径

        TextureImporter improter = assetImporter as TextureImporter; // 获取当前正在处理的资源的导入器并转换为TextureImporter类型
        improter.textureType = TextureImporterType.Sprite; // 设置导入的纹理类型为Sprite
        improter.mipmapEnabled = false; // 禁用mipmap，因为sprite通常不需要mipmap
    }

    //  导入纹理资源之后调用，允许你对导入后为其进行后处理，比如 修改纹理格式、尺寸、压缩等等
    void OnPostprocessTexture(Texture2D texture)
    {
        //2.资源导入后处理（对导入的资源进行统一的预处理）
        Debug.Log("纹理后处理回调" + texture.name); // 输出处理后的纹理名称

        // 使用EditorUtility.CompressTexture方法压缩纹理到ETC_RGB4格式，并且压缩质量设为Fast
        EditorUtility.CompressTexture(texture, TextureFormat.ETC_RGB4, TextureCompressionQuality.Fast);
    }

    //模型相关
    //  导入模型资源之前调用，允许修改模型的导入设置
    void OnPreprocessModel()
    {
        // 获取当前正在处理的资源的导入器并转换为ModelImporter类型
        ModelImporter improter = assetImporter as ModelImporter;
        // 在这里可以对模型的导入设置进行修改，例如设置网格优化选项、法线计算方式等
    }

    //  导入模型资源之后调用，允许你对导入后为其进行后处理，比如 修改网格、材质、动画等
    void OnPostprocessModel(GameObject obj)
    {
        // 导入模型后，可以在这里进行后处理，例如为模型添加默认材质、生成碰撞器、调整动画设置等
    }

    //音频相关
    //  导入音频资源之前调用，允许修改音频的导入设置
    void OnPreprocessAudio()
    {
        // 获取当前正在处理的资源的导入器并转换为AudioImporter类型
        AudioImporter improter = assetImporter as AudioImporter;
        // 在这里可以对音频的导入设置进行修改，例如设置音频压缩格式、加载类型等
    }

    //  导入音频资源之后调用，允许你对导入后为其进行后处理，比如 修改音频格式、质量等
    void OnPostprocessAudio(AudioClip clip)
    {
        // 导入音频后，可以在这里进行后处理，例如调整音频的音量、应用音频效果、分析音频数据等
    }
}
