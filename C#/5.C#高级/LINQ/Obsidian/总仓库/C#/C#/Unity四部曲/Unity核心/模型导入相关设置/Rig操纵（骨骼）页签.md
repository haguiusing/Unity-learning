
![[Pasted image 20240924214936.png]]
![[Pasted image 20240924215003.png]]
![[Pasted image 20240924215052.png]]
![[Pasted image 20240924215136.png]]
# Rig 选项卡

**Rig** 选项卡上的设置定义了 Unity 如何将变形体映射到导入模型中的网格，以便能够将其动画化。对于人形 (Humanoid) 角色，这意味着需要[分配或创建 Avatar](https://docs.unity3d.com/cn/current/Manual/ConfiguringtheAvatar.html)。对于非人形角色（_通用 (Generic)_ 角色），这意味着需要[在骨架中确定根骨骼](https://docs.unity3d.com/cn/current/Manual/GenericAnimations.html)。

默认情况下，在__项目__视图中选择模型时，Unity 会确定哪个__动画类型 (Animation Type)__ 与所选的模型最匹配，然后将其显示在 **Rig** 选项卡中。如果 Unity 从未导入该文件，则 Animation Type 设置为 __None__：

![无骨架映射](https://docs.unity3d.com/cn/current/uploads/Main/Rig-0.png)

无骨架映射

|**属性：**|   |**功能：**|
|---|---|---|
|**Animation Type**|   |指定动画类型。|
||**None**|不存在动画|
||**Legacy**|使用[旧版动画系统](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Rig.html#LegacyRig)。与 Unity 3.x 及更早版本一样导入和使用动画。|
||**Generic**|如果骨架为_非人形_（四足动物或任何要动画化的实体），请使用[通用动画系统](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Rig.html#GenericRig)。Unity 会选择一个根节点，但可以确定另一个用作__根节点__的骨骼。|
||**Humanoid**|如果骨架为_人形_（有两条腿、两条手臂和一个头），请使用[人形动画系统](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Rig.html#HumanoidRig)。Unity 通常会检测骨架并将其正确映射到 Avatar。有些情况下，可能需要更改 **Avatar 定义 (Avatar Definition)** 并手动对映射进行__配置 (Configure)__。|

## 通用动画类型

![骨架为非人形（四足动物或任何要动画化的实体）](https://docs.unity3d.com/cn/current/uploads/Main/Rig-1.png)

骨架为_非人形_（四足动物或任何要动画化的实体）

[通用动画](https://docs.unity3d.com/cn/current/Manual/GenericAnimations.html)不会像人形动画那样使用 Avatar。由于骨架可以是任意形状，必须指定哪个骨骼是__根节点 (Root node)__。通过使用根节点，Unity 可在通用模型的动画剪辑之间建立一致性，并在尚未“在正确位置”（即，整个模型在动画化时移动其世界位置的位置）制作的动画之间正确混合。

指定根节点有助于 Unity 区分骨骼相对于彼此的移动与根节点在世界中的运动（通过 [OnAnimatorMove](https://docs.unity3d.com/cn/current/ScriptReference/MonoBehaviour.OnAnimatorMove.html) 进行控制）。

|**属性：**|   |**功能：**|
|---|---|---|
|**Avatar Definition**|   |选择获取 Avatar 定义的位置。|
||**Create from this model**|根据此模型创建 Avatar|
||**Copy from Other Avatar**|指向另一个模型上设置的 Avatar。|
|**Root node**|   |选择要用作此 Avatar 的根节点的骨骼。  <br>  <br>仅当将 **Avatar Definition** 设置为 **Create From This Model** 时此设置才可用。|
|**Source**|   |复制另一个具有相同绑定的 Avatar 以导入其动画剪辑。  <br>  <br>仅当将 **Avatar Definition** 设置为 **Copy from Other Avatar** 时此设置才可用。|
|**Skin Weights**|   |Set the maximum number of bones that can influence a single vertex.|
||**Standard (4 Bones)**|使用最多四个骨骼来产生影响。这是默认值，出于性能考虑，建议使用此设置。|
||**Custom**|设置自定义的最大骨骼数量。  <br>  <br>选择此选项时，将显示 **Max Bones/Vertex** 和 **Max Bone Weight** 属性。|
|**Max Bones/Vertex**|   |定义每个顶点的最大骨骼数（以影响给定顶点）。可为每个顶点设置 1 到 32 个骨骼，但是用来影响顶点的骨骼数量越多，性能成本就越高。  <br>  <br>仅当将 **Skin Weights** 属性设置为 **Custom** 时此设置才可用。|
|**Max Bone Weight**|   |设置考虑骨骼权重的最低阈值。权重计算将忽略小于此值的任何值，并且 Unity 会将高于此值的骨骼权重放大为总计 1.0。  <br>  <br>仅当 **Skin Weights** 属性设置为 **Custom** 时此设置才可用。|
|**Optimize Game Object**|   |在 Avatar 和 Animator 组件中删除和存储所导入角色的游戏对象变换层级视图。如果启用此选项，角色的 SkinnedMeshRenderer 将使用 Unity 动画系统的内部骨架，因此可提高动画角色的性能。  <br>  <br>仅当 **Avatar Definition** 设置为 **Create From This Model** 时才可用。|
|**Extra Transforms to Expose**|   |指定已启用 **Optimize Game Object** 时希望 Unity 忽略的变换路径。有关更多信息，请参阅[包含额外变换](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Rig.html#ExtraTransforms)。  <br>  <br>仅当启用了 **Optimize Game Object** 时才会显示此部分。|

## 人形动画类型

![您的绑定是人形（有两条腿、两条手臂和一个头）](https://docs.unity3d.com/cn/current/uploads/Main/Rig-2.png)

您的绑定是_人形_（有两条腿、两条手臂和一个头）

除了极少数例外情况，人形模型具有相同的基本结构。此结构代表了身体的主要关节部位：头部和四肢。使用 Unity 的[人形动画功能](https://docs.unity3d.com/cn/current/Manual/ConfiguringtheAvatar.html)的第一步是[设置和配置](https://docs.unity3d.com/cn/current/Manual/class-Avatar.html) **Avatar**。Unity 使用 Avatar 将简化的人形骨骼结构映射到模型骨架中的实际骨骼。

|**属性：**|   |**功能：**|
|---|---|---|
|**Avatar Definition**|   |选择获取 Avatar 定义的位置。|
||**Create from this model**|根据此模型创建 Avatar|
||**Copy from Other Avatar**|指向另一个模型上设置的 Avatar。|
|**Source**|   |复制另一个具有相同骨架的 Avatar 以导入其动画剪辑。  <br>  <br>仅当 **Avatar Definition** 设置为 **Copy from Other Avatar** 时才可用。|
|**Configure…**|   |打开 [Avatar 配置](https://docs.unity3d.com/cn/current/Manual/class-Avatar.html)。  <br>  <br>仅当 **Avatar Definition** 设置为 **Create From This Model** 时才可用。|
|**Skin Weights**|   |对于人形角色模型和通用模型，此属性相同。请参阅上文中有关 [Skin Weights](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Rig.html#SkinWeights) 属性的文档以了解相关信息。|
|**Optimize Game Object**|   |在 Avatar 和 Animator 组件中删除和存储所导入角色的游戏对象变换层级视图。如果启用此选项，角色的 SkinnedMeshRenderer 将使用 Unity 动画系统的内部骨架，因此可提高动画角色的性能。  <br>  <br>仅当 **Avatar Definition** 设置为 **Create From This Model** 时才可用。|
|**Extra Transforms to Expose**|   |指定已启用 **Optimize Game Object** 时希望 Unity 忽略的变换路径。有关更多信息，请参阅[包含额外变换](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Rig.html#ExtraTransforms)。  <br>  <br>仅当启用了 **Optimize Game Object** 时才会显示此部分。|

## 包含额外变换

启用 **Optimize Game Object** 属性时，Unity 将忽略属于层级视图但未映射在 Avatar 中的任何变换，以便提高 CPU 性能。但可以使用 **Extra Transforms to Expose** 部分来标记游戏对象层级视图中的特定节点以纳入到计算中：

![启用 Optimize Game Objects 选项时将显示 Extra Transforms to Expose 属性](https://docs.unity3d.com/cn/current/uploads/Main/ExtraTransforms.png)

启用 Optimize Game Objects 选项时将显示 Extra Transforms to Expose 属性

**(A)** 在搜索框中输入全名或部分名称以过滤变换列表。这样可以更轻松地浏览具有大量骨骼的角色。

**(B)** 启用希望 Unity 在计算中包含的每个变换（骨架的骨骼）。

**(C)** 使用按钮有助于选择特定变换。例如，__Toggle All__ 按钮可以一次选择或取消选择所有内容（无论当前选择如何，包括过滤的项）。

**(D)** 使用 **Revert** 按钮可以撤消所做的选择，或使用 **Apply** 按钮对模型应用例外条件。

**注意**：在优化模式下，蒙皮网格矩阵提取是多线程操作。

## 旧版动画类型

![您的绑定使用旧版动画系统](https://docs.unity3d.com/cn/current/uploads/Main/Rig-3.png)

您的绑定使用旧版动画系统

|**属性：**|   |**功能：**|
|---|---|---|
|**Generation**|   |选择动画导入方法。|
||**Don’t Import**|不导入动画|
||**Store in Original Roots (Deprecated)**|已弃用。请勿使用。|
||**Store in Nodes (Deprecated)**|已弃用。请勿使用。|
||**Store in Root (Deprecated)**|已弃用。请勿使用。|
||**Store in Root (New)**|导入动画并将其存储在模型的根节点中。这是默认设置。|
|**Skin Weights**|   |请参阅上文中有关 [Skin Weights](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Rig.html#SkinWeights) 属性的文档以了解此属性的相关信息。|

有关旧版动画的详细信息，请参阅[旧版动画系统](https://docs.unity3d.com/cn/current/Manual/Animations.html)的文档。

---

- 在 [2019.1](https://docs.unity3d.com/2019.1/Documentation/Manual/30_search.html?q=newin20191) 中添加了 **Skin Weights**
- [2017.2](https://docs.unity3d.com/2017.2/Documentation/Manual/30_search.html?q=newin20172) 中添加了 **Materials** 选项卡

# Avatar Mapping 选项卡

当 Unity 编辑器处于化身配置模式时，Avatar Mapping 选项卡可用。

要进入化身配置模式，请执行以下任一操作：

- 在 Project 窗口中选择 Avatar Asset，然后在 Inspector 中单击 “Configure Avatar”，或
    
- 在 Project 窗口中选择 Model Asset，在 Inspector 中转到 “Rig” 选项卡，然后单击 Avatar Definition 菜单下的 “Configure…”。
    

进入化身配置模式后，__Inspector__ 内将显示 **Avatar Mapping** 选项卡，其中显示 Unity 的骨骼映射：

![Avatar 窗口显示了骨骼映射](https://docs.unity3d.com/cn/current/uploads/Main/classAvatar-Inspector.png)

Avatar 窗口显示了骨骼映射

**(A)** 通过这些按钮在 **Mapping** 和 **Muscles & Settings** 选项卡之间进行切换。在选项卡之间切换之前，必须对所做的更改执行 **Apply** 或 **Revert** 操作。

**(B)** 通过这些按钮在 Avatar 的部位之间进行切换：__Body**、**Head**、**Left Hand__ 和 **Right Hand**。

**(C)** 这些菜单提供各种 **Mapping** 和 **Pose** 工具来帮助您将骨骼结构映射到 Avatar。

**(D)** 通过这些按钮接受所做的更改 (**Accept**)、放弃更改 (**Revert**) 以及离开 Avatar 窗口 (**Done**)。在离开 **Avatar** 窗口之前，必须对所做的更改执行 **Apply** 或 **Revert** 操作。

Avatar Mapping（Avatar 映射）指示哪些骨骼是必需的（实线圆圈）和哪些骨骼是可选的（虚线圆圈）。Unity 可自动插入可选的骨骼移动。

## 保存和重用 Avatar 数据（人体模板 (Human Template) 文件）

您可以将骨架中的骨骼映射保存到磁盘上的 Avatar 作为[人体模板（Human Template）文件](https://docs.unity3d.com/cn/current/Manual/class-HumanTemplate.html)（扩展名为 `*.ht`）。您可以对任何角色重用此映射。例如，您希望通过源代码控制 Avatar 映射，并提交基于文本的文件；或者希望使用自己的自定义工具来解析文件。

要将 Avatar 数据保存到人体模板文件，请从 **Avatar** 窗口底部的 **Mapping** 下拉菜单中选择 **Save**。

![Avatar 窗口底部的 Mapping 下拉菜单](https://docs.unity3d.com/cn/current/uploads/Main/MecanimMappingMenus.png)

**Avatar** 窗口底部的 **Mapping** 下拉菜单

Unity 将显示一个对话框，可在其中选择要保存的文件的名称和位置。

![](https://docs.unity3d.com/cn/current/uploads/Main/classHumanTemplate-Project.png)

要加载先前创建的人体模板文件，请选择 **Mapping** > __Load__，然后选择要加载的文件。

## 使用 Avatar 遮罩

有时，将动画限制为特定的身体部位会很有用。例如，在一个行走动画中，角色可能会挥动他们的手臂，但如果他们拿起火炬，他们应该将火炬举起来投光。您可以使用 **Avatar 身体遮罩 (Avatar Body Mask)** 来指定应将动画限制在角色的哪些部位。请参阅有关 [Avatar 遮罩](https://docs.unity3d.com/cn/current/Manual/class-AvatarMask.html)的文档以了解更多详细信息。

# Avatar Muscle & Settings 选项卡

Unity 的动画系统允许使用__肌肉 (Muscles)__ 控制不同骨骼的运动范围。

[正确配置](https://docs.unity3d.com/cn/current/Manual/class-Avatar.html) Avatar 后，动画系统可“理解”骨骼结构，并允许使用 **Avatar** Inspector 的 **Muscles & Settings** 选项卡。使用 **Muscles & Settings** 选项卡可调整角色的运动范围，并确保角色以逼真的方式变形，而不出现视觉瑕疵或自我重叠。

![Avatar 窗口中的 Muscles &amp; Settings 选项卡](https://docs.unity3d.com/cn/current/uploads/Main/MecanimAvatarMuscles.png)

**Avatar** 窗口中的 **Muscles & Settings** 选项卡

**Muscle & Settings** 选项卡具有以下区域：

**(A)** 通过这些按钮在 **Mapping** 和 **Muscles & Settings** 选项卡之间进行切换。在选项卡之间切换之前，必须对所做的更改执行 **Apply** 或 **Revert** 操作。

**(B)** 通过 **Muscle Group Preview** 区域可使用预定义的变形来操作角色。这些设置一次影响多个骨骼。

**(C)** 使用 **Per-Muscle Settings** 区域可调整身体的各个骨骼。可以展开这些肌肉设置以便更改每项设置的范围限制。例如，默认情况下，Unity 会将 Head-Nod 和 Head-Tilt 设置的范围设置为 –40 到 40 度，可以进一步减小这些范围以增加这些动作的刚度。

**(D)** 使用 **Additional Settings** 可调整身体的特定特效。

**(E)** **Muscles** 菜单提供了 **Reset** 工具，可将所有肌肉设置恢复到默认值。

**(F)** 通过这些按钮接受所做的更改 (**Accept**)、放弃更改 (**Revert**) 以及离开 Avatar 窗口 (**Done**)。在离开 **Avatar** 窗口之前，必须对所做的更改执行 **Apply** 或 **Revert** 操作。

## 预览更改

对于 **Muscle Group Preview** 和 **Per-Muscle Settings** 区域中的设置，可直接在 **Scene** 视图中预览所做的更改。可以拖动滑动条来查看应用于角色的每项设置的移动范围：

![在 Scene 视图中预览肌肉设置的更改](https://docs.unity3d.com/cn/current/uploads/Main/MuscleDefinitions-SceneView.png)

在 Scene 视图中预览肌肉设置的更改

可以通过网格查看骨架的骨骼。

## 移动自由度 (Degree of Freedom, DoF)

可以在 **Additional Settings** 中启用 **Translate DoF** 选项，从而启用人形角色的移动动画。如果禁用此选项，则 Unity 仅使用旋转对骨骼进行动画化。**Translation DoF** 可用于 Chest、UpperChest、Neck、LeftUpperLeg、RightUpperLeg、LeftShoulder 和 RightShoulder 的肌肉。

**注意：**启用 **Translate DoF** 可能会提高性能要求，因为动画系统需要执行额外的步骤来重新定位人形动画。因此，在已知动画包含角色某些骨骼的动画式移动时，才应启用此选项。