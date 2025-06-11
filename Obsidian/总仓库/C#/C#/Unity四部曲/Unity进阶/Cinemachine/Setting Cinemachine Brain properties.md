# Setting Cinemachine Brain properties

Cinemachine Brain 是 Unity 摄像机本身的一个组件。Cinemachine Brain 监控场景中所有活动的虚拟摄像机。它选择下一个 Virtual Camera 来控制 Unity Camera 。它还控制从当前 Virtual Camera 到下一个 Virtual Camera 的[剪切或混合](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineBlending.html)。

要将 Cinemachine Brain 组件添加到 Unity 摄像机，请执行以下操作**之一**：
- [将 Virtual Camera](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineSetUpVCam.html) 或其他 Cinemachine 对象添加到场景中。Unity 会为您添加一个 Cinemachine Brain 组件（如果还没有）。
    
- 自行将 Cinemachine Brain 组件[添加到](https://docs.unity3d.com/Manual/UsingComponents.html) Unity 摄像机。
    

**提示**： 您还可以从 [Timeline](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineTimeline.html) 控制虚拟摄像机。Timeline 将覆盖 Cinemachine Brain 做出的决策。

Cinemachine Brain 具有以下关键属性：
- **Blend Settings（混合设置**）：定义如何从一个虚拟摄像机混合到另一个虚拟摄像机的列表。例如，向列表中添加一个项目，用于从 vcam1 到 vcam2 的 4 秒混合，然后添加另一个项目，用于从 vcam2 返回到 vcam1 的 1 秒混合。如果未定义两个摄像机之间的混合，则 Cinemachine Brain 将使用其默认混合。
    
- **Layer Filter**：Cinemachine Brain 仅使用通过 Unity 摄像机的剔除遮罩的虚拟摄像机。您可以通过使用剔除蒙版来筛选图层来设置[分屏环境](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineMultipleCameras.html)。
    
- **事件调度**：Cinemachine Brain 在更改镜头时触发事件。当 Virtual Camera 上线时，它会触发一个事件。当它从一个 Virtual Camera 切到另一个 Virtual Camera 时，它也会触发一个事件。使用后一个事件来重置临时后期效果。
    

![Cinemachine Brain, a component in the Unity camera](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/images/CinemachineBrain.png)

## 性能：