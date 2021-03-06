﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeThemeElement : MonoBehaviour, IPointerClickHandler
{
    //The elements that can have different colours.
    public enum DesktopElement
    {
        Background,
        ActiveTitleBar, 
        InactiveTitleBar,
        Taskbar,
        ToolTip,
        SelectedIcon
    }
    public DesktopElement desktopElement;
    ThemeManager themeManager;

    //Grabs the variables for the colour picker and the header
    public ColourPicker colourPicker;
    public Text colourPickerHeader;

    void Start()
    {
        themeManager = ThemeManager.instance;

        switch (desktopElement) //Sets each of the colour sliders to the respective variable in the theme manager.
        {
            case DesktopElement.Background:
                GetComponent<Image>().color = themeManager.backgroundColour;
                break;
            case DesktopElement.ActiveTitleBar:
                GetComponent<Image>().color = themeManager.activeTitleBarColour;
                break;
            case DesktopElement.InactiveTitleBar:
                GetComponent<Image>().color = themeManager.inactiveTitleBarColour;
                break;
            case DesktopElement.Taskbar:
                GetComponent<Image>().color = themeManager.TaskbarColour;
                break;
            case DesktopElement.ToolTip:
                GetComponent<Image>().color = themeManager.toolTipColour;
                break;
            case DesktopElement.SelectedIcon:
                GetComponent<Image>().color = themeManager.SelectedColour;
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (desktopElement) //Changes the colour of the theme element.
        {
            case DesktopElement.Background:
                colourPicker.changingComponent = ColourPicker.ComponentChanging.Background;
                colourPickerHeader.text = "Background";
                colourPicker.image = this.GetComponent<Image>();
                colourPicker.Start();
                break;
            case DesktopElement.ActiveTitleBar:
                colourPicker.changingComponent = ColourPicker.ComponentChanging.ActiveTitleBar;
                colourPickerHeader.text = "Active Title Bar";
                colourPicker.image = this.GetComponent<Image>();
                colourPicker.Start();
                break;
            case DesktopElement.InactiveTitleBar:
                colourPicker.changingComponent = ColourPicker.ComponentChanging.InactiveTitleBar;
                colourPickerHeader.text = "Inactive Title Bar";
                colourPicker.image = this.GetComponent<Image>();
                colourPicker.Start();
                break;
            case DesktopElement.Taskbar:
                colourPicker.changingComponent = ColourPicker.ComponentChanging.Taskbar;
                colourPickerHeader.text = "Taskbar";
                colourPicker.image = this.GetComponent<Image>();
                colourPicker.Start();
                break;
            case DesktopElement.ToolTip:
                colourPicker.changingComponent = ColourPicker.ComponentChanging.Tooltip;
                colourPickerHeader.text = "Tooltips";
                colourPicker.image = this.GetComponent<Image>();
                colourPicker.Start();
                break;
            case DesktopElement.SelectedIcon:
                colourPicker.changingComponent = ColourPicker.ComponentChanging.Selected;
                colourPickerHeader.text = "Selected Icon";
                colourPicker.image = this.GetComponent<Image>();
                colourPicker.Start();
                break;
        }
    }
}
