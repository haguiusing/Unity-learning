# Instancing|实例化
您可以使用实例化对多个效果进行批处理，前提是它们具有相同的 [Visual Effect Graph 资源](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html)。这可以显著提高性能。

默认情况下，实例化处于启用状态，但使用不支持实例化的功能的 Visual Effect Graph 资源除外。这些包括：
- [GPU events](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#gpu-events)
- [Output Mesh|输出网格](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputMesh.html)
- [Output Event Handlers|输出事件处理程序](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/OutputEventHandlers.html)
## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Instancing.html#how-instancing-works)实例化的工作原理
视觉效果包括存储在缓冲区中的数据和着色器执行的操作。使用相同 [Visual Effect Graph 资源](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html)的效果将执行相同的操作。

实例化 （Instancing） 在共享缓冲区中为这些效果分配数据。共享缓冲区的一组效果称为 **批次**，效果是属于该批次的**实例**。

每次创建新效果时，实例化系统都会在现有批处理中查找插槽。如果没有任何可用的空槽，则实例化系统会创建一个新的完整批处理，并在其中分配效果数据。每个 [Visual Effect Graph 资源的](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html)批次都具有**固定容量**，您可以自动（默认情况下）或手动设置。

如果为效果禁用了实例化，则实例化系统会分配一个具有单个实例的批处理。

在模拟更新期间，属于同一批次的效果可以一起运行一些操作。

同样，在渲染过程中，可以按批次对效果进行分组，从而减少 CPU 时间。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Instancing.html#configuration)配置
实例化功能默认处于启用状态，在大多数情况下不需要任何配置。但是，为了提高性能，您可以调整每个 [Visual Effect Graph 资源的](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html)批处理容量。您还可以禁用对特定效果的实例化。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Instancing.html#adjust-batch-capacity)调整批次产能
您可以调整每个 [Visual Effect Graph 资源的](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html#visual-effect-asset-inspector)批处理容量。要调整容量，请导航到 VFX 资产的 Inspector，然后在 Instancing 部分中选择 Instancing Mode。
- **自动批量容量**：根据效果的内容和构建平台自动设置批量容量。这是默认模式。
- **自定义批量容量**：将容量设置为自定义值。如果你对同时应该存在多少效果有很好的估计，或者如果你想更好地控制使用的内存量，这将非常有用。

当您设置自定义容量时，效果在所有平台上使用相同的值。您应该对不同的场景进行性能分析，以确保性能没有回归。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Instancing.html#disable-instancing)禁用实例化
您可以在特定 [Visual Effect Graph 资源](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html#visual-effect-asset-inspector)或 [Visual Effect 组件](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#the-visual-effect-inspector)上禁用实例化，也可以在整个项目中禁用实例化。禁用实例化会将每个受影响的效果的批处理容量设置为 1。您应该仅出于调试目的禁用实例化，或者如果您确信不需要实例化。

要对特定 [Visual Effect Graph 资源](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html#visual-effect-asset-inspector)禁用实例化，请执行以下操作：
1. 导航到 VFX 资源的 Inspector。
2. 在**Instancing （实例化）** 部分中，选择 **Instancing Mode （实例化模式**）。
3. 将 **Instancing mode （实例化**模式） 设置为 **Disabled （已禁用**）。

要在特定 [Visual Effect 组件](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html#the-visual-effect-inspector)上禁用实例化：
1. 导航到 Visual Effect 组件的 Inspector。
2. 在 **Instancing** 部分中，停用 **Allow Instancing**。

要在整个项目中禁用实例化：
1. 打开 [Visual Effect 首选项](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectPreferences.html)（Windows：**Edit > Preferences > Visual Effects**。macOS：**Unity > Settings > Visual Effects**）。
2. Deactivate **Instancing Enabled（已启用实例化**）。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Instancing.html#scripting-api)脚本 API
实例化通过 [VFX Manager 脚本 API](https://docs.unity3d.com/ScriptReference/VFX.VFXManager.html) 添加了一些脚本功能。

使用此功能，您可以访问每个 Visual Effect 资源的[其他信息和统计信息](https://docs.unity3d.com/ScriptReference/VFX.VFXBatchedEffectInfo.html)。