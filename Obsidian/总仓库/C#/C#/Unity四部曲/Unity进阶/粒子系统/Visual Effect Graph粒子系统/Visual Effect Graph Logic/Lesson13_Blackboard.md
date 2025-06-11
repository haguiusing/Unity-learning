# Blackboard|黑板
Blackboard 是 [Visual Effect Graph 窗口中](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphWindow.html)的一个实用工具面板，可用于管理：
- [Properties|性能](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html)
- [Custom Attributes|自定义属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#attributes)
- Built-in particle attributes|内置粒子[属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html)

要切换 Blackboard 的可见性，您可以使用快捷方式或单击 Visual Effect Graph [工具栏](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphWindow.html#Toolbar)中的 **Blackboard** 按钮。  
拖动窗口的边缘以调整其大小，拖动窗口的标题以移动它。`SHIFT + 1`

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#properties)性能
您可以创建/删除、排序和分类属性。  
对于每个属性，可以使用以下选项：

| **设置**       | **描述**                                                                                                                                                                                                                                                                                            |
| ------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Exposed	** | 指定是否公开属性。启用后，您可以在[Visual Effect 组件](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html)以及通过[C# API](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html).  <br>当属性公开时，将显示一个绿点（如果使用该属性，则为亮绿色，如果未使用，则灰显）。 |
| **Value**    | 指定属性的默认值。如果您不公开该属性，或者公开该属性但不覆盖它，则 Visual Effect Graph 会使用此值。                                                                                                                                                                                                                                      |
| **Tooltiip** | 指定将属性悬停在图表或 Visual Effect 组件检查器中时显示的文本。                                                                                                                                                                                                                                                           |
| **Mode**     | 对于数字类型，您可以设置 **Range** 模式（具有最小值和最大值），从而将值控件转换为滑块。  <br>对于 UInt 类型，您还可以选择 **Enum** ，这会将控件转换为下拉列表                                                                                                                                                                                                   |

要在图表中使用属性，您可以将其拖放到图表中，也可以在节点搜索中按名称查找它。  
您可以在图表中多次使用同一属性（即使在不同的系统中）
[![黑板属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-properties.png)](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-properties.png)
### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#add-a-property)添加属性
要添加属性，请单击 Blackboard 左上角的加号按钮。  
将打开一个菜单，提供两个选项： **Property （属性**[**） 和 Attribute （属性**](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#attributes)）。选择 **Property** 选项，然后选择所需的类型。`+`

您还可以将内联 [Operator](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html) 转换为属性。为此，请使用快捷方式或右键单击图表中的 Node 并选择以下任一选项：`SHIFT + X`
- 如果您想创建一个常量，**请转换为 Property**。
- Convert **to Exposed Property** 如果要创建公开的属性  (新版改为“Exposed”触发器)
    无论您选择哪个选项，您都可以稍后启用或禁用 **Exposed** 设置。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#arranging-properties)排列属性
1. 要重命名属性，您可以：
    - 选择属性并按 F2
    - 双击属性名称
    - 右键单击属性名称，然后从上下文菜单中选择 **Rename**。
    - 在 Inspector 中，更改 **Exposed Name** 值
2. 要对属性重新排序，请将其拖放到上方或下方的某个位置。  
    如果将其拖放到某个类别上或某个类别内，则该属性将移动到该类别
3. 要删除属性：
    - 右键单击该属性，然后从上下文菜单中选择 **Delete**。
    - 选择属性，然后按 **Delete** 键（对于 macOS，**为 Cmd** + **Delete** 键）。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#property-categories)属性类别
类别允许您将属性分类到组中，以便更轻松地管理它们。您可以**像重命名**属性一样重命名和**删除**类别。  
类别创建的工作方式与属性相同，只需选择菜单顶部的 **Category** 类型即可。 您可以将属性从一个类别拖放到另一个类别。如果您不希望某个属性属于某个类别，请将其放在属性的顶部。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#property-nodes)属性节点
Property Nodes 看起来与标准[运算符](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html)略有不同。它们会显示属性名称，如果属性已公开，则会显示一个绿点。 该值可以是 blackboard 中设置的默认值，也可以是 Component Inspector 中设置的覆盖值。

您可以展开它们以使用属性值的子成员。
![属性节点](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PropertyNode.png)
左侧是未公开的属性，右侧是公开的属性（注意绿点）

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#exposed-properties-in-the-inspector)Inspector 中公开的属性
当您为某个属性启用 **Exposed** 设置时，该属性将在 [Visual Effect](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html) 组件的 Inspector 的 **Properties** 部分中可见。  
属性的显示顺序和类别与您在 Blackboard 中设置的顺序和类别相同。
![[Pasted image 20241023190445.png]]
#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#overriding-property-values-per-gameobject)覆盖每个游戏对象的属性值
对于场景中的每个 VFX 组件，您可以覆盖任何公开的属性值。  
在层次结构中选择包含 Visual Effect 的游戏对象时，将在 Inspector 中看到列出所有公开的属性。  
然后，如果您更改属性值，则 override 复选框将被选中并覆盖该值。 要撤销更改，您只需取消选中 override 复选框，然后将使用黑板中设置的该属性的默认值。
###   使用 Gizmo
您可以使用 Gizmo 编辑某些高级属性类型。要启用 Gizmo 编辑，请单击 **Show Property Gizmos** 按钮。要使用 Gizmo 编辑兼容的属性，请单击该属性旁边的 **Edit** 按钮。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#attributes)Attributes|属性(新版本)
[属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html)是 **Particle Attribute** 的简称，是每个粒子携带的独立值。 现在，黑板允许您管理内置属性和自定义属性。

左侧的图标表示属性的类型。在下面的屏幕截图中，我们可以看到该属性是一个`Vector3`
![属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-attribute.png)
要在图表中使用属性，您可以将其拖放到图表中。
- 如果你把它放在上下文中，它将创建一个块。`Set Attribute`
- 如果你把它放在 void 中，它将创建一个运算符。`Get Attribute`

您还可以在节点搜索窗口中找到该属性。
[![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-dragdrop-attribute.gif)](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-dragdrop-attribute.gif)
### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#custom-attributes)自定义属性
对于每个自定义属性，您可以：
- **Rename**：自定义属性的所有用法都将自动更新
- **更改类型**：自定义属性的所有使用情况都将自动更新
- **添加描述**：它将在图表中显示为工具提示

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#built-in-attributes)内置属性
本节列出了所有可用的内置属性。右侧的小储物柜图标表示您无法修改它们。  
对于每个内置属性，您都有以下信息：
- 名字
- 类型
- 访问（是否为只读）
- 描述
![内置属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-builtin-attributes.png)

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#custom-hlsl)自定义 HLSL
为避免在编写[自定义 HLSL](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html) 代码时出现拼写错误，可以在 HLSL 代码编辑器（在 Unity 中）中拖放属性。
## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#common-features)共同特点
- **Duplicate**：您可以使用快捷键 （macOS： ） 或上下文菜单复制属性或自定义属性`Ctrl + D``Cmd + D`
    
- **多选**：例如，您可以使用 or （macOS： ） 选择多个属性或自定义属性，然后在图表中拖放`Shift + Click``Ctrl + Click``Cmd + Click`
    
- **复制/粘贴**：您可以使用 和 跨不同的 VFX 图形复制/粘贴属性和自定义属性`Ctrl + C``Ctrl + V`
    
- **悬停属性**：如果将鼠标悬停在某个属性上，则图表中所有对应的节点都会以橙色  
    高亮显示，同样，如果将鼠标悬停在图表中的某个节点上，相应的属性将在黑板中高亮显示。
    
- **Hover Attribute**：如果将鼠标悬停在某个属性上，则图表中所有使用该属性的节点都会以橙色  
    高亮显示。同样，如果将鼠标悬停在图表中的某个节点上，相应的属性将在黑板中高亮显示。  
    这适用于自定义属性和内置属性。
    
- **Select unused**：右键单击类别（或位于黑板顶部）时，上下文菜单提供选择未使用的属性或未使用的自定义属性的选项。 当您想要清理 VFX 时，这可能很有帮助。
    
- ![选择 Unused](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-unused.png)
    

##### 提示
自定义属性的一个便捷工作流程是使用 （macOS： ） 复制内置属性。  
这将创建一个新的自定义属性，其名称为 like 且类型相同。`Ctrl + D``Cmd + D``orignalname_1`

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#filter)滤波器
在黑板顶部附近，有三个选项卡，可让您筛选要显示的元素类型：
- **All**：显示 Properties 和 Attributes
- **属性**：仅显示属性
- **属性**：仅显示属性
![滤波器](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-filter.png)

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#subgraph-category)子图类别
在处理子图时，黑板允许您指定将在节点搜索中使用的类别。 要更改类别，请双击黑板的副标题并输入所需的类别名称，然后使用 键`Return`

要创建多个类别级别，请使用角色。例如。`/``MySubgraphs/Math`
![黑板-类别](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/blackboard-subgraph.png)