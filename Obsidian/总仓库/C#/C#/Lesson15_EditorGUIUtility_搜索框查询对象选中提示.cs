using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson15_EditorGUIUtility_搜索框查询对象选中提示 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 搜索框查询

        //  主要作用：
        //  弹出一个搜索窗口，用于选择自己想要的资源
        //  主要API：
        //  EditorGUIUtility.ShowObjectPicker<资源类型>(默认被选中的对象, 是否允许查找场景对象, "查找对象名称过滤", 0);
        //  参数1. 默认被选中的对象的引用
        //  参数2. 是否允许查找场景对象
        //  参数3. 查找对象名称过滤（默认搜索过滤 比如这里的normal是指文件名称中有normal的会被搜索到）
        //  参数4. controlID, 默认写0

        //  获取选择对象：
        //  主要API：
        //  EditorGUIUtility.GetObjectPickerObject()

        //  弹出的搜索窗口会通过发送事件的形式
        //  通知开启它的窗口对象信息的变化
        //  通过Event公共类可以获取其它窗口发送给自己的事件
        //  Event.current 获取当前事件
        //  commandName 获取事件命令的名字
        //      ObjectSelectorUpdated 对象选择发生变化时发送
        //      ObjectSelectorClosed 对象选择窗口关闭时发送
        //  if(Event.current.commandName == "ObjectSelectorUpdated")
        //  {
        //    当选择发生更新时通知进入
        //
        //  }
        //  else if (Event.current.commandName == "ObjectSelectorClosed")
        //  {
        //    当选择窗口关闭时通知进入
        //  }

        #endregion

        #region 知识点二 对象选中提示

        //EditorGUIUtility.PingObject(想要提示选中的对象);

        #endregion
    }
}
