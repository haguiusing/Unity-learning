using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson41_EditorUtility_文件面板相关 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 显示 文件 存储面板

        //通常用于在编辑器中保存新创建的文件或选择文件的保存路径
        //string path = EditorUtility.SaveFilePanel("窗口标题", "打开的目录", "保存的文件的名称", "文后缀格式")

        #endregion

        #region 知识点二 显示 文件 存储面板(默认指定在Asset文件夹中)

        //与 SaveFilePanel 类似，但是它将保存路径限制在项目目录中，只允许用户选择项目内的文件夹作为保存路径
        //string path = EditorUtility.SaveFilePanelInProject("窗口标题", "保存的文件的名称", "后缀格式", "在对话框窗口中显示的文本摘要");

        #endregion

        #region 知识点三 显示 文件夹 存储面板

        //通常用于在编辑器中选择文件夹作为保存路径，用于保存文件或执行其他与文件夹相关的操作
        //string path = EditorUtility.SaveFolderPanel("窗口标题", "文件夹", "默认名称");

        #endregion

        #region 知识点四 显示打开 文件 面板

        //通常用于在编辑器中选择文件进行打开或执行其他与文件相关的操作
        //string path = EditorUtility.OpenFilePanel("窗口标题", "文件路径", "后缀格式");

        #endregion

        #region 知识点五 显示打开 文件夹 面板

        //通常用于在编辑器中选择文件夹进行打开或执行其他与文件夹相关的操作
        //string path = EditorUtility.OpenFolderPanel("窗口标题", "文件夹", "默认名称");

        #endregion
    }
}
