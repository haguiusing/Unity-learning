![[Lesson36_Scene窗口拓展_Gizmos_贴图图标.cs]]

### Gizmos绘制贴图
Gizmos.DrawGUITexture(new Rect(x, y, w, h), 图片信息);（默认就反过来的）
```cs
private void OnDrawGizmos()
{
    if (pic != null)
    {
        // 注意只能在xy跟随对象移动，在z轴移动不起作用
        Gizmos.DrawGUITexture(new Rect(this.transform.position.x, this.transform.position.y, 160, 90), pic);
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/36.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E8%B4%B4%E5%9B%BE%E5%9B%BE%E6%A0%87/1.png)

### Gizmos绘制图标
图标需要放置在固定文件夹中 Assets/Gizmos/中  
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/36.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E8%B4%B4%E5%9B%BE%E5%9B%BE%E6%A0%87/2.png)

Gizmos.DrawIcon(Vector3.up, “图标名”);
```cs
private void OnDrawGizmos()
{
    Gizmos.DrawIcon(this.transform.position, "MyIcon");
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/36.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E8%B4%B4%E5%9B%BE%E5%9B%BE%E6%A0%87/3.png)

