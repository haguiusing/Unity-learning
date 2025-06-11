using System;
using UnityEditor;
using UnityEngine;

public class MyEditorApplicationLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyEditorApplicationLearnWindow")]
    private static void OpenMyEditorApplicationLearnWindow()
    {
        MyEditorApplicationLearnWindow win =
            EditorWindow.GetWindow<MyEditorApplicationLearnWindow>("EditorApplication知识学习");
        win.Show();
    }

    //1.监听编辑器事件
    //  EditorApplication.update：每帧更新事件，可以用于在编辑器中执行一些逻辑
    //  EditorApplication.hierarchyChanged：层级视图变化事件，当场景中的对象发生变化时触发
    //  EditorApplication.projectChanged：项目变化事件，当项目中的资源发生变化时触发
    //  EditorApplication.playModeStateChanged：编辑器播放状态变化时触发
    //  EditorApplication.pauseStateChanged：编辑器暂停状态变化时触发
    private void OnEnable()
    {
        EditorApplication.update += MyUpdate;
    }

    private void OnDestroy()
    {
        EditorApplication.update -= MyUpdate;
    }

    void MyUpdate()
    {
        // Debug.Log("更新");  

        //2.管理编辑器生命周期相关
        //  EditorApplication.isPlaying：判断当前是否处于游戏运行状态。
        //  EditorApplication.isPaused：判断当前游戏是否处于暂停状态。
        //  EditorApplication.isCompiling：判断Unity编辑器是否正在编译代码
        //  EditorApplication.isUpdating：判断Unity编辑器是否正在刷新AssetDatabase
        if (EditorApplication.isPlaying)
        {
            Debug.Log("处于运行播放状态");
        }
    }

    private void OnGUI()
    {
        //3.获取Unity应用程序路径相关
        //  EditorApplication.applicationContentsPath：Unity安装目录Data路径
        //  EditorApplication.applicationPath：Unity安装目录可执行程序路径
        if (GUILayout.Button("打印Unity安装路径"))
        {
            Debug.Log(EditorApplication.applicationContentsPath);//D:/Software/Unity/UnityEditor/2022.3.17f1c1/Editor/Data
            Debug.Log(EditorApplication.applicationPath);//D:/Software/Unity/UnityEditor/2022.3.17f1c1/Editor/Unity.exe
        }


        //4.常用方法
        //  EditorApplication.Exit(0)：退出Unity编辑器
        //  EditorApplication.ExitPlaymode()：退出播放模式，切换到编辑模式
        //  EditorApplication.EnterPlaymode()：进入播放模式
        if (GUILayout.Button("进入播放模式"))
        {
            EditorApplication.EnterPlaymode();
        }
        if (GUILayout.Button("退出播放模式"))
        {
            EditorApplication.ExitPlaymode();
        }
    }
}
