using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson46_EditorApplication : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 EditorApplication公共类是用来干什么的？

        //它是 Unity 编辑器中的一个公共类，它主要提供了一些和编辑器本身相关的一些功能
        //比如 编辑器事件监听（播放、暂停等）、生命周期判断（是否运行中、暂停中、编译中）
        //     编辑器进入播放模式、退出播放模式 等等功能

        #endregion

        #region 知识点二 创建自定义面板用于进行知识讲解

        #endregion

        #region 知识点三 常用API

        //1.监听编辑器事件
        //  EditorApplication.update：每帧更新事件，可以用于在编辑器中执行一些逻辑
        //  EditorApplication.hierarchyChanged：层级视图变化事件，当场景中的对象发生变化时触发
        //  EditorApplication.projectChanged：项目变化事件，当项目中的资源发生变化时触发
        //  EditorApplication.playModeStateChanged：编辑器播放状态变化时触发
        //  EditorApplication.pauseStateChanged：编辑器暂停状态变化时触发

        //2.管理编辑器生命周期相关
        //  EditorApplication.isPlaying：判断当前是否处于游戏运行状态。
        //  EditorApplication.isPaused：判断当前游戏是否处于暂停状态。
        //  EditorApplication.isCompiling：判断Unity编辑器是否正在编译代码
        //  EditorApplication.isUpdating：判断Unity编辑器是否正在刷新AssetDatabase

        //3.获取Unity应用程序路径相关
        //  EditorApplication.applicationContentsPath：Unity安装目录Data路径
        //  EditorApplication.applicationPath：Unity安装目录可执行程序路径

        //4.常用方法
        //  EditorApplication.Exit(0)：退出Unity编辑器
        //  EditorApplication.ExitPlaymode()：退出播放模式，切换到编辑模式
        //  EditorApplication.EnterPlaymode()：进入播放模式

        #endregion

        #region 知识点四 更多内容

        //官方文档
        //EditorApplication： https://docs.unity3d.com/2022.3/Documentation/ScriptReference/EditorApplication.html
        //EditorSceneManager：https://docs.unity3d.com/2022.3/Documentation/ScriptReference/SceneManagement.EditorSceneManager.html

        #endregion
    }
}
