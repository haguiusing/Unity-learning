[InputField](file://assets/Scripts/UGUI/Lesson12_InputField/Lesson12_InputField.cs)
# 输入字段 (Input Field)
__输入字段__是一种使[文本 (Text) 控件](https://docs.unity3d.com/cn/2022.3/Manual/script-Text.html)的文本可编辑的方法。与其他交互控件一样，输入字段本身不是可见的 UI 元素，必须与一个或多个可视 UI 元素组合才能显示。

![空的输入字段。](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_InputFieldExample.png)
空的输入字段。

![在输入字段中输入的文本。](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_InputFieldExample2.png)
在输入字段中输入的文本。

![[Pasted image 20241203221121.png]]

## 属性
![[Pasted image 20241203221025.png]]

| **_属性：_**                        |                        | **_功能：_**                                                                                                                                                       |
| -------------------------------- | ---------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Interactable**                 |                        | 一个用于确定输入字段是否可交互的布尔值。                                                                                                                                            |
| **Transition**                   |                        | [过渡](https://docs.unity3d.com/cn/2022.3/Manual/script-SelectableTransition.html)用于设置输入字段在 **_Normal_**、**_Highlighted_**、**_Pressed_** 或 **_Disabled_** 时的过渡方式。 |
| **Navigation**                   |                        | 确定控件顺序的属性。请参阅[导航选项](https://docs.unity3d.com/cn/2022.3/Manual/script-SelectableNavigation.html)。                                                                |
| **TextComponent**                |                        | 对用作__输入字段__内容的[文本](https://docs.unity3d.com/cn/2022.3/Manual/script-Text.html)元素的引用                                                                             |
| **Text**                         |                        | 起始值。开始编辑前置于字段中的初始文本。                                                                                                                                            |
| **Character Limit**              |                        | 可在输入字段中输入的最大字符数的值。                                                                                                                                              |
| **Content Type**                 |                        | 定义输入字段接受的字符类型                                                                                                                                                   |
|                                  | **Standard**           | 可以输入任何字符。                                                                                                                                                       |
|                                  | **Autocorrected**      | 自动更正将确定输入是否跟踪未知单词，并向用户建议更合适的替换候选项，除非用户明确覆盖该操作，否则会自动替换键入的文本。                                                                                                     |
|                                  | **Integer Number**     | 只允许输入整数。                                                                                                                                                        |
|                                  | **Decimal Number**     | 仅允许输入数字和单个小数点。                                                                                                                                                  |
|                                  | **Alphanumeric**       | 允许字母和数字。无法输入元件。                                                                                                                                                 |
|                                  | **Name**               | 自动将每个单词的首字母大写。请注意，用户可以使用 **Delete** 键绕过大小写规则。                                                                                                                   |
|                                  | **Email Address**      | 允许您输入一个字母数字字符串，该字符串最多包含一个 @ 符号。句点/基线点不能彼此相邻输入。                                                                                                                  |
|                                  | **Password**           | 隐藏输入的带星号的字符。允许元件。                                                                                                                                               |
|                                  | **Pin**                | 隐藏输入的带星号的字符。只允许输入整数。                                                                                                                                            |
|                                  | **Custom**             | 允许您自定义 Line Type、Input Type、Keyboard Type 和 Character Validation。                                                                                               |
| **Line Type**                    |                        | 定义文本字段内文本的格式设置方式。                                                                                                                                               |
|                                  | **Single Line**        | 仅允许文本位于单行上。                                                                                                                                                     |
|                                  | **Multi Line Submit**  | 允许文本使用多行。仅在需要时使用新行。                                                                                                                                             |
|                                  | **Multi Line Newline** | 允许文本使用多行。用户可以通过按回车键来使用换行符。                                                                                                                                      |
| **Placeholder**                  |                        | 这是一个可选的“空”[图形](https://docs.unity3d.com/cn/2022.3/ScriptReference/UI.Graphic.html)，用于表明__输入字段__不包含文本。请注意，即使选择了__输入字段__（即获得焦点），仍会显示此“空”图形。如：“Enter text…”。       |
| **Caret Blink Rate**             |                        | 定义该行上的标记的闪烁速率（用于指示建议插入文本）。                                                                                                                                      |
| Caret Width                      |                        | 光标宽度                                                                                                                                                            |
| Custom Caret Color               |                        | 自定义光标颜色                                                                                                                                                         |
| Caret Color                      |                        | 光标颜色，勾选Custom Caret Color时出现                                                                                                                                    |
| **Selection Color**              |                        | 所选文本部分的背景颜色。                                                                                                                                                    |
| **Hide Mobile Input** (iOS only) |                        | 在移动设备上隐藏附加到屏幕键盘的本机输入字段。请注意，这仅适用于 iOS 设备。                                                                                                                        |
| Read Only                        |                        | 只读                                                                                                                                                              |
| Should Activate On Select        |                        | 应在选择时激活                                                                                                                                                         |

## 事件

| **_属性：_**           | **_功能：_**                                                                                                                                          |
| ------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| **On Value Change** | 输入字段的文本内容发生变化时调用的 [UnityEvent](https://docs.unity3d.com/cn/2022.3/Manual/UnityEvents.html)。该事件可将当前文本内容作为 `string` 类型动态参数发送。                        |
| **OnSubmit**        | 在使用InputField.onEndEdit时发现一个问题，就是你输入法点击提交会执行该方法，输入时点击其他任何地方也会执行该方法，这是我们不需要的。<br>我们想要的是只有我们在输入完成后点击提交的时候再执行，于是我们想到了InputField.onSubmit方法            |
| **End Edit**        | 用户完成文本内容的编辑（通过提交操作或单击某个位置以将焦点移出输入字段）时调用的 [UnityEvent](https://docs.unity3d.com/cn/2022.3/Manual/UnityEvents.html)。该事件可将当前文本内容作为 `string` 类型动态参数发送。 |

## 详细信息

可从菜单 (**Component > UI > Input Field**) 中将输入字段 (Input Field) 脚本添加到任何现有的文本控件对象。完成此操作后，还应将该对象拖动到输入字段的 _Text_ 属性以便启用编辑。

文本控件本身的 _Text_ 属性将随用户输入而变化，并可在编辑后从脚本中检索值。请注意，可编辑的文本控件有意不支持富文本 (Rich Text)；该字段将在输入时立即应用富文本标记，但标记基本上会“消失”，并且没有后续方法可更改或删除样式。

## 提示

- 要获取输入字段的文本，请使用 InputField 组件本身的 Text 属性，而不是使用显示文本的文本组件的 Text 属性。文本组件的 Text 属性可能会被裁剪，也可能包含隐藏密码的星号。