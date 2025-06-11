[Panel](file:///D:/Obsidian%20Unity/Unity/UI%20System/Assets/Scripts/NGUI/%E7%9F%A5%E8%AF%86%E7%82%B9/Lesson1_%E4%B8%89%E5%A4%A7%E5%9F%BA%E7%A1%80%E6%8E%A7%E4%BB%B6/Lesson1_Panel.cs)
## Panel 管理ui面板的渲染顺序 管理所有控件
![[Pasted image 20240928184511.png]]
Alpha ：所有子ui透明度
Depth ：渲染层级 层级越高显示在越前面
Clipping ：不咋用
Sorting Layer ：渲染层

![[Pasted image 20240928184852.png]]
补充 ：在panel上查看draw call 相同图集和文字减少depth的穿插