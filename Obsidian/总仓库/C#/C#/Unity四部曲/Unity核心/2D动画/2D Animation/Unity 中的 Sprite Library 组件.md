**Sprite Library** 组件定义游戏对象在运行时引用的 [Sprite Library 资源](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html)。将此组件附加到游戏对象时，附加到同一游戏对象或子游戏对象的 [Sprite Resolver 组件](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Resolver.html)将引用 Sprite Library 组件设置的 Sprite Library Asset。这允许您使用 Sprite Resolver 组件更改 [Sprite 渲染器](https://docs.unity.cn/Manual/class-SpriteRenderer)引用的 Sprite。

## 属性设置

在 Sprite Library 组件的 Inspector 窗口中，将所需的 Sprite Library Asset 分配给 **Sprite Library Asset** 属性。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLComp-properties.png)

分配 Sprite Library 资源后，Inspector 窗口会显示所选 Sprite Library 资源中内容的视觉预览。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLComp-preview.png)

## 组件功能

在 Sprite Library 组件 Inspector 窗口中，您可以将相同的覆盖提交到分配的 Sprite Library 资源，就像在 [Sprite Library Editor](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html) 窗口中[提交到](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html)主**库**一样。您可以添加或删除新 Categories，在 Category 中添加或删除新 Labels，并更改 Label 引用的 sprite。

## 修改后的精灵

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-category-entry-icon.png)  
_示例：从 Sprite Library 资源中检索到的修改后的 Sprite。_

**在以下情况下，+** 图标将显示在 Label 条目的左上角：

- 您可以从检索到的 Sprite Library 资源中将新 Label 添加到 Category。
- 您可以从 Sprite Library 资源中检索的原始 Sprite 引用更改 Label 的 Sprite 引用。

## 类别和标签名称冲突行为

以下是 Unity 解决在 **Sprite Library Asset** 属性中分配的 Sprite Library 资源替换为另一个 Sprite Library 资源时可能发生的任何名称冲突的方法。

- 如果当前设置的 Sprite Library 资源中已存在相同的 Category 名称，则 Unity 会将两个 Sprite Library 资源中具有相同名称的 Categories 中的标签合并为具有该名称的单个 Category。
    
- 如果在分配 Sprite 库资源时，同一类别中有同名的标签，则 Unity 会将这些标签合并为一个标签。合并后的 Label 改用替换 Sprite Library 资源中的 Sprite 引用。
    

**注意：**从 **Sprite Library Asset** 属性中删除 Sprite Library 资源时，覆盖不会保存到该 Sprite Library 资源中。所有更改都保留在 Sprite Library 组件中。