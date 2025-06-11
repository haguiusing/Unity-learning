# Output Particle Line
菜单路径 : **Context > Output Particle Line**

此 **Output Particle Line** Context 使用线条来渲染粒子系统。线条由两个端点定义，并且始终为单个像素宽度，而不管粒子到摄像机的距离或粒子的大小和缩放属性如何。

有两种模式可用于设置线条的终点。第一个点始终位于粒子位置：
- 在粒子空间中使用目标偏移。通过在粒子空间中定义的偏移来指定第二个点。
- 使用 target position 属性。使用 target position 属性指定第二个点。

此输出不支持纹理。

以下是特定于 Output Particle Line Context 的设置和属性列表。有关此上下文与所有其他上下文共享的通用输出设置的信息，请参阅[全局输出设置和属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputSharedSettings.html)。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputLine.html#context-settings)Context settings

| 设置                    | 类型   | 描述                                                                                    |
| --------------------- | ---- | ------------------------------------------------------------------------------------- |
| **Use Target Offset** | bool | 指示此 Context 是否将线条的终点派生为粒子空间中粒子位置的偏移量。如果禁用此属性，则 Context 将使用粒子的 target position 属性作为终点。 |

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputLine.html#context-properties)Context properties

|输入|类型|描述|
|---|---|---|
|**Target Offset**|Vector3|此上下文应用于粒子位置以派生第二个点的粒子空间中的偏移量。  <br>此属性仅在启用 Use Target Offset （使用目标偏移） 时可用。|