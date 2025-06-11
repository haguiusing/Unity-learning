[Unity 中的 Sprite 库资源 |2D 动画 |9.0.3](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html)
# Sprite Library Asset
Sprite Library Asset是一种 Unity 资源，其中包含要用于 [Sprite 交换](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SpriteSwapIntro.html)的 Sprite。本页介绍了什么是 [Sprite Library 资源属性](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#sprite-library-asset-properties)，以及如何[创建 Sprite Library 资源](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#create-a-sprite-library-asset)或 [Sprite Library 资源变体](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#convert-a-sprite-library-asset-into-a-variant)。

Sprite 库资源将其包含的 Sprite 分组到 [Categories （类别](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#categories)） 中，您可以为这些 Sprite 指定称为 [Labels （标签](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#labels)） 的唯一名称来区分它们。您可以在 [Sprite Library Editor 窗口中编辑 Sprite](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html) Library Asset 的内容（有关更多详细信息，请参阅其文档）。

在 [Sprite Swap 工作流程](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SpriteSwapSetup.html)中，在创建一个 Sprite Library 资源或多个资源后，您可以选择要与 [Sprite Library](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-component.html) 组件一起使用的 Sprite Library 资源，[Sprite Resolver](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Resolver.html) 组件将从所选资源中提取信息。

## 创建 Sprite 库资源

要创建 Sprite 库资源，请转到 **Assets** > **Create** > **2D** > **Sprite Library Asset**。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-dropdown.png)

## Sprite 库资产属性

选择 Sprite Library 资源，然后转到其 Inspector 窗口以查看以下属性。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-properties.png)

|财产|描述|
|---|---|
|**在 Sprite Library Editor 中打开**|选择此项可打开[Sprite Library Editor 窗口](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html)以编辑此资源的内容。|
|**主库**|将此属性留空，以使此 Sprite Library 资源引用其自己的 Categories 和 Labels。分配不同的 Sprite 库资源，使其成为[主库](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor-UI.html#main-library)，现在将改为引用第二个资源的 Categories 和 Labels。这样做也[转换](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#convert-a-sprite-library-asset-into-a-variant)将选定的 Sprite 库资源转换为设置为 **Main Library** 的 Sprite Library 资源的 Variant 资源。|
|**恢复**|选择此选项可将属性更改重置回上次保存的状态。选择此选项将删除所有未保存的更改。|
|**应用**|选择此选项可保存当前属性设置。|

## 创建 Sprite 库资产变体

Sprite 库资源变体从选定的 Sprite Library 资源继承 **Categories** 和 **Labels**，而不是引用其自己的资源。有两种方法可以创建 Variant。

### 通过菜单创建

创建 Sprite Library 资源后，在 Project 窗口中选择它，然后转到 **Assets** > **Create** **> 2D** > **Sprite Library Asset Variant** 创建引用它的 Variant 资源。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAssetVariant-dropdown.png)

### 将 Sprite 库资源转换为 Variant

通过将现有 Sprite 库资源设置为其[主库](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html)，可以将现有 Sprite 库资源转换为另一个 Sprite 库资源的变体。

## 其他资源

- [Sprite 库编辑器](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html)
- [设置 Sprite Swap](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SpriteSwapSetup.html)
- [主库的覆盖](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html)