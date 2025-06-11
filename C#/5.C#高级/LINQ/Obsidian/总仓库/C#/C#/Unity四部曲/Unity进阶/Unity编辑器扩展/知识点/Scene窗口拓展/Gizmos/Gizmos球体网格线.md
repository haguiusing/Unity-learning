![[Lesson38_Scene窗口拓展_Gizmos_球体网格线.cs]]

### Gizmos绘制球体
Gizmos.DrawSphere(中心点, 半径);  
Gizmos.DrawWireSphere(中心点, 半径);
```cs
private void OnDrawGizmosSelected()
{
    // Gizmos绘制球体
    Gizmos.color = Color.red;
    Gizmos.DrawSphere(this.transform.position, 2);
    Gizmos.color = Color.white;
    Gizmos.DrawWireSphere(this.transform.position, 3);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/38.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E7%90%83%E4%BD%93%E7%BD%91%E6%A0%BC%E7%BA%BF/1.png)

### Gizmos绘制网格线
Gizmos.DrawWireMesh(mesh, 位置, 角度);
```cs
private void OnDrawGizmosSelected()
{
    // Gizmos绘制网格线
    Gizmos.color = Color.yellow;
    if (mesh != null)
        Gizmos.DrawWireMesh(mesh, this.transform.position, this.transform.rotation);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/38.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E7%90%83%E4%BD%93%E7%BD%91%E6%A0%BC%E7%BA%BF/2.png)

### 更多Gizmos相关

官方文档：[Gizmos](https://docs.unity3d.com/ScriptReference/Gizmos.html)