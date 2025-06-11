## Converting a Project from the Built-in Renderer to the High Definition Render Pipeline / 将项目从内置渲染器转换为高清[渲染管线](https://so.csdn.net/so/search?q=%E6%B8%B2%E6%9F%93%E7%AE%A1%E7%BA%BF&spm=1001.2101.3001.7020)
高清晰度渲染管线（HDRP）使用了一组新的[着色器](https://docs.unity3d.com/Manual/class-Shader.html)和[照明单元](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Physical-Light-Units.html)，两者均与内置渲染器不兼容。 要将Unity项目升级到HDRP，您必须首先转换所有的[材质](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Upgrading-To-HDRP.html#MaterialConversion)和阴影，然后相应地调整各个[灯光](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Upgrading-To-HDRP.html#LightAdjustment)设置。

本文档说明了如何将**3D With Extras**模板项目转换为HDRP，但是您可以使用相同的工作流程来转换自己的项目。 要遵循本文档并升级**3D With Extras**项目，请创建一个使用**3D With Extras**模板的项目。 去做这个：
1. 打开Unity Hub。
2. 在项目选项卡中，选择【新建】。
3. 在模板选择种选择 **3D With Extras**。
4. 输入项目名称并设置Unity的位置以将项目保存到该位置。
5. 单击【创建】。
6. Unity编辑器将打开，如下所示：  
    ![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/c760a06c7ecb03231b75b3a388704be7.png#pic_center)

## Setting up HDRP / 设置HDRP
首先，要安装HDRP，请将High Definition RP软件包添加到Unity项目中：
1. 在Unity编辑器里打开包管理器（Package Manager）窗口:(menu: Window > Package Manager)
2. 找到并选择 **High Definition RP**包，然后点击安装（Install）

现在可以在项目中使用HDRP。 请注意，当您安装HDRP时，Unity会自动将两个特定于HDRP的组件附加到场景中的GameObjects。 它将**HD Additional Light Data**组件附加到Lights，并将**HD Additional Camera Data**组件附加到Cameras。 如果未将项目设置为使用HDRP，并且场景中存在任何HDRP组件，则Unity会引发错误。 要解决这些错误，请参阅以下有关如何在Project中设置HDRP的说明。

要设置HDRP，请使用“[渲染管道向导](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Render-Pipeline-Wizard.html)”。详情跳转：[[Lesson3_High Definition Render Pipeline Wizard]]
1. 打开渲染管道窗口(menu **Window > Render Pipeline > HD Render Pipeline Wizard**)
2. 在**Configuration Checking**部分中，转到**HDRP**选项卡，然后单击**Fix All**。 这可以解决项目中的每个HDRP配置问题。

现在已在您的项目中设置了HDRP，但是您的场景无法正确渲染，并使用洋红色错误[着色器](https://so.csdn.net/so/search?q=%E7%9D%80%E8%89%B2%E5%99%A8&spm=1001.2101.3001.7020)显示GameObjects。 这是因为场景中的GameObjects仍使用为内置渲染器制作的着色器。 若要了解如何将内置着色器升级到HDRP着色器，请参阅“[升级材质](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Upgrading-To-HDRP.html#MaterialConversion)”部分。  
HDRP已经有了自己的[后处理](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Post-Processing-Main.html)实现，不再支持后处理包。 如果要转换**3D With Extras**项目，或者您自己的项目使用“后处理”包，请从项目中删除“后处理”包。 去做这个：
1. 在Unity编辑器里打开包管理器（Package Manager）窗口:(menu: Window > Package Manager)  
    2。 找到并选择 **Post Processing**包，然后点击移除（Remove）

有关如何向模板项目添加和自定义后期处理效果的详细信息，请参见[后期处理](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Upgrading-To-HDRP.html#Post-processing)部分。

## Upgrading Materials / 升级材质
要将场景中的材质升级为与HDRP兼容的材质，请执行以下任一操作：
- **Upgrade Project Materials to High Definition Materials**：将项目中的每个兼容材质转换为 HDRP 材质。
    
- **Upgrade Selected Materials to High Definition Materials**：将 Project 窗口中当前选定的每个兼容材质转换为 HDRP 材质。
    
- **Upgrade Scene Terrains to High Definition Terrains**：将场景中每个[地形](https://docs.unity3d.com/Manual/script-Terrain.html)中的内置默认标准地形材质替换为 HDRP 默认地形材质。
- 
    ![[Pasted image 20241022185236.png]]

您可以在以下任一位置找到这些选项：
- 菜单栏种打开：**Edit > Render Pipeline 。
- Edit > Render Pipeline里面拥有HD Render Pipeline Wizard窗口内的部分用于快速迁移项目的按钮链接
- HD Render Pipeline Wizard 窗口打开：（Window>Render Pipeline>HD Render Pipeline Wizard）

此过程无法自动将自定义材质或着色器升级到HDRP。 您必须手动转换自定义材质和自定义着色器。

### Converting Materials manually / 手动转换材质
HDRP材质转换器自动将内置的标准材质和非发光材质分别转换为HDRP发光材质和非发光材质。这个过程使用叠加功能将颜色通道混合在一起，类似于在Photoshop等图像编辑软件中使用的过程。为了帮助您手动转换自定义材质，本节将描述从内置材质创建的材质的转换器的映射。

### Mask Map
内置着色器到HDRP着色器的转换过程中将内置标准着色器的不同材质贴图分别合并合并到“ HDRP [Lit Material](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Lit-Shader.html)”中的Mask Map的分别的RGBA通道中。有关每个贴图进入哪个颜色通道的信息，请参见[Mask Map](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Mask-Map-and-Detail-Map.html#MaskMap)。

### Detail maps
内置着色器到HDRP着色器的转换过程将内置标准着色器的不同Detail maps组合到HDRP [Lit Material](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Lit-Shader.html)中Detail maps的分别的RGBA通道中。 它还增加了平滑度细节。 有关每个贴图进入哪个颜色通道的信息，请参见[Detail maps](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Mask-Map-and-Detail-Map.html#DetailMap)。

## Adjusting lighting / 调整灯光照明
HDRP使用[物理光单元](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Physical-Light-Units.html)来控制光的强度。 这些单位与内置渲染管线使用的任意单位都不匹配。

对于光强度单位，定向光源使用[勒克斯(Lux)](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Physical-Light-Units.html#Lux)，所有其他光源可以使用[流明(Lumen)](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Physical-Light-Units.html#Lumen)，[坎德拉(Candela)](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Physical-Light-Units.html#Candela)，EV或模拟一定距离的勒克斯(Lux))。

要在HDRP项目中设置照明，请执行以下操作：
1. 将默认的Sky [Volume](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Volumes.html)添加到场景中以设置环境照明(menu: **Window > Rendering > Lighting Settings**)。
    
2. 将 [Environment Lighting](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Environment-Lighting.html) 设置为使用新的sky:
    
    1. 打开照明窗口 (menu: **Window > Rendering > Lighting Settings**)
    2. 对于**Profile**属性，选择 Sky and Fog Volume使用的相同的 [Volume Profile](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Volume-Profile)。
    3. 对于**Static Lighting Sky**属性，选择**PhysicallyBasedSky**。
    4. （可选）如果您不希望Unity在本节中进行其余更改时重新烘烤场景的灯光，则可以禁用窗口底部的**Auto Generate**复选框
3. 当前，阴影质量很差。要提高其质量，可以更改阴影属性：
    
    1. 新建一个**Global Volume**物体 (**menu: GameObject > Volume > Global Volume**)，并将其命名为**Global Settings**
    2. 为新建的这个Volume 创建一个新的Volume Profile。为此，请打开该Volume的Inspector面板 ，然后单击 【新建（New）】按钮。
    3. 添加一个**Shadows** override (**Add Override > Shadowing > Shadows**),启用**Max Distance**并将其设置为50
4. 在表示太阳光（这是定向光游戏对象上的光组件 Directional Light）上，将Intensity （强度）设置为100000，将Color(颜色)设置为白色。 然后，要查看天空中的太阳，请转到General (常规)面板，启用More Options(更多选项)，并将Angular Diameter(角直径),设置为3。
    
5. 场景现已经曝光过度。 要解决此问题，请选择在步骤**3a**中创建的**Global Settings **游戏对象(GameObject))，然后向其Volume 组件(component )添加**Exposure** override替代（**Add Override > Exposure**）。 然后，将**Mode**设置为**Automatic**。
    
6. 要刷新exposure，请转到Scene视图并启用**Animate Materials**。  
    ![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/8a99d86eab8a05f4ac3525e44cafe08f.png#pic_center)
    
7. 纠正Light cookie，因为HDRP支持彩色light cookie，而内置light cookie使用仅包含alpha的纹理格式：
    
    1. 在Project窗口，选择 **Assets > ExampleAssets> Textures > Light_Cookies > Spotlight_Cookie**。
    2. 在Inspector窗口，将**Texture Type **从**Cookie**改为**Default**。
    3. 设置**Wrap Mode**为**Clamp**。
8. 修复construction Light:
    
    1. 在**Hierarchy**窗口，选择**ExampleAssets > Props > ConstructionLight > Spot Light**并在Inspector窗口查看灯光组件（Light）
    2. 改变**Intensity(强度)**到**17000 Lumen(流明)**，这代表两个8500流明灯泡。
    3. 在**Emission**部分，启用**More Options**。
    4. 开启**Reflector**复选框，这模拟了聚光灯后面的反射表面来调整视觉强度。
9. 制作一个灯泡发光材质
    
    1. 在Project窗口，选择**Assets/ExampleAssets/Materials/Lightbulb_Mat.mat**
    2. 在Inspector窗口的**Emission Inputs**部分，启用**Use Emission Intensity**，设置**Emissive Color**为白色，设置**Emission Intensity**为  
        **8500 Luminance**
    3. 最后，如果你在第二个步骤里禁用了**Auto Generate**，你可以前往Lighting窗口点击**Generate Lighting** ，也可以重新启用**Auto Generate**

## Post-processing /后处理

HDRP不再支持**Post Processing**包，而是自己做了[后期处理的实现](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Post-Processing-Main.html)，要将场景转换为HDRP后处理：
1. 在Hierarchy窗口，删除**Post-process Volume**游戏物体（GameObject）
    
    1. 如果你的项目里使用了后处理包API编辑了后处理效果，你需要更新你的脚本，使用心得后处理效果。
2. 创建一个新的**Global Volume**游戏物体(GameObject)(**menu: GameObject > Volume > Global Volume**)并且将其重命名为**Post-processing**，选择这个GameObject在Inspector窗口，制定好Profile字段属性后，你可以通过点击**Add Override**在**Post-processing**中看到所有后处理效果。
    
3. 添加一个**Tonemapping** override到Volume(**Add Override > Post-processing > Tonemapping**),然后启用**Mode**并且将它设置为**ACES**
    
4. 添加一个**Bloom** override到Volume(**Add Override > Post-processing > Bloom**)，然后启用 **Intensity**(强度)并且设置为0.2，请注意，Bloom的结果和Post Processing包的结果有些不一样，这是因为HDRP的Bloom效果在物理上是准确的，并且正确模拟相机镜头的光晕效果。
    
5. 添加一个**Motion Blur**(运动模糊) override到Volume(**Add Override > Post-processing > Motion Blur**)然后启用**Intensity**(强度)并且设置为0.1
    
6. 添加一个**Vignette** override到Volume(**Add Override > Post-processing > Vignette**)然后设置以下属性的值：
    
    1. 启用**Intensity**并且设置值为**0.55**。
    2. 启用**Smoothness**并且设置值为**0.4**。
    3. 启用**Roundness**并且设置值为**0**。
7. 添加一个**Depth Of Field override**(景深)到Volume(**Add Override > Post-processing > Depth Of Field**)然后设置以下属性的值：
    
    1. 启用**Focus Mode**(对焦模式)并且设置为**Manual**(手动)。
    2. 在**Near Blur**(近景模糊)部分，启用**Start**并且设置它为**0**，然后启用**End**并且设置值为**0.5**。
    3. 在**Far Blur**(远景模糊)部分，启用Start并且设置值为2，然后启用End并且设置值为10，请注意，这个视觉效果仅限于Game窗口视图可以看见。
8. 最后，选择**Global Settings** GameObject(游戏物体)在Inspector窗口里查看，在Volume组件，添加一个**Ambient Occlusion**(环境光遮蔽)override(**Add Override > Lighting > Ambient Occlusion**)，然后启用**Intensity**并且设置值为0.5。
    

## Result
现在的场景，游戏窗口视图看起来应该像这样：
![[Pasted image 20241022184239.png]]