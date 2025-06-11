# Game 视图

![](https://docs.unity.cn/cn/2021.3/uploads/Main/game-view-window.png)

从应用程序中的摄像机渲染 Game 视图。该视图代表最终发布的应用程序。需要使用一个或多个摄像机来控制玩家在使用应用程序时看到的内容。有关摄像机的更多信息，请参阅[摄像机组件页面](https://docs.unity.cn/cn/2021.3/Manual/class-Camera.html)。

## 播放模式

![](https://docs.unity.cn/cn/2021.3/uploads/Main/Editor-PlayButtons.png)

1.引擎内运行游戏
2.暂停游戏
3.逐帧运行
Use the buttons in the Toolbar to control the Editor Play mode and see how your published application plays. In Play mode, any changes you make are temporary, and are reset when you exit the Play mode. The Editor UI darkens to remind you of this.
使用 Toolbar 中的按钮来控制 Editor Play 模式，并查看已发布的应用程序的播放方式。在 Play 模式下，您所做的任何更改都是临时的，当您退出 Play 模式时，这些更改将被重置。Editor UI 变暗以提醒您这一点。

## Using the Game view

To open the Game view, do one of the following:
要打开 Game （游戏） 视图，请执行以下操作之一：

- In the **Game** tab, on the top left corner, use the drop-down menu to click **Game view** if [Simulator view](https://docs.unity.cn/cn/2021.3/Manual/device-simulator-view.html) is open.
- In the menu: **Window** > **General** > **Game**.
- 在 **Game** 选项卡的左上角，如果 [Simulator 视图](https://docs.unity.cn/cn/2021.3/Manual/device-simulator-view.html)已打开，请使用下拉菜单单击 **Game view**。
- 在菜单中：**Window** > **General** > **Game**。
## Game 视图控制栏

![](https://docs.unity.cn/cn/2021.3/uploads/Main/GameViewControlBar.png)

| **按钮**               |                                  | **功能**                                                                                                                                                                     |
| -------------------- | -------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Game/Simulator**   |                                  | Click to enable the **Game** or **Simulator** view from the drop-down menu.<br>单击以从下拉菜单中启用 **Game** 或 **Simulator** 视图。                                                    |
| **Display/显示屏**      |                                  | 如果场景中有多个摄像机，可单击选择此按钮从摄像机列表中进行选择。默认情况下，此按钮设置为 **Display 1**。可以在摄像机模块中的 **Target Display** 下拉菜单下将显示分配给摄像机。                                                                   |
| **Aspect/分辨率**       |                                  | 可选择不同值来测试游戏在具有不同宽高比的显示器上的显示效果。默认情况下，此设置为 **Free Aspect**。                                                                                                                  |
|                      | **x:y**                          | 类似该格式的选项代表Game视图的宽高比。（当你选择宽高比，然后又勾选了Low Res…屏幕会模糊哦~）                                                                                                                       |
|                      | **NNNNxMMMM**                    | 类似该格式的选项代表Game视图的**分辨率**，一般我用1080x1920开发                                                                                                                                   |
|                      | **小加号**                          | 如果选项中没有你满意的视图样式，你可以点击小加号**自定义一个视图样式**                                                                                                                                      |
|                      | **Low Resolution Aspect Ratios** | 启用 **Low Resolution Aspect Ratios** 可模拟更旧显示屏的像素密度：选择宽高比后，此功能会降低 Game 视图的分辨率。Game 视图位于非 Retina 显示屏上时，此复选框始终处于启用状态。                                                          |
|                      | **VSync (Game view only)/垂直同步**  | 启用 **VSync (Game view only)** 可为 Game 视图指定优先级。此选项可能会添加一些垂直同步，例如，在录制视频时可以使用此选项。Unity 会尝试以监视器刷新率渲染 Game 视图，但不能保证这一点。启用此选项后，在运行模式下最大化 Game 视图仍然很有用，可以隐藏其他视图并减少 Unity 渲染的视图数量。 |
| **Scale 滑动条**        |                                  | 向右滚动可放大并更详细地检查游戏屏幕的区域。设备分辨率高于 Game 视图窗口大小的情况下，此滑动条可缩小视图以查看整个屏幕。在应用程序停止或暂停时，也可以使用滚轮和鼠标中键来执行此操作。                                                                             |
| **Maximize on Play** |                                  | 单击按钮启用：进入运行模式时，使用此按钮可使 Game 视图最大化（Editor 窗口的 100%）以便进行全屏预览。                                                                                                                |
| **Mute audio**       |                                  | 单击按钮启用：进入运行模式时，使用此按钮可将任何应用程序内的音频静音。                                                                                                                                        |
| **Stats**            |                                  | 单击此按钮可以切换 Statistics 覆盖层，其中包含有关应用程序音频和图形的[渲染统计信息](https://docs.unity.cn/cn/2021.3/Manual/RenderingStatistics.html)。这对于在运行模式下监控应用程序性能非常有用。                                  |
| **Gizmos**           |                                  | 单击此按钮可切换[辅助图标](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html)的可见性。要在运行模式下仅查看某些类型的辅助图标，请单击 **Gizmos** 一词旁边的下拉箭头，然后仅启用要查看的辅助图标类型。                                   |

## Aspect/分辨率
![[Pasted image 20240830162937.png]]
![[Pasted image 20240830163310.png]]
**说明**：上面的是自定义长宽比，下面的是自定义分辨率，设置好后OK即可。
## Stats窗口
该窗口通过点击Stats按钮弹出，用于查看游戏在运行模式下的实时渲染信息，一般用于游戏性能优化。
![[Pasted image 20240830163547.png]]

统计信息	描述
1. FPS：表示Unity渲染游戏画面的速率，可以理解为1s渲染多少张游戏画面。数值越高游戏越流畅，由于人类眼睛的生物结构，30fps可以让人眼不会感觉到卡顿。
2. CPU main ：CPU处理一帧所花费的总时间
3. CPU render： GPU渲染一帧花费的时间
4. Batches：Unity在一帧内处理的批次总数量（包括静态和动态批次，该值过高会影响游戏性能）
5. Saved by batching：Unity的合并批次数，不同游戏对象共享相同的材质，可以将Batches合并处理，节约性能开销
6. Tris：Unity在一帧内处理的三角形数量（针对低端机型优化时这一点很重要）
7. Verts：Untiy在一帧内处理的定点数（针对低端机型优化时这一点很重要）
8. Screen：屏幕的分辨率及其使用的内存量
9. SetPass：	Unity 在一帧中切换用于渲染游戏对象的着色器通道的次数。一个着色器可能包含多个着色器通道，每个通道以不同的方式渲染场景中的游戏对象。每个 pass 都需要 Unity 绑定一个新的着色器，这可能会带来 CPU 开销
10. Shadow casters：在一帧中投射阴影的游戏对象的数量（受可被光源投射，从而产生阴影的物体数量所影响）
11. Visible skinned meshes：Unity 在帧中渲染的带蒙皮的网格渲染器的数量
12. Animations：帧期间播放的动画数量
说明：
■ 一般情况下，这个窗口你是不需要看的，除非进行游戏性能优化。
■ 游戏性能优化是个比较大的话题，后面会安排一章。

## Gizmos 菜单[[Gizmos 菜单]]

Gizmos 菜单包含的一些选项用于控制 Unity 如何在 Scene 视图和 Game 视图中显示游戏对象的辅助图标以及其他项。此菜单在 Scene 视图和 Game 视图中均可用。有关更多信息，请参阅 [Gizmos 菜单](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html)。

## 高级选项

Right-click the **Game** tab to display advanced Game view options.
右键单击 **Game** 选项卡可显示高级 Game 视图选项。

![](https://docs.unity.cn/cn/2021.3/uploads/Main/GameView-AdvancedOptions.png)

__Warn if No Cameras Rendering__：此选项默认为启用状态：如果没有摄像机渲染到屏幕，Unity 会显示警告。这对于诊断意外删除或禁用摄像机等问题非常有用。除非故意不使用摄像机来渲染应用程序，否则应将此选项保持启用状态。

__Clear Every Frame in Edit Mode__：此选项默认为启用状态：在应用程序未运行时，Unity 会每帧更新 Game 视图。这可以防止在配置应用程序时出现拖尾效果。除非在未处于运行模式时依赖于前一帧的内容，否则应将此选项保持启用状态。

Maximize：最大最小化。

Close Tab：关闭窗口
Add Tab：开启窗口

UIEements Debugger：调试

---

- 从 [2018.2](https://docs.unity.cn/2018.2/Documentation/Manual/30_search.html?q=newin20182) 版开始在 Windows 上提供了 **Low Resolution Aspect Ratios** Game 视图选项