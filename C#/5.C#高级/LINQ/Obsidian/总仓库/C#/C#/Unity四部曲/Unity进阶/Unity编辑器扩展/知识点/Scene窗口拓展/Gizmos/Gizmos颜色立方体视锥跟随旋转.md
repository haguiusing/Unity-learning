![[Lesson35_Scene窗口拓展_Gizmos_颜色立方体视锥跟随旋转.cs]]

### Gizmos修改颜色
Gizmos.color = Color.xx;
```cs
private void OnDrawGizmosSelected()
{
    // Gizmos绘制立方体
    Gizmos.color = Color.green;
}
```
### Gizmos绘制立方体
Gizmos.DrawCube(中心点, 大小);  
Gizmos.DrawWireCube(中心点, 大小);
```cs
private void OnDrawGizmosSelected()
{
    // Gizmos绘制立方体
    Gizmos.color = Color.green;
    Gizmos.DrawCube(Vector3.zero, Vector3.one);
    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(this.transform.position, new Vector3(2, 1, 3));
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/35.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E9%A2%9C%E8%89%B2%E7%AB%8B%E6%96%B9%E4%BD%93%E8%A7%86%E9%94%A5%E8%B7%9F%E9%9A%8F%E6%97%8B%E8%BD%AC/1.png)
### Gizmos绘制视锥
Gizmos.DrawFrustum(绘制中心, FOV(Field of View,视野)角度, 远裁切平面, 近裁切平面, 屏幕长宽比);
```cs
private void OnDrawGizmosSelected()
{
    // Gizmos绘制视锥
    Gizmos.color = Color.yellow;
    Gizmos.DrawFrustum(this.transform.position, 30, 50, 0.5f, 1.7f);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/35.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E9%A2%9C%E8%89%B2%E7%AB%8B%E6%96%B9%E4%BD%93%E8%A7%86%E9%94%A5%E8%B7%9F%E9%9A%8F%E6%97%8B%E8%BD%AC/2.png)

### 如何改变绘制内容的角度
注意：Gizmos绘制立方体和视锥是不能跟随对象旋转的，我们要自行处理

修改Gizmos绘制前的矩阵  
Gizmos.matrix  
Gizmos.matrix = Matrix4x4.TRS(位置, 角度, 缩放);  
还原矩阵  
Gizmos.matrix = Matrix4x4.identity
```cs
private void OnDrawGizmosSelected()
{
    // 将绘制矩阵还原，以下绘制的对象不会跟随旋转
    Gizmos.matrix = Matrix4x4.identity;

    // Gizmos绘制立方体
    Gizmos.color = Color.green;
    Gizmos.DrawCube(Vector3.zero, Vector3.one);
    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(this.transform.position, new Vector3(2, 1, 3));

    // Gizmos绘制视锥
    Gizmos.color = Color.yellow;
    Gizmos.DrawFrustum(this.transform.position, 30, 50, 0.5f, 1.7f);

    // 将绘制矩阵该为某个对象的，这样就可以跟着移动、旋转、缩放了
    Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
    Gizmos.color = Color.white;
    //绘制会跟随对象旋转的空心立方体
    Gizmos.DrawWireCube(Vector3.zero, new Vector3(2, 1, 4));
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/35.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Gizmos-%E9%A2%9C%E8%89%B2%E7%AB%8B%E6%96%B9%E4%BD%93%E8%A7%86%E9%94%A5%E8%B7%9F%E9%9A%8F%E6%97%8B%E8%BD%AC/3.png)
