[[Visual Effect 组件 API]]

# 视觉效果 （组件）
Visual Effect Component 基于 Visual Effect Graph 资源在场景中创建 Visual Effect 的实例。它控制效果的播放方式、渲染方式，并允许用户通过编辑 [Exposed Properties](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#creating-properties) 来自定义实例。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#how-to-create-a-visual-effect)如何创建视觉效果
要创建视觉效果：
1. 使用 Inspector 中的 **Add Component** 菜单添加 Visual Effect 组件，或导航到 **Visual Effect > > Component**
2. 单击 Asset Template 属性旁边的 **New** Button。
3. 保存新的 Visual Effect Graph 资源。

然后，Visual Effect Graph 窗口将打开新创建的资源。

要创建包含 Visual Effect 组件的完整游戏对象，请导航到 GameObject 菜单，单击 **Visual Effects**，然后选择 **Visual Effect**。

当您将 Visual Effect Graph 资源从项目视图拖动到 Scene 视图或层次结构视图时，它会自动创建一个具有 Visual Effect Component 的子游戏对象：
- 拖放到 Scene 视图中时：在摄像机前面的屏幕中央。
- 当拖放到 Hierarchy 中的 no Parent Game Object 下时：在世界的原点。
- 当拖放到 Hierarchy 中的 Parent Game Object 下时：在父对象的变换处。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#the-visual-effect-inspector)The Visual Effect Inspector
#### General属性
Visual Effect Inspector 可帮助您配置 Visual Effect 的每个实例。它仅显示与此特定实例相关的值。

| Item               | 项目       | 描述                                                                                                                                                                                                               |
| ------------------ | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Asset Template     | 资产模板     | 引用 Unity 用于此实例的 Visual Effect Graph 的 Object Field。  <br>  <br>**New/Edit （新建/编辑**） 按钮允许您创建新的 Visual Effect Graph 资源或编辑当前资源。单击 **New/Edit** 时，Unity 会打开 Visual Effect Graph 资源，并将此场景实例连接到 Target Game Object 面板。 |
| Random Seed        | 随机种子     | 一个 Integer Field ，显示用于此实例的当前随机种子。**Reseed （重新设定种子**） 按钮会为此组件生成一个新的随机种子。                                                                                                                                          |
| Reseed On Play     | 重新设定播放种子 | 每次 Unity 将 Play Event 发送到 Visual Effect 时随机计算新种子的布尔设置。                                                                                                                                                           |
| Initial Event Name | 初始事件名称   | 允许 Unity 在启用时覆盖发送到组件的默认事件名称（字符串）。（默认 ： _OnPlay_ ）。                                                                                                                                                               |
#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#rendering-properties)Rendering属性
渲染属性控制视觉效果实例将如何渲染和接收照明。这些属性按实例存储在场景中，不会对 Visual Effect Graph 应用修改。

| Item                  | 项目    | 描述                                                                                                                                                                                                                      |
| --------------------- | ----- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Probes                |       |                                                                                                                                                                                                                         |
| Light Probes          | 光照探针  | 控制 Use of Light 探针来计算效果的 Ambient Lighting。                                                                                                                                                                              |
| Anchor Override       | 锚点覆盖  | （仅使用光照探针可见）：定义用于计算探针采样位置的替代变换。                                                                                                                                                                                          |
| Reflection Probes     | 反射探针  | 指定场景中的反射如何影响渲染器。仅当项目使用 Universal Render Pipeline 时，才会显示此属性。                                                                                                                                                             |
| Proxy Volume Override | 代理卷覆盖 | （仅使用光照探针的 Using Proxy Volume 选项可见）：定义替代光照探针代理体积，以便计算探针采样。                                                                                                                                                               |
| Additional Setting    |       |                                                                                                                                                                                                                         |
| Rendering Layer Mask  | 渲染层遮罩 | 此属性的功能因项目使用的渲染管线而异。  <br>• **High Definition Render Pipeline**：控制 Lighting Layer Mask（如果在 HDRP 资源中配置了它）。  <br>• **Universal Render Pipeline**：确定此渲染器位于哪个渲染层上。                                                           |
| Priority              | 优先权   | 控制效果的透明度顺序。仅当项目使用 High Definition Render Pipeline 时，才会显示此属性。                                                                                                                                                            |
| Sorting Layer         | 排序图层  | 指定 Renderer 的组等[SpriteRenderer （精灵渲染器）](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html)组件。                                                                                                                |
| Order in Layer        | 层中的顺序 | 指定 Renderer 的排序图层相对于其他排序图层的顺序[SpriteRenderer （精灵渲染器）](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html)组件。另请参阅[Renderer.sortingOrder](https://docs.unity3d.com/ScriptReference/Renderer-sortingOrder.html). |

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#instancing-properties)Instancing属性
实例化属性控制 [Instancing](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Instancing.html) 功能如何使用视觉效果实例。

| Item             | 项目    | 描述                                                     |
| ---------------- | ----- | ------------------------------------------------------ |
| Allow Instancing | 允许实例化 | 允许 Instancing 功能将此实例与其他实例作为一个批处理进行分组，以提高性能。默认为 _true_。 |

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#properties)Properties|性能
属性类别显示在 Visual Effect Graph Blackboard 中定义为 **Exposed Property 的任何属性**。每个属性都可以从其默认值中覆盖，以便自定义场景中的 Visual Effect 实例。某些属性也可以直接在场景中使用 Gizmo 进行编辑。

| Item                 | 项目         | 描述                                                                                                                                                                                                        |
| -------------------- | ---------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Show Property Gizmos | 显示属性 Gizmo | 切换用于设置某些公开属性（球体、盒体、圆柱体、变换、位置）的编辑小工具的显示。您可以使用每个 Gizmo 属性旁边的专用按钮来访问每个 Gizmo。                                                                                                                                |
| Properties           | 性能         | Visual Effect Graph 资源中已公开的所有属性。您可以编辑此 Visual Effect 实例的这些属性。有关更多信息，请参阅[公开的属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#exposed-properties-in-inspector) |

要访问属性值，请使用 Inspector 编辑它们，使用 [C# API](https://docs.unity3d.com/2019.3/Documentation/ScriptReference/VFX.VisualEffect.html) 或使用属性绑定器。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#the-play-controls-window)Play Controls 窗口
Play Controls （播放控件） 窗口显示 UI 元素，通过这些元素，您可以控制当前选定的 Visual Effect 实例。当选择 Visual Effect Game Object 时，它将显示在 Scene View 的右下角。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PlayControls.png)

播放 Controls Window 显示以下控件：
- 停止 （按钮） ：重置效果并将其状态设置为暂停。
- 播放/暂停（按钮） ：切换效果的暂停状态。
- 步长（按钮）：暂停效果并模拟一帧。
- Restart （Button） ：取消暂停效果，重置效果，并发送默认的播放事件。
- Rate （Int 滑块） ： 设置效果的播放速率（以百分比表示）
- 设置（弹出窗口） ：从菜单中设置效果的自定义播放速率。
- Show Bounds （Toggle） ：切换效果边界的可见性
- Show Event Tester （Toggle） ： 显示 Event Tester 实用程序窗口
- Play（） 和 Stop（） 按钮 ：将默认的 OnPlay 和 OnStop 事件发送到组件。
- （可选）小工具（弹出窗口） ：切换属性小工具的可见性。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#editing-properties-with-gizmos)使用 Gizmo 编辑属性
您可以在场景中使用 Gizmo 编辑某些属性。要启用 Gizmo 编辑，请单击 Inspector 中的 **Show Property Gizmos** 按钮。启用属性 Gizmo 后，可以使用 Gizmos 编辑的每个属性都将在可以使用 Gizmos 编辑的每个属性旁边显示 **Edit Gizmo** 按钮。

![属性 Gizmos Inspector](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PropertyGizmosInspector.png)