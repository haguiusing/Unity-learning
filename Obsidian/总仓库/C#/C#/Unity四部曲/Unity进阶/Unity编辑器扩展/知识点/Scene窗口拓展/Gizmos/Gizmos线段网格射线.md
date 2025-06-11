![[Lesson37_Scene窗口拓展_Gizmos_线段网格射线.cs]]

### Gizmos绘制线段
Gizmos.DrawLine(起点, 终点);
```cs
private void OnDrawGizmosSelected()
{
    // Gizmos绘制线段
    Gizmos.color = Color.red;
    Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.one);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/37.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E7%BA%BF%E6%AE%B5%E7%BD%91%E6%A0%BC%E5%B0%84%E7%BA%BF/1.png)
### Gizmos绘制网格
Gizmos.DrawMesh(mesh, 位置, 角度);
```cs
private void OnDrawGizmosSelected()
{
    // Gizmos绘制网格
    Gizmos.color = Color.blue;
    if (mesh != null)
        Gizmos.DrawMesh(mesh, this.transform.position, this.transform.rotation);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/37.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E7%BA%BF%E6%AE%B5%E7%BD%91%E6%A0%BC%E5%B0%84%E7%BA%BF/2.png)
### Gizmos绘制射线
Gizmos.DrawRay(起点, 方向);
```cs
private void OnDrawGizmosSelected()
{
    // Gizmos绘制射线
    Gizmos.color = Color.green;
    Gizmos.DrawRay(this.transform.position, this.transform.forward);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/37.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E7%BA%BF%E6%AE%B5%E7%BD%91%E6%A0%BC%E5%B0%84%E7%BA%BF/3.png)