# Light Explorer 扩展
通过 Light Explorer 扩展，可以创建自定义版本的 [Light Explorer 窗口](https://docs.unity3d.com/cn/current/Manual/LightingExplorer.html)。可以将这种扩展用于调整 Light Explorer 窗口的功能，以便处理可编程渲染管线 (SRP) 或者[高清渲染管线](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest/index.html?preview=1)的自定义[光源](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest/index.html?subfolder=/manual/Light-Component.html?)。

在 Light Explorer 窗口中，可以看到场景中的所有[光源](https://docs.unity3d.com/cn/current/Manual/class-Light.html)并可编辑它们的属性。使用此扩展，可以通过多种方式扩展当前窗口。例如，可以执行以下操作：
- 更改选项卡（从简单地更改选项卡名称到添加您自己的自定义选项卡）以显示不同类型的游戏对象的列表。例如，如果要显示自己的自定义反射探针的属性信息，这将很有用。
- 更改选项卡上的列（同样从更改名称到添加您自己的自定义列）。如果要查看其他光源属性，添加列很有用。

## 扩展 Light Explorer
要扩展 Light Explorer，可以继承自：
- `ILightingExplorerExtension` 接口，然后覆盖 `GetContentTabs` 方法。
- `DefaultLightingExplorerExtension` 类（继承自 `ILightingExplorerExtension`）。此类提供窗口中已经存在的所有内容。如果只希望覆盖选项卡的数量、每个选项卡的标题或要显示的光源，请使用此选项。要了解如何以这种方式扩展 Light Explorer，请参阅下面的示例。

### 示例代码
本节中的示例展示了如何扩展默认的 Light Explorer 类以仅显示光源的名称 (Name) 列，以及如何更改选项卡的数量。在您自己的实现中，可以根据需要覆盖任意数量的方法。

以下示例显示了光源的名称列：
```
using UnityEngine;
using UnityEditor;

[LightingExplorerExtensionAttribute(typeof(ExampleRenderPipelineAsset))]
public class SimpleExplorerExtension : DefaultLightingExplorerExtension
{
    private static class Styles
    {
        public static readonly GUIContent Name = EditorGUIUtility.TrTextContent("Name");
    }
    
    protected override LightingExplorerTableColumn[] GetLightColumns()
    {
        return new[]
        {
            new LightingExplorerTableColumn(LightingExplorerTableColumn.DataType.Name, Styles.Name, null, 200), // 0: Name
        };
    }
}
```

以下示例仅显示光源的名称和启用状态，并隐藏 Emissive Materials 选项卡（仅显示 3 个选项卡，而不是 4 个）

```
using UnityEngine;
using UnityEditor;

[LightingExplorerExtensionAttribute(typeof(ExampleRenderPipelineAsset))]
public class ComplexLightExplorerExtension : DefaultLightingExplorerExtension
{
    private static class Styles
    {
        public static readonly GUIContent Name = EditorGUIUtility.TrTextContent("Name");
        public static readonly GUIContent Enabled = EditorGUIUtility.TrTextContent("Enabled");
    }
    
    protected override UnityEngine.Object[] GetLights()
    {
        return Resources.FindObjectsOfTypeAll<Light>();
    }

    protected override LightingExplorerTableColumn[] GetLightColumns()
    {
        return new[]
        {
            new LightingExplorerTableColumn(LightingExplorerTableColumn.DataType.Name, Styles.Name, null, 200), // 0: Name
            new LightingExplorerTableColumn(LightingExplorerTableColumn.DataType.Checkbox, Styles.Enabled, "m_Enabled", 25), // 1: Enabled
        };
    }

    public override LightingExplorerTab[] GetContentTabs()
    {
        return new[]
        {
            new LightingExplorerTab("Lights", GetLights, GetLightColumns, true),
            new LightingExplorerTab("2D Lights", Get2DLights, Get2DLightColumns, true),
            new LightingExplorerTab("Reflection Probes", GetReflectionProbes, GetReflectionProbeColumns, true),
            new LightingExplorerTab("Light Probes", GetLightProbes, GetLightProbeColumns, true),
            new LightingExplorerTab("Static Emissives", GetEmissives, GetEmissivesColumns, false),
        };
    }
}
```

### 有用的类和方法
下面列出了可用于扩展 Light Explorer 的类和方法：
ILightingExplorerExtension：
```
public virtual LightingExplorerTab[] GetContentTabs();
public virtual void OnEnable() {}
public virtual void OnDisable() {}
```

DefaultLightingExplorerExtension（继承自 ILightingExplorerExtension）：
```
public virtual LightingExplorerTab[] GetContentTabs();
public virtual void OnEnable() {}
public virtual void OnDisable() {}

protected virtual UnityEngine.Object[] GetLights();
protected virtual LightingExplorerTableColumn[] GetLightColumns();

protected virtual UnityEngine.Object[] GetReflectionProbes();
protected virtual LightingExplorerTableColumn[] GetReflectionProbeColumns();

protected virtual UnityEngine.Object[] GetLightProbes();
protected virtual LightingExplorerTableColumn[] GetLightProbeColumns();

protected virtual UnityEngine.Object[] GetEmissives();
protected virtual LightingExplorerTableColumn[] GetEmissivesColumns();
```