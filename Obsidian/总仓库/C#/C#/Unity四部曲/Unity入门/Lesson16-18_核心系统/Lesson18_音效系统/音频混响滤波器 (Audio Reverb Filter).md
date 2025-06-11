**Audio Reverb Filter** 将获取[音频剪辑](https://docs.unity3d.com/cn/current/Manual/class-AudioClip.html)并对其进行失真处理以创建自定义的混响效果。

## 属性
![](https://docs.unity3d.com/cn/current/uploads/Main/AudioReverbFilter.png)

|**_属性：_**|**_功能：_**|
|---|---|
|**Reverb Preset**|自定义的混响预设值，选择 User 可创建自定义混响。|
|**Dry Level**|输出中的干信号的混合等级，以 mB 为单位。范围从 –10000.0 到 0.0。默认值为 0。|
|**Room**|低频下的房间效果等级，以 mB 为单位。范围从 –10000.0 到 0.0。默认值为 0.0。|
|**Room HF**|房间效果高频等级，以 mB 为单位。范围从 –10000.0 到 0.0。默认值为 0.0。|
|**Room LF**|房间效果低频等级，以 mB 为单位。范围从 –10000.0 到 0.0。默认值为 0.0。|
|**Decay Time**|低频下的混响衰减时间，以秒为单位。范围从 0.1 到 20.0。默认值为 1.0。|
|**Decay HFRatio**|衰减高频比率：高频到低频衰减时间比率。范围从 0.1 到 2.0。默认值为 0.5。|
|**Reflections Level**|相对于房间效果的早期反射等级，以 mB 为单位。范围从 –10000.0 到 1000.0。默认值为 –10000.0。|
|**Reflections Delay**|相对于房间效果的早期反射延时时间，以 mB 为单位。范围从 0 到 0.3。默认值为 0.0。|
|**Reverb Level**|相对于房间效果的晚期混响等级，以 mB 为单位。范围从 –10000.0 到 2000.0。默认值为 0.0。|
|**Reverb Delay**|相对于第一次反射的晚期混响延时时间，以秒为单位。范围从 0.0 到 0.1。默认值为 0.04。|
|**HFReference**|参考高频，以 Hz 为单位。范围从 1000.0 到 20000.0。默认值为 5000.0。|
|**LFReference**|参考低频，以 Hz 为单位。范围从 20.0 到 1000.0。默认值为 250.0。|
|**Diffusion**|混响扩散（回声密度），以百分比为单位。范围从 0.0 到 100.0。默认值为 100.0。|
|**Density**|混响密度（模态密度），以百分比为单位。范围从 0.0 到 100.0。默认值为 100.0。|

**注意：**仅当 **Reverb Preset** 设置为 **User** 时，才能修改这些值，否则这些值将显示为灰色，并且每个预设都为默认值。

# 混响区（Audio Reverb Zones）
_混响区__获取[音频剪辑](https://docs.unity3d.com/cn/current/Manual/class-AudioClip.html)并根据音频监听器在混响区内的位置使音频剪辑失真。从没有环境效果的点逐渐到有环境效果的点（例如进入洞穴时），便可使用混响区。

## 属性
![](https://docs.unity3d.com/cn/current/uploads/Main/AudioReverbZone.png)

|**_属性：_**|**_功能：_**|
|---|---|
|**Min Distance**|表示辅助图标中内圆的半径，决定了逐渐出现混响效果的区域和完整的混响区。|
|**Max Distance**|表示辅助图标中外圆的半径，决定了没有效果的区域和开始逐渐应用混响的区域。|
|**Reverb Preset**|决定了混响区将使用的混响效果。|

此图说明了混响区的属性。
![声音在混响区中的工作方式](https://docs.unity3d.com/cn/current/uploads/Main/ReverbZoneExpl.png)

声音在混响区中的工作方式

## 提示

可混合混响区以创建组合效果。