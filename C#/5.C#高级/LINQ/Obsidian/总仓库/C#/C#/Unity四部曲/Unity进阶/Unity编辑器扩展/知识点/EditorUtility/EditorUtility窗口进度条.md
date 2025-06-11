![[EditorUtility是什么#^34c7f2]]

![[Lesson40_EditorUtility_编辑器默认窗口相关.cs]]


### 显示提示窗口
EditorUtility.DisplayDialog(“标题”, “显示信息”, “确定键名”);  
注意：窗口显示会阻塞逻辑 即一定要对提示窗口做处理后才会显示其他逻辑
```cs
private void OnGUI()
{
    if(GUILayout.Button("显示提示窗口"))
    {
        if(EditorUtility.DisplayDialog("测试窗口", "确定一定要做这件事情吗", "一定要做"))
        {
            Debug.Log("确定要做，在这里去处理逻辑");
        }
        else
        {
            Debug.Log("点击了叉叉，不去做");
        }

        Debug.Log("窗口显示完毕");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/40.EditorUtility-%E7%BC%96%E8%BE%91%E5%99%A8%E9%BB%98%E8%AE%A4%E7%AA%97%E5%8F%A3%E7%9B%B8%E5%85%B3/1.png)

### 显示三键提示面板
int EditorUtility.DisplayDialogComplex(“标题”, “显示信息”, “按钮1名字”, “按钮3名字”, “按钮2名字”);  
返回值 0-按钮1按下 1-按钮3按下 2-按钮2按下  
注意：窗口显示会阻塞逻辑
```cs
private void OnGUI()
{
    if(GUILayout.Button("显示三键提示窗口"))
    {
        int result = EditorUtility.DisplayDialogComplex("三键提示", "显示信息", "选项1", "关闭", "选项2");
        switch (result)
        {
            case 0:
                Debug.Log("选项1按下了");
                break;
            case 1:
                Debug.Log("关闭键按下了");
                break;
            case 2:
                Debug.Log("选项2按下了");
                break;
            default:
                break;
        }

        Debug.Log("三键窗口显示完毕");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/40.EditorUtility-%E7%BC%96%E8%BE%91%E5%99%A8%E9%BB%98%E8%AE%A4%E7%AA%97%E5%8F%A3%E7%9B%B8%E5%85%B3/2.png)

### 进度条相关
显示进度条  
EditorUtility.DisplayProgressBar(“进度条”, “显示信息”, 进制值0~1);

关闭进度条  
EditorUtility.ClearProgressBar();

注意：进度条窗口不会卡逻辑，但是需要配合关闭进度条使用
```cs
private void OnGUI()
{        
    if(GUILayout.Button("显示更新进度条"))
    {
        //每次点击加进度条进度
        value += 0.1f;
        EditorUtility.DisplayProgressBar("进度条标题", "进度条窗口显示内容", value);
        Debug.Log("进度条窗口显示完毕");
    }

    if(GUILayout.Button("关闭进度条"))
    {
        value = 0;
        EditorUtility.ClearProgressBar();
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/40.EditorUtility-%E7%BC%96%E8%BE%91%E5%99%A8%E9%BB%98%E8%AE%A4%E7%AA%97%E5%8F%A3%E7%9B%B8%E5%85%B3/3.png)

