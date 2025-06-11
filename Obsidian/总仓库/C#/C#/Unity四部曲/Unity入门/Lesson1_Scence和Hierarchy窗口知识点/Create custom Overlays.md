# Create custom Overlays

You can create custom panel Overlays and toolbar Overlays for your **Scene view** window.

- [Panel Overlays](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#panel-overlays)
- [Toolbar Overlays](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#toolbar-overlays)

**Tip:** For information about creating UIElements, see the [UI Elements Developer Guide](https://docs.unity.cn/Manual/UIElements.html).

## The EditorToolbarElement

A toolbar element can contain text, an icon, or a combination of the two.

Use [`EditorToolbarElement(Identifier, EditorWindowType)`] to register toolbar elements for use in `ToolbarOverlay` implementations.

You may inherit any VisualElement type and provide styling yourself, but toolbar elements require specific styling, so it is preferable to inherit one of the predefined `EditorToolbar` types:

- EditorToolbarButton - based on `UnityEditor.UIElements.ToolbarButton`
- EditorToolbarDropdown - based on `EditorToolbarButton`
- EditorToolbarDropdownToggle - based on `UnityEngine.UIElements.BaseField&lt;bool>`
- EditorToolbarToggle - based on `UnityEditor.UIElements.ToolbarToggle`

**Tip:** If a toolbar is docked horizontally or vertically the text will be clipped or not visible, so specify an icon for each.

## Panel Overlays

All Overlays must inherit the Overlay base class and implement the CreatePanelContent() method. This creates a basic panel that you can use as-is or add toolbar elements.

1. Create a new [C# script](https://docs.unity.cn/Manual/CreatingAndUsingScripts.html) in your [Editor](https://docs.unity.cn/Manual/SpecialFolders.html) folder and name it.
2. Open your new script.
3. Remove the boilerplate content between the main curly brackets and implement the `Overlay`class in the namespace `UnityEditor.Overlays`.
4. Override the `CreatePanelContent` function and add your content to the visual element.
5. Add the `Overlay`attribute to the class and specify which type of window this Overlay will be available in. Specifying `EditorWindow` as the type, will make the Overlay available in all Editor windows, specifying `SceneView` will make the Overlay available in Scene view only.
6. Add the name, ID, and display name.
7. Optional: Add the `Icon`attribute to the `Overlay`class to specify which icon to use in condensed mode. If no icon is specified, then by default the system uses the first two letters of the Overlay name (or the first two initial letters of the first two words).

### 示例

```
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine.UIElements;
[Overlay(typeof(SceneView), "My Custom Toolbar", true)]
public class MyToolButtonOverlay : Overlay
{
    public override VisualElement CreatePanelContent()
    {
        var root = new VisualElement() { name = "My Toolbar Root" };
        root.Add(new Label() { text = "Hello" });
        return root;

    }
}
```

## Toolbar Overlays

Toolbar Overlays are containers that hold toolbar items and are composed of collections of `EditorToolbarElement`.

Toolbar Overlays have built-in horizontal, vertical, and panel layouts. ToolbarOverlay implements a parameterless constructor, passing the EditorToolbarElementAttribute ID. Unlike panel Overlays, the contents are defined as standalone pieces that are collected to form a strip of elements.

1. As with panel Overlays, start by creating a C# script and saving it in your Editor folder, then open and edit your script.
2. Add toolbar elements.
3. Add the toolbar elements to the Overlay constructor.
4. Add the panel Overlay and implement with the toolbar elements.

When creating toolbar Overlays:

- Use `[EditorToolbarElement(Identifier, EditorWindowType)]` to register toolbar elements for use in the `ToolbarOverlay` implementation.
- All Overlays must be tagged with the `OverlayAttribute`
- Toolbar Overlays must inherit `ToolbarOverlay` and implement a parameter-less constructor.
- The contents of a toolbar are populated with string IDs, which are passed to the base constructor.
- IDs are defined by `EditorToolbarElementAttribute`.
- `Icon` attribute defines the icon visible when an Overlay is collapsed. If not provided, the first two letters of the Overlay name (or the first two initial letters of the first two words) are used.

When implementing ToolbarOverlay-specific elements in an Overlay:

- The IAccessContainerWindow interface is for toolbar only, therefore, the element won’t be aware of its context. In the DropdownToggleExample, toggling the element won’t do anything.
- The toolbar element won’t carry its styling in an Overlay. Use UIElement styling for visuals.

### 示例

This example demonstrates an Overlay named _Element Toolbars Example_ that demonstrates toolbar elements:

- EditorToolbarButton
- EditorToolbarToggle
- EditorToolbarDropdown
- EditorToolbarDropdownToggle

Each toolbar element is created as a standalone class and then added to the Overlay panel.

- It can be arranged as a panel, horizontally, and vertically.
- The buttons include text and tooltips.
- The toolbar has icons defined by the `Icon`attribute which will be visible when the toolbar is collapsed.

```
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using UnityEngine;
    using UnityEditor.EditorTools;
    using UnityEditor.Toolbars;
    using UnityEditor.Overlays;
    using UnityEngine.UIElements;
    using UnityEditor;

    // Use [EditorToolbarElement(Identifier, EditorWindowType)] to register toolbar elements for use in ToolbarOverlay implementation.

    [EditorToolbarElement(id, typeof(SceneView))]
    class DropdownExample : EditorToolbarDropdown
    {
        public const string id = "ExampleToolbar/Dropdown";

        static string dropChoice = null;

        public DropdownExample()
        {
            text = "Axis";
            clicked += ShowDropdown;
        }

        void ShowDropdown()
        {
            var menu = new GenericMenu();
            menu.AddItem(new GUIContent("X"), dropChoice == "X", () => { text = "X"; dropChoice = "X"; });
            menu.AddItem(new GUIContent("Y"), dropChoice == "Y", () => { text = "Y"; dropChoice = "Y"; });
            menu.AddItem(new GUIContent("Z"), dropChoice == "Z", () => { text = "Z"; dropChoice = "Z"; });
            menu.ShowAsContext();
        }
    }
    [EditorToolbarElement(id, typeof(SceneView))]
    class ToggleExample : EditorToolbarToggle
    {
        public const string id = "ExampleToolbar/Toggle";
        public ToggleExample()
        {
            text = "Toggle OFF";
            this.RegisterValueChangedCallback(Test);
        }

        void Test(ChangeEvent<bool> evt)
        {
            if (evt.newValue)
            {
                Debug.Log("ON");
                text = "Toggle ON";
            }
            else
            {
                Debug.Log("OFF");
                text = "Toggle OFF";
            }
        }
    }

    [EditorToolbarElement(id, typeof(SceneView))]
    class DropdownToggleExample : EditorToolbarDropdownToggle, IAccessContainerWindow
    {
        public const string id = "ExampleToolbar/DropdownToggle";

        // This property is specified by IAccessContainerWindow and is used to access the Overlay's EditorWindow.

        public EditorWindow containerWindow { get; set; }
        static int colorIndex = 0;
        static readonly Color[] colors = new Color[] { Color.red, Color.green, Color.cyan };
        public DropdownToggleExample()
        {
            text = "Color Bar";
            tooltip = "Display a color rectangle in the top left of the Scene view. Toggle on or off, and open the dropdown" +
                      "to change the color.";

        // When the dropdown is opened, ShowColorMenu is invoked and we can create a popup menu.

            dropdownClicked += ShowColorMenu;

        // Subscribe to the Scene view OnGUI callback so that we can draw our color swatch.

            SceneView.duringSceneGui += DrawColorSwatch;
        }

        void DrawColorSwatch(SceneView view)
        {

         // Test that this callback is for the Scene View that we're interested in, and also check if the toggle is on
        // or off (value).

            if (view != containerWindow || !value)
            {
                return;
            }

            Handles.BeginGUI();
            GUI.color = colors[colorIndex];
            GUI.DrawTexture(new Rect(8, 8, 120, 24), Texture2D.whiteTexture);
            GUI.color = Color.white;
            Handles.EndGUI();
        }

        // When the dropdown button is clicked, this method will create a popup menu at the mouse cursor position.

        void ShowColorMenu()
        {
            var menu = new GenericMenu();
            menu.AddItem(new GUIContent("Red"), colorIndex == 0, () => colorIndex = 0);
            menu.AddItem(new GUIContent("Green"), colorIndex == 1, () => colorIndex = 1);
            menu.AddItem(new GUIContent("Blue"), colorIndex == 2, () => colorIndex = 2);
            menu.ShowAsContext();
        }
    }

    [EditorToolbarElement(id, typeof(SceneView))]
    class CreateCube : EditorToolbarButton//, IAccessContainerWindow
    {
        // This ID is used to populate toolbar elements.

        public const string id = "ExampleToolbar/Button";

        // IAccessContainerWindow provides a way for toolbar elements to access the `EditorWindow` in which they exist.
        // Here we use `containerWindow` to focus the camera on our newly instantiated objects after creation.
        //public EditorWindow containerWindow { get; set; }

        // Because this is a VisualElement, it is appropriate to place initialization logic in the constructor.
        // In this method you can also register to any additional events as required. In this example there is a tooltip, an icon, and an action.

        public CreateCube()
        {

    // A toolbar element can be either text, icon, or a combination of the two. Keep in mind that if a toolbar is
        // docked horizontally the text will be clipped, so usually it's a good idea to specify an icon.

            text = "Create Cube";
            icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/CreateCubeIcon.png");
            tooltip = "Instantiate a cube in the scene.";
            clicked += OnClick;
        }

        // This method will be invoked when the `Create Cube` button is clicked.

        void OnClick()
        {
            var newObj = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;

        // When writing editor tools don't forget to be a good citizen and implement Undo!

            Undo.RegisterCreatedObjectUndo(newObj.gameObject, "Create Cube");

        //if (containerWindow is SceneView view)
        //    view.FrameSelected();

        }

    }

    // All Overlays must be tagged with the OverlayAttribute

    [Overlay(typeof(SceneView), "ElementToolbars Example")]

        // IconAttribute provides a way to define an icon for when an Overlay is in collapsed form. If not provided, the name initials are used.

    [Icon("Assets/unity.png")]

    // Toolbar Overlays must inherit `ToolbarOverlay` and implement a parameter-less constructor. The contents of a toolbar are populated with string IDs, which are passed to the base constructor. IDs are defined by EditorToolbarElementAttribute.

    public class EditorToolbarExample : ToolbarOverlay
    {

     // ToolbarOverlay implements a parameterless constructor, passing the EditorToolbarElementAttribute ID.
    // This is the only code required to implement a toolbar Overlay. Unlike panel Overlays, the contents are defined
    // as standalone pieces that will be collected to form a strip of elements.

        EditorToolbarExample() : base(
            CreateCube.id,
            ToggleExample.id,
            DropdownExample.id,
            DropdownToggleExample.id
            )
        { }
    }


```

### Toolbar elements implementation

- [Creating custom Overlays](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#creating-custom-overlays)
- [Using EditorToolbarElement](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#using-editortoolbarelement)
- [Panel Overlays](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#panel-overlays)
    - [Example](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#example)
- [Toolbar Overlays](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#toolbar-overlays)
    - [Example](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#example-1)
    - [Toolbar elements implementation](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#toolbar-elements-implementation)
    - [EditorToolbarButton](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#editortoolbarbutton)
    - [EditorToolbarToggle](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#editortoolbartoggle)
    - [EditorToolbarDropdown](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#editortoolbardropdown)
    - [EditorToolbarDropdownToggle](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#editortoolbardropdowntoggle)
    - [Panel Overlay](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html#panel-overlay)

After adding the toolbar elements, implement the [Overlay](https://docs.unity.cn/cn/2021.3/Manual/add-elements-to-panel) panel.

The controls are the same as their equivalent in UIToolkit but inherit some toolbar functionalities (like collapse state, orientation, and panel) and specific styling.

#### EditorToolbarButton

A standalone class that will contain all the logic of the element. Here is an example of a button that creates a cube when clicked.

```
[EditorToolbarElement(id, typeof(SceneView))]
class CreateCube : EditorToolbarButton
{
// This ID is used to populate toolbar elements.

public const string id = "ExampleToolbar/Button";   

// Because this is a VisualElement, it is appropriate to place initialization logic in the constructor.

// In this method you can also register to any additional events as required. In this example there is a tooltip, an icon, and an action.

    public CreateCube()
       {

// A toolbar element can be either text, icon, or a combination of the two. Keep in mind that if a toolbar is docked horizontally the text will be clipped, so it's a good idea to specify an icon.

            text = "Create Cube";
            icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/CreateCubeIcon.png");
            tooltip = "Instantiate a cube in the scene.";
            clicked += OnClick;
}

void OnClick()
{
    var newObj = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;

    // When writing editor tools, don't forget to be a good citizen and implement Undo.

    Undo.RegisterCreatedObjectUndo(newObj.gameObject, "Create Cube");

// Note: Using ObjectFactory class instead of GameObject(like in this example) will register the undo entry automatically removing the need to register manually.

}
}
```

Add the element’s ID to the Overlay constructor:

```
[Overlay(typeof(SceneView), "ElementToolbar Example")]
[Icon("Assets/unity.png")]
public class EditorToolbarExample : ToolbarOverlay
{
    EditorToolbarExample() : base(CreateCube.id) { }

}
```

#### EditorToolbarToggle

Create a standalone class that contains all the logic of the element. Here is a simple example of a toggle that prints its state in the console and updates its text in the element.

```
[EditorToolbarElement(id, typeof(SceneView))]
class ToggleExample : EditorToolbarToggle
{
    public const string id = "ExampleToolbar/Toggle";
    public ToggleExample()
    {
        text = "Toggle OFF";

    // Register the class to a callback for when the toggle’s state changes

        this.RegisterValueChangedCallback(OnStateChange);
    }

    void OnStateChange(ChangeEvent<bool> evt)
    {
        if (evt.newValue)
        {

    // Put logic for when the state is ON here

                Debug.Log("Toggle State -> ON");
        text = "Toggle ON";
        }
        else
        {

    // Put logic for when the state is OFF here

                Debug.Log("Toggle State -> OFF");
        text = "Toggle OFF";
        }
    }
}
```

Add the element’s ID to the Overlay constructor:

```
[[Overlay(typeof(SceneView), "ElementToolbar Example")]
[Icon("Assets/unity.png")]
public class EditorToolbarExample : ToolbarOverlay
{
    EditorToolbarExample() : base(
ToggleExample.id
) { }

}

```

#### EditorToolbarDropdown

Create a standalone class that contains all the logic of the element. Here is a simple example of a drop-down that adjusts its text with the drop-down selection.

```
[EditorToolbarElement(id, typeof(SceneView))]
class DropdownExample : EditorToolbarDropdown
{
    public const string id = "ExampleToolbar/Dropdown";

    static string dropChoice = null;

    public DropdownExample()
    {
        text = "Axis";
        clicked += ShowDropdown;
    }

    void ShowDropdown()
    {

// A simple GenericMenu to populate the dropdown content

        var menu = new GenericMenu();
        menu.AddItem(new GUIContent("X"), dropChoice == "X", () => { text = "X"; dropChoice = "X"; });
        menu.AddItem(new GUIContent("Y"), dropChoice == "Y", () => { text = "Y"; dropChoice = "Y"; });
        menu.AddItem(new GUIContent("Z"), dropChoice == "Z", () => { text = "Z"; dropChoice = "Z"; });
        menu.ShowAsContext();
    }
}
```

Add the element’s ID to the Overlay constructor:

```
[Overlay(typeof(SceneView), "ElementToolbar Example")]
[Icon("Assets/unity.png")]
public class EditorToolbarExample : ToolbarOverlay
{
    EditorToolbarExample() : base(
DropdownExample.id
) { }

}
```

#### EditorToolbarDropdownToggle

Create a standalone class that contains all the logic of the element. A drop-down toggle is a dropdown that can also be toggled (Like the Gizmo menu in the Scene view). This example creates a colored rectangle in the corner of the Scene view when toggled with the color chosen from the dropdown.

```
[EditorToolbarElement(id, typeof(SceneView))]
class DropdownToggleExample : EditorToolbarDropdownToggle, IAccessContainerWindow
{
    public const string id = "ExampleToolbar/DropdownToggle";


    // This property is specified by IAccessContainerWindow and is used to access the Overlay's EditorWindow.

    public EditorWindow containerWindow { get; set; }
    static int colorIndex = 0;
    static readonly Color[] colors = new Color[] { Color.red, Color.green, Color.cyan };
    public DropdownToggleExample()
    {
        text = "Color Bar";
        tooltip = "Display a color rectangle in the top left of the Scene view. Toggle on or off, and open the dropdown" +
                "to change the color.";


   // When the dropdown is opened, ShowColorMenu is invoked and you can create a pop-up menu.

        dropdownClicked += ShowColorMenu;


    // Subscribe to the Scene view OnGUI callback to draw a color swatch.

        SceneView.duringSceneGui += DrawColorSwatch;
    }


    void DrawColorSwatch(SceneView view)
    {

        // Test that this callback is for the correct Scene view, and check if the toggle is on
     // or off (value).

        if (view != containerWindow || !value)
        {
            return;
        }


        Handles.BeginGUI();
            GUI.color = colors[colorIndex];
        GUI.DrawTexture(new Rect(8, 8, 120, 24), Texture2D.whiteTexture);
        GUI.color = Color.white;
        Handles.EndGUI();
    }


    // When the drop-down button is clicked, this method creates a pop-up menu at the mouse cursor position.

    void ShowColorMenu()
    {
        var menu = new GenericMenu();
        menu.AddItem(new GUIContent("Red"), colorIndex == 0, () => colorIndex = 0);
        menu.AddItem(new GUIContent("Green"), colorIndex == 1, () => colorIndex = 1);
        menu.AddItem(new GUIContent("Blue"), colorIndex == 2, () => colorIndex = 2);
        menu.ShowAsContext();
    }
}
```

Add the element’s ID to the Overlay constructor:

```
[Overlay(typeof(SceneView), "ElementToolbar Example")]
[Icon("Assets/unity.png")]
public class EditorToolbarExample : ToolbarOverlay
{
    EditorToolbarExample() : base(
DropdownToggleExample.id
) { }


}
```

#### Panel Overlay

Implement the Panel Overlay and add the toolbar element standalone classes. In the example below, all of the toolbar elements are included to demonstrate how to add multiple elements to a toolbar. Toolbar elements must be included in the Panel Overlay to be visible.

```
[Overlay(typeof(SceneView), "ElementToolbar Example")]
[Icon("Assets/unity.png")]
public class EditorToolbarExample : Overlay
{
    public override VisualElement CreatePanelContent()
    {
        var root = new VisualElement() { name = "My Tool Root" };
        root.Add(new CreateCube());
        root.Add(new ToggleExample());
        root.Add(new DropdownExample());
        root.Add(new DropdownToggleExample());
        return root;
    }
}
```