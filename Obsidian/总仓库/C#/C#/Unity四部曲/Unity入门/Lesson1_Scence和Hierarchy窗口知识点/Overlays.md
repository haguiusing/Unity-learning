## Overlays

Unity authoring tools are available as Overlay panels in the **Scene view** window to make them more accessible and improve your workflow. You can customize which Overlays are shown, their placement in the **Scene view** window, and save your customized Overlay configurations as presets to reuse and share.

You can also [create custom Overlays](https://docs.unity.cn/cn/2021.3/Manual/overlays-custom.html).[[Create custom Overlays]]

Default Editor Overlays

![Overlays](https://docs.unity.cn/cn/2021.3/uploads/Main/overlays-default-view.png)

Overlays

|||
|---|---|
|A|[Tools](https://docs.unity.cn/cn/2021.3/Manual/PositioningGameObjects.html)|
|B|[View Options](https://docs.unity.cn/cn/2021.3/Manual/ViewModes.html)|
|C|[Grid and Snap Toolbar](https://docs.unity.cn/cn/2021.3/Manual/GridSnapping.html)|
|D|[Orientation](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html)|
|E|[Search](https://docs.unity.cn/cn/2021.3/Manual/Searching.html)|
|F|[Tool Settings](https://docs.unity.cn/cn/2021.3/Manual/PositioningGameObjects.html#GizmoHandlePositions)|

[Display and hide](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#displaying-overlays)

[Position](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#positioning-overlays)

[Dock](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#docking-overlays)

[Collapse and expand](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#collapsing-overlays)

[Snap](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#snapping-overlays)

[Change orientation](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#changing-orientation-overlays)

[Save configurations](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#saving-configuration-overlays)

[Switch configurations](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#switching-configuration-overlays)

[Import and export configurations](https://docs.unity.cn/cn/2021.3/Manual/overlays.html#importing-configuration-overlays)

### Display and hide Overlays

1. Click anywhere in the **Scene view** and select the Spacebar to open the **Overlays** menu.
2. Click the Overlay you want to display or hide. If the Overlay is already displayed, an eye icon appears to its left. When you rollover a displayed option, the Overlay highlights in blue in the **Scene view**.

![Overlays menu](https://docs.unity.cn/cn/2021.3/uploads/Main/overlays-menu-open.png)

Overlays menu

#### Hide all Overlays

Toggle all your configured Overlays to hide/show by pressing the backtick ( **`** ).

### Position Overlays

To reposition an Overlay in the **Scene view**:

- Click and hold the handle (**=**) or click the header of the Overlay and drag it to the desired position in the **Scene view**.

**Note:** You can overlap Overlays that are floating in the **Scene view**. Click on the Overlay to bring an Overlay to the front.

### Dock Overlays

To dock an Overlay to the top, bottom, or side of the **Scene view**:

- Click and hold the handle (**=**) of the Overlay or click the header of the Overlay and drag it over the boundary of the **Scene view** until the boundary is highlighted in blue and release it. The Overlay will dock itself at the highlighted position.

To move an Overlay into a position occupied by another docked Overlay:

- Drag the Overlay until the blue highlight indicates the desired position and release. The Overlays will rearrange themselves.

**Note:** An Overlay that is not a toolbar (for example, Orientation) will collapse when docked. Access the Overlay’s options by clicking the down arrow.

### Collapse and expand Overlays

To collapse an Overlay, right-click the handle (**=**) or click the border of the Overlay and select Collapse.

To expand, right-click and select **Expand**.

### Snap Overlays

To snap an Overlay to a corner of the **Scene view**:

- Click and hold the handle (**=**) of the Overlay and drag it to a corner of the **Scene view** until a blue highlighted square appears and release it.

**Note:** Snapping several Overlays into the corner does not snap them to each other. Each Overlay remains snapped to the corner until you change its position.

### Change Overlay orientation

Some Overlays allow you to select a vertical or horizontal orientation.

To change an Overlay’s orientation:

- Right-click the handle (**=**) and select **Horizontal** or **Vertical**.
- If the Overlay is floating or snapped in the **Scene view**, select **Panel** to change the Overlay into a named panel.

### Save Overlay configurations

You can save your Overlay configurations to easily switch configurations in your project.

To save your Overlay configuration as a preset:

1. Press the spacebar to open the Overlays menu.
2. From the drop-down menu, choose **Save Preset**.
3. Name the preset and click **Save**.  
    The preset is saved to the drop-down menu.

**Note:** When you save an Overlay preset in this way, it does not create a file that you can load to another project, but saved presets are available to any Unity project on your computer.

Overlay configurations are also saved when you save the Editor layout.

### Switch Overlay configurations

To switch your Overlay configuration:

1. Press the spacebar to open the Overlays menu.
    
2. Choose an Overlay preset from the drop-down list.
    
    The Overlay configuration is shown in the **Scene view**.
    

### Import and export Overlay configurations

To import an Overlay configuration into your project:

1. Press the spacebar to open the Overlays menu.
2. From the drop-down menu, choose **Load Preset From File**.
3. Browse to the preset .wpr file and click **Open**. The preset is added to the drop-down menu.

To export an Overlay configuration, save it as a .wpr file and then import it into another project:

1. Press the spacebar to open the Overlays menu.
2. From the drop-down menu, choose **Save Preset to File**.
3. Name the preset and click **Save**. The preset is saved to a folder and in the drop-down menu.