# **1.布局**
Unity编辑器右上角可以修改布局，也可以自己拖动。右上角可以快速布局，例如Tall、双屏、四屏等等
![](https://developer.qcloudimg.com/http-save/yehe-9094469/7ddee4987e67e3a264cc978ee2fabce1.png)
或者自己可以对布局进行一系列设置以后，然后保存为自己的习惯性操作的布局模板。选择右上角-Save Layout,即可保存成你的自定义模板。后续你操作期间布局搞乱了，就可以一键还原你配置的布局模板了。
![](https://developer.qcloudimg.com/http-save/yehe-9094469/f5caf4a6f41a5bb5ffce9be9bde7a0ff.png)

在布局栏可以看到自己配置的自定义布局模板
![](https://developer.qcloudimg.com/http-save/yehe-9094469/4dd7c95d904bb059b59480fcbd80007e.png)
# **2.Hierarchy层级窗口**[Hierarchy 窗口 - Unity 手册](https://docs.unity.cn/cn/2021.3/Manual/Hierarchy.html)[[Hierarchy窗口知识点]]
![[Pasted image 20240829130101.png]]![[Pasted image 20240829130235.png]]![[Pasted image 20240829130255.png]]窗口中常使用的快捷键：
F2：给对象改名
Ctrl+C复制（通过复制得到的对象不会出现父子关系，父子关系将在其它篇幅讲解）
Ctrl+V粘贴
Ctrl+D克隆一个对象（相当于实现了复制粘贴两种功能）
Delete删除
Ctrl+Z撤销操作

当然，如果你不想通过快捷键操作或者你忘记了快捷键的使用，你可以鼠标点击对象：
Copy复制
Paste粘贴
Rename改名
Duplicate克隆
# **3.Scene场景窗口**[[Scence窗口知识点]]
我们在Scene窗口中，查看所有游戏对象，设置所有游戏对象。
![[Pasted image 20240829130839.png]]
## 绘制模式 (Draw mode) 菜单

第一个下拉菜单选择要用于描绘场景的__绘制模式__。可用选项为：
![[Pasted image 20240829131102.png]] 
## **2D lighting and Audio switches**
在 Render Mode 菜单的右侧有三个按钮，用于打开或关闭 Scene 视图的某些选项：
2D：在场景的 2D 和 3D 视图之间切换。在 2D 模式下，摄像机朝向正 z 方向，x 轴指向右方，y 轴指向上方。
Lighting：打开或关闭 Scene 视图光照（光源、对象着色等）。
Audio：打开或关闭 Scene 视图音频效果。
## 辅助线及自定义工具
![[Pasted image 20240829132619.png]]  可调节辅助线的透明度
### 使用自定义 Editor 工具

从 [Scene 视图](https://docs.unity.cn/cn/2021.3/Manual/UsingTheSceneView.html)中可以访问使用[工具模式 API](https://docs.unity.cn/2019.1/Documentation/ScriptReference/EditorTools.EditorTool.html) 创建的自定义工具。您可以通过以下方式来访问自定义工具：

- Clicking the [**Available Custom Editor Tools** drop-down menu](https://docs.unity.cn/cn/2021.3/Manual/UsingCustomEditorTools.html#ToolModesAccessSceneViewToolbar) in the Scene view Tool toolbar Overlay.
    
- Opening the [Tools Settings toolbar Overlay](https://docs.unity.cn/cn/2021.3/Manual/Overlays).
    

![Custom Editor tools are available from a menu in the Scene view Tools toolbar Overlay](https://docs.unity.cn/cn/2021.3/uploads/Main/ToolModesExample.png)

Custom Editor tools are available from a menu in the Scene view Tools toolbar Overlay

#### 全局工具与上下文工具

有些自定义工具是全局性的，而有些则是依赖于上下文：

- 全局工具会影响任何类型的游戏对象，并且无论您选择哪种类型的游戏对象，全局工具都始终可用。例如，变换组件工具可用于任何游戏对象，因此始终可供访问。
    
- 上下文自定义工具仅影响特定类型的游戏对象，并且仅在您选择该类型的游戏对象时才可用。例如，仅当选择了光源时，才可以访问光源的自定义操控器。
    

#### 从 Scene 视图工具栏中激活自定义 Editor 工具

要激活自定义 Editor 工具，请右键单击 Scene 视图工具栏中的 **Available Custom Editor Tools** 按钮。

![](https://docs.unity.cn/cn/2021.3/uploads/Main/ToolmodesMenu.png)

此时将打开一个菜单，并分为以下几个部分：

- A. **Recent**：列出最近使用过的全局工具。  
      
    只有在当前会话中首次激活全局工具时，才会出现此部分。
    
- B. **Selection**：列出可影响当前所选的一个或多个游戏对象的上下文工具。  
      
    如果项目中没有影响所选对象的自定义工具，则不会出现此部分。
    
- C. **Available**：列出所有可用的全局工具。  
      
    只要项目包含自定义工具，此部分就会始终出现。
    

If the Project does not contain any custom tools, the menu will not have the custom tools icon.

从菜单中选择工具后，**Available Custom Editor Tools** 按钮将变为选定工具的图标。

![从菜单中选择 Custom Transform Tool 后，该工具的图标将显示在 Scene 视图工具栏中](https://docs.unity.cn/cn/2021.3/uploads/Main/ToolmodesMenuSelected.png)

从菜单中选择 Custom Transform Tool 后，该工具的图标将显示在 Scene 视图工具栏中

#### 从 Component Editor Tools 面板中激活上下文工具

The Component Editor Tools appear in the Tools Settings toolbar Overlay in the main Scene view window.

![](https://docs.unity.cn/cn/2021.3/uploads/Main/ToolmodesPopup.png)

The Tool Settings toolbar contains all contextual custom tools that affect one or more selected GameObjects. It updates automatically whenever the selection changes.

- 单击一个按钮以激活一个工具。

---

- 在 [2019.1](https://docs.unity.cn/2019.1/Documentation/Manual/30_search.html?q=newin20191) 中添加了 Available Custom Editor Tools 按钮和 Component Editor Tools 面板

## Effects button and menu
The menu (activated by the icon to the right of the **Audio** button) has options to enable or disable rendering effects in the Scene view.
菜单（由 **Audio** 按钮右侧的图标激活）包含用于在 Scene 视图中启用或禁用渲染效果的选项。
- **Skybox**：在场景的背景中渲染的天空盒纹理
- **Fog**：视图随着与摄像机之间的距离变远而逐渐消褪到单调颜色。
- **Flares**：光源上的镜头光晕。
- **Always Refresh**：定义动画化的材质是否显示动画。选中后，任何基于时间的效果（例如，着色器）都将成为动画。例如，场景效果（如在地形上舞动的草）。
- **后期处理**：添加[后期处理](https://docs.unity.cn/cn/2021.3/Manual/PostProcessingOverview.html)效果。
- **粒子系统**：显示 [粒子系统](https://docs.unity.cn/cn/2021.3/Manual/ParticleSystems.html)效果。
## 场景可见性开关
The Scene visibility switch toggles Scene visibility for GameObjects on and off. When it’s on, Unity applies the Scene visibility settings. When it’s off, Unity ignores them.
Scene visibility 开关用于打开和关闭游戏对象的 Scene visibility 。启用后，Unity 会应用 Scene visibility 设置。关闭后，Unity 会忽略它们。

如需了解更多信息，请参阅[场景可见性](https://docs.unity.cn/cn/2021.3/Manual/SceneVisibility.html)文档。
## Camera settings menu
摄像机设置菜单包含用于配置 Scene 视图摄像机的选项。如需了解更多信息，请参阅[摄像机设置](https://docs.unity.cn/cn/2021.3/Manual/SceneViewCamera.html)文档。
## Gizmos 菜单
The Gizmos menu contains options for how objects, icons, and gizmos are displayed. This menu is available in both the Scene view and the [Game view](https://docs.unity.cn/cn/2021.3/Manual/GameView.html). See documentation on the [Gizmos Menu](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html) manual page for more information.
Gizmos 菜单包含有关对象、图标和 Gizmo 显示方式的选项。此菜单在 Scene 视图和 [Game 视图中](https://docs.unity.cn/cn/2021.3/Manual/GameView.html)均可用。有关更多信息，请参阅 [Gizmos Menu](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html) 手册页上的文档。
- 在 [2019.1](https://docs.unity.cn/2019.1/Documentation/Manual/30_search.html?q=newin20191) 中添加了场景可见性开关
- 在 2019.1 中添加了 Scene 视图摄像机设置
- 在 2019.1 中添加了 Component Editor Tools 面板开关
- Toolbar moved to Overlays in 2021.2
## 搜索
搜索场景中物体并高亮，拥有一些特殊写法
## Scene 视图导航

## Position GameObjects

## Overlays

## 场景中的操作
![[Pasted image 20240829142342.png]]