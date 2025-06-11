# 视觉效果边界
Unity 使用视觉效果的边界来确定是否渲染它。如果摄像机看不到效果的边界，则会剔除并且不会渲染效果。视觉效果中每个 System 的累积边界定义了视觉效果的边界。每个 System 的边界必须正确封装 System：
- 如果边界太大，则摄像机会处理视觉效果，即使屏幕上没有单个粒子。这会导致资源浪费。
- 如果边界太小，即使某些效果的粒子仍在屏幕上，Unity 也可能会剔除视觉效果。

可以在 [Visual Effect Asset Inspector](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html#visual-effect-asset-inspector) 中设置 **Culling Flags**。可以使用 [Profiling and Debug 面板](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/performance-debug-panel.html)了解系统的 [Culling 状态](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/performance-debug-panel.html#particle-system-info)

视觉效果中的每个 System 都会在 [Initialize 上下文中](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-Initialize.html)定义其边界。默认情况下，Recorded （录制） 模式处于启用状态，默认值用于设置边界，等待被录制覆盖，但您可以更改此行为并使用其他方法来定义边界。Initialize Context 的 **Bounds Setting Mode** 属性控制视觉效果使用的方法。边界计算方法有：
- **Manual**：直接在 Initialize Context 中设置边界。您可以使用 Operators 动态计算边界，并将输出发送到 Initialize Context 的 **Bounds** 输入端口。边界与 [AABox 类型的](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Type-AABox.html)运算符或属性兼容。
- **Recorded**：允许您从 VFX 控制面板录制系统。有关如何执行此操作的信息，请参阅 [边界录制](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/visual-effect-bounds.html#bounds-recording)。在此模式下，您还可以使用 Operators 计算边界并将其传递给 Initialize Context，就像在 **Manual** 中一样。这将覆盖任何记录的边界。
- **Automatic**：Unity 自动计算边界。注意：这将强制 VFX 资源的剔除标志为“Always recompute bounds and simulate”（始终重新计算边界和模拟）。自动边界计算可能会对性能产生负面影响，建议尽可能避免使用。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/Bounds-Init.png)

Initialize Context 还包含一个 **Bounds Padding** 输入端口。这是一个 Vector3，用于扩大 System 的每轴边界。如果系统使用 **Automatic** bounds 或在 **Recorded** 模式下进行录制，则 Unity 会在 Update Context 期间计算系统的边界。这意味着在 Output Context （输出上下文） 中对粒子的大小、位置、缩放或枢轴所做的任何更改都不会影响该帧期间的边界。向边界添加填充有助于减轻这种影响。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/visual-effect-bounds.html#bounds-recording)边界记录
Visual Effect Graph 窗口中的 [VFX Control 面板](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphWindow.html#vfx-control)包括 **Bounds Recording** 部分，可帮助您设置系统的边界。如果将 System 的 **Bounds Setting Mode** 设置为 **Recorded**，则该工具会在播放视觉效果时计算系统的边界。

您可以单击[工具栏](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphWindow.html#toolbar)右上角的图标以打开 VFX 控制面板。
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/ControlPanelIcon.png)

然后，您需要从[场景中附加 VFX](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GettingStarted.html#attaching-a-visual-effect-from-the-scene-to-the-current-graph) 才能正确使用 VFX 控制面板的功能。完成后，您可以单击红色的 recording 按钮开始记录边界以匹配您的粒子行为。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/Bounds-Not-Recording.png)
> Target Visual Effect GameObject 面板界面（不录制时）。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/Bounds-Recording.png)
> 录制时的 Target Visual Effect GameObject 面板界面。

您可以可视化录制器正在保存的边界。当录制器处于活动状态时，请查看 Scene 视图中的视觉效果。边界在视觉效果周围显示为一个红色框。如果要可视化特定系统的边界，请在工具窗口中选择它们或选择它们的 Initialize Context。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/bounds-preview.png)
> Unity 正在录制的边界的视觉效果和预览。

录制时，您可以 **暂停**、**播放**、**重新启动** 或事件更改**播放速率**。这使您能够加快录制速度或模拟各种生成位置。当您对计算的边界感到满意时，单击 **Apply Bounds （应用边界**） 将记录的边界应用于系统。可以在录制期间或之后应用录制的边界。要结束录制，请再次单击录制按钮。