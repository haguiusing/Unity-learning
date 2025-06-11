# Point Cache 资源
Point Cache 资源遵循开源 [Point Cache](https://github.com/peeweek/pcache/blob/master/README.md) 规范并使用“.pCache”文件扩展名。这些资源在内部是嵌套的 [脚本化对象](https://docs.unity3d.com/Manual/class-ScriptableObject.html) 并包含所有代表粒子属性贴图的各种纹理。

Point Cache 资源是只读的，因此如果您选择一个资源并在检查器中查看，无法编辑其任何属性。但是，检查器会显示每个只读属性的值。有关每个只读属性的含义的信息，请参阅 [属性](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-asset.html#properties)。

## 属性
Point Cache 资源显示一些只读信息，例如它包含的粒子数量和表示粒子属性的纹理等等。

|**属性**|**描述**|
|---|---|
|**Script**|指定 Unity 用于导入“.pCache”文件的导入器。|
|**Point Count**|此 Point Cache 代表的粒子数。|
|**Surface**|表示粒子属性贴图的纹理的列表。数组每个索引中的纹理名称与贴图的属性名称相同。|