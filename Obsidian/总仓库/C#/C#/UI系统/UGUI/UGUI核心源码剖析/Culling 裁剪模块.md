## Culling 裁剪模块
![[Pasted image 20250416224031.png]]
Culling 里是对模型裁剪的工具类，大都用在了 Mask 遮罩上，只有 Mask 才有裁剪的需求。
里面四个文件，其中一个是静态类，一个是接口类。
### IClipRegion：存放IClipper和IClippable
#### IClipper：
``` cs
	// Interface that can be used to recieve clipping callbacks as part of the canvas update loop.
    // 可用于接受裁剪回调（裁剪是画布更新循环的一部分）的接口。
    // 实现该接口的元素（目前只有RectMask2D），将对其“实现了 IClippable 接口”的子物体进行裁剪。
    public interface IClipper
    {
        // Function to to cull / clip children elements.
        // Called after layout and before Graphic update of the Canvas update loop.
        // 在 CanvasUpdate 循环中, 方法在 LayoutUpdate 与 GraphicUpdate 之间被调用。
        void PerformClipping();
    }
```
#### IClippable：
``` cs
    // Interface for elements that can be clipped if they are under an IClipper
    // 实现该接口的元素（目前只有MaskableGraphic），如果作为“实现了 IClipper 接口”的元素（目前只有RectMask2D）的子物体，则可被裁剪。
    public interface IClippable
    {
        // 实现了 IClippable 接口的组件所在的 GameObject
        GameObject gameObject { get; }
 
        // Will be called when the state of a parent IClippable changed.
        // “实现了 IClipper 接口”的元素（目前只有RectMask2D）状态改变时，调用其“实现了 IClippable 接口”的子物体的该方法。
        // 状态改变包括：OnEnable、OnDisable、OnValidate（编辑器下）。
        void RecalculateClipping();
 
        // The RectTransform of the clippable.
        // 实现了 IClippable 接口的组件关联的 RectTransform。
        RectTransform rectTransform { get; }
 
        // Clip and cull the IClippable given a specific clipping rect
        // 裁剪和剔除 IClippable 给定的裁剪矩形
        // 参数"clipRect"：The Rectangle in which to clip against. 裁剪本物体的矩形 （来自RectMask2D）。
        // 参数"validRect"：Is the Rect valid. If not then the rect has 0 size. 矩形是否有效。若无效，则矩形的大小视为0（不裁剪）。
        void Cull(Rect clipRect, bool validRect);
 
        // Set the clip rect for the IClippable.
        // 设置裁剪矩形。
        // 参数"value"：The Rectangle for the clipping.  裁剪本物体的矩形 （来自RectMask2D）。
        // 参数"validRect"：Is the rect valid.  矩形是否有效。
        void SetClipRect(Rect value, bool validRect);
    }
```
Cllipping：
``` cs
using System.Collections.Generic;
 
namespace UnityEngine.UI
{
    // Utility class to help when clipping using IClipper.
    // 使用 IClipper 进行裁剪时的工具类。
    public static class Clipping
    {
        // Find the Rect to use for clipping.
        // Given the input RectMask2ds find a rectangle that is the overlap of all the inputs.
        // 找到用于剪切的矩形。
        // 输入一个 RectMask2d 列表，找到与所有输入矩形都重叠的矩形。（所有输入矩形的总交集）
        // 参数"rectMaskParents"：RectMasks to build the overlap rect from. //
        // 参数"validRect"：Was there a valid Rect found.
        // 返回值：The final compounded overlapping rect.
        //---------------------------------------------------------------
        // 这个方法决定了，有多个 RectMask2d 嵌套时，是怎么处理的！
        //---------------------------------------------------------------
        public static Rect FindCullAndClipWorldRect(List<RectMask2D> rectMaskParents, out bool validRect)
        {
            //列表为空，返回无效和默认Rect
            if (rectMaskParents.Count == 0)
            {
                validRect = false;  
                return new Rect();
            }
 
            Rect current = rectMaskParents[0].canvasRect; //取第一个 RectMask2D 在 Canvas空间下的 Rect。
            float xMin = current.xMin;
            float xMax = current.xMax;
            float yMin = current.yMin;
            float yMax = current.yMax;
            for (var i = 1; i < rectMaskParents.Count; ++i)   //遍历取交集
            {
                current = rectMaskParents[i].canvasRect;     //取其他 RectMask2D 在 Canvas空间下的 Rect。
 
                //取交集：取所有RectMask2D 的 xMin 和 yMin 的最大值 和 xMax 和 yMax 的最小值。
                if (xMin < current.xMin)
                    xMin = current.xMin;
                if (yMin < current.yMin)
                    yMin = current.yMin;
                if (xMax > current.xMax)
                    xMax = current.xMax;
                if (yMax > current.yMax)
                    yMax = current.yMax;
            }
 
            validRect = xMax > xMin && yMax > yMin; //总交集是否有效
            if (validRect)
                return new Rect(xMin, yMin, xMax - xMin, yMax - yMin);  //返回总交集
            else
                return new Rect();
        }
    }
}
```
ClipperRegistry：
``` cs
using System.Collections.Generic;
using UnityEngine.UI.Collections;

namespace UnityEngine.UI
{
    // Registry class to keep track of all IClippers that exist in the scene
    // This is used during the CanvasUpdate loop to cull clippable elements. The clipping is called after layout, but before Graphic update.
    // 一个用于跟踪场景中所有 实现了 IClipper 接口的对象的 注册表类。
    // 这是在 CanvasUpdate 循环期间用来剔除可剪切元素的。方法在 LayoutUpdate 与 GraphicUpdate 之间被调用。
    public class ClipperRegistry
    {
        static ClipperRegistry s_Instance;

        readonly IndexedSet<IClipper> m_Clippers = new IndexedSet<IClipper>();

        protected ClipperRegistry()
        {
            // This is needed for AOT platforms. Without it the compile doesn't get the definition of the Dictionarys
            // 这是 AOT 平台所需要的。没有它，编译器就得不到字典的的定义。
            // 疑问???
#pragma warning disable 168
            Dictionary<IClipper, int> emptyIClipperDic;
#pragma warning restore 168
        }

        // The singleton instance of the clipper registry.
        // ClipperRegistry 单例
        public static ClipperRegistry instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new ClipperRegistry();
                return s_Instance;
            }
        }

        // Perform the clipping on all registered IClipper
        // 在所有注册的 IClipper 上执行裁剪
        public void Cull()
        {
            for (var i = 0; i < m_Clippers.Count; ++i)
            {
                m_Clippers[i].PerformClipping();
            }
        }

        // Register a unique IClipper element
        // 注册一个特定 IClipper 元素
        public static void Register(IClipper c)
        {
            if (c == null)
                return;
            instance.m_Clippers.AddUnique(c);
        }

        // UnRegister a IClipper element
        // 将 IClipper 元素从注册中移除
        public static void Unregister(IClipper c)
        {
            instance.m_Clippers.Remove(c);
        }
    }
}
```
RectangularVertexClipper：
``` cs
namespace UnityEngine.UI
{
    internal class RectangularVertexClipper
    {
        readonly Vector3[] m_WorldCorners = new Vector3[4];
        readonly Vector3[] m_CanvasCorners = new Vector3[4];
 
        //获取 t在Canvas下的 rect (包括位置和大小)
        public Rect GetCanvasRect(RectTransform t, Canvas c)
        {
            if (c == null)
                return new Rect();
 
            t.GetWorldCorners(m_WorldCorners);  //取t的世界坐标
            var canvasTransform = c.GetComponent<Transform>();
            for (int i = 0; i < 4; ++i)
                m_CanvasCorners[i] = canvasTransform.InverseTransformPoint(m_WorldCorners[i]);  //将世界坐标转为相对Canvas的local坐标
 
            //返回t在Canvas下的 rect (包括位置和大小)
            return new Rect(m_CanvasCorners[0].x, m_CanvasCorners[0].y, m_CanvasCorners[2].x - m_CanvasCorners[0].x, m_CanvasCorners[2].y - m_CanvasCorners[0].y);
        }
    }
}
```


