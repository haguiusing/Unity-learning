![[EditorGUIUtility是什么#^ca5a49]]

![[Lesson17_EditorGUIUtility_指定区域使用对应鼠标指针.cs]]

### 指定区域使用对应鼠标指针
AddCursorRect(Rect position, MouseCursor mouse);

MouseCursor鼠标光标类型枚举  
Arrow 普通指针箭头  
Text 文本文本光标  
ResizeVertical 调整大小垂直调整大小箭头  
ResizeHorizontal 调整大小水平调整大小箭头  
Link 带有链接徽章的链接箭头  
SlideArrow 滑动箭头带有小箭头的箭头，用于指示在数字字段处滑动  
ResizeUpRight 调整大小向上向右调整窗口边缘的大小  
ResizeUpLeft 窗口边缘为左  
MoveArrow 带有移动符号的箭头旁边用于场景视图  
RotateArrow 旁边有用于场景视图的旋转符号  
ScaleArrow 旁边有用于场景视图的缩放符号  
ArrowPlus 旁边带有加号的箭头  
ArrowMinus 旁边带有减号的箭头  
Pan 用拖动的手拖动光标进行平移  
Orbit 用眼睛观察轨道的光标  
Zoom 使用放大镜进行缩放的光标  
FPS 带眼睛的光标和用于FPS导航的样式化箭头键  
CustomCursor 当前用户定义的光标  
SplitResizeUpDown 向上-向下调整窗口拆分器的大小箭头  
SplitResizeLeftRight窗口拆分器的左-右调整大小箭头
```cs
private void OnGUI()
{
    EditorGUI.DrawRect(new Rect(0, 180, 100, 100), Color.green);
    EditorGUIUtility.AddCursorRect(new Rect(0, 180, 100, 100), MouseCursor.FPS);
}
```

鼠标移动到绿色区域会变指针样式  
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/17.EditorGUIUtility-%E6%8C%87%E5%AE%9A%E5%8C%BA%E5%9F%9F%E4%BD%BF%E7%94%A8%E5%AF%B9%E5%BA%94%E9%BC%A0%E6%A0%87%E6%8C%87%E9%92%88/1.png)

