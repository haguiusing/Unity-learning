![[MyAssetPostprocessor.cs]]

![[Lesson48_AssetImporter和AssetPostprocessor.cs]]

### AssetImporter和AssetPostprocessor和什么有关
今天学的两个知识点，它们是需要配合进行使用的。它们主要是用于处理资源导入批量设置（对导入的资源进行统一设置）和资源导入后处理（对导入的资源进行统一的预处理）。

### AssetPostprocessor的作用
AssetPostprocessor（资源后处理器类）主要用于处理资源导入时的通用逻辑。我们可以通过继承该类并实现其中的一些回调方法来自定义处理资源。我们一般会进行以下处理：
- 进行某种类型资源的通用设置
- 对某种类型资源进行统一批量的处理

继承它后的常用属性有：
- `AssetImporter assetImporter`：对应类型的资源导入器对象
- `string assetPath`：导入资源的路径

继承它后的常用回调方法有：
- 纹理相关
    - `void OnPreprocessTexture()`：导入纹理资源之前调用，允许修改纹理的导入设置
    - `void OnPostprocessTexture(Texture2D texture)`：导入纹理资源之后调用，允许你对导入后为其进行后处理，比如修改纹理格式、尺寸、压缩等等
- 模型相关
    - `void OnPreprocessModel()`：导入模型资源之前调用，允许修改模型的导入设置
    - `void OnPostprocessModel(GameObject obj)`：导入模型资源之后调用，允许你对导入后为其进行后处理，比如修改网格、材质、动画等
- 音频相关
    - `void OnPreprocessAudio()`：导入音频资源之前调用，允许修改音频的导入设置
    - `void OnPostprocessAudio(AudioClip clip)`：导入音频资源之后调用，允许你对导入后为其进行后处理，比如修改音频格式、质量等

更多内容详见[AssetPostprocessor](https://docs.unity3d.com/ScriptReference/AssetPostprocessor.html)。

注意：如果只想对某种资源中的某些内容进行处理，可以自己加命名规则。

### AssetImporter的作用
AssetImporter（资源导入器类）是特定资源类型的资源导入程序的基类，提供了一些方法和属性，用于配置和管理资源的导入设置。一般我们不会直接使用该类，而是通过使用继承它的子类来设置导入资源的相关信息。当我们导入一个资源时，在Inspector窗口中进行的相关设置都是通过继承该类的子类实现的。

它的子类一般按照资源类型来划分：
- TextureImporter：用于导入纹理资源，并配置纹理的压缩格式、尺寸、平铺方式等设置。[TextureImporter](https://docs.unity3d.com/ScriptReference/TextureImporter.html)
- ModelImporter：用于导入模型资源，并配置模型的导入设置，如网格、材质、动画等。[ModelImporter](https://docs.unity3d.com/ScriptReference/ModelImporter.html)
- AudioImporter：用于导入音频资源，并配置音频的导入设置，如压缩格式、音频质量等。[AudioImporter](https://docs.unity3d.com/ScriptReference/AudioImporter.html)
- VideoClipImporter：用于导入视频资源，并配置视频的导入设置，如视频质量、循环模式等。[VideoClipImporter](https://docs.unity3d.com/ScriptReference/VideoClipImporter.html)
- ScriptedImporter：用于创建自定义的资源导入器，可以通过编写脚本来实现对特定类型资源的导入设置和处理逻辑。如果想要对某些特定格式的资源进行自定义配置处理，可以通过继承该类的方式去实现。[ScriptedImporter](https://docs.unity3d.com/ScriptReference/AssetImporters.ScriptedImporter.html)

### AssetImporter和AssetPostprocessor联动使用
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/48.AssetImporter%E5%92%8CAssetPostprocessor/1.png)

```cs
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
```

![[Pasted image 20250609002036.png]]

