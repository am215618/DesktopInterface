﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//In a nutshell this is where all the theme settings are stored as well as some public variables and functions.
public class ThemeManager : MonoBehaviour
{
    #region Singleton
    public static ThemeManager instance;

    void Validate()
    {
        instance = this;
    }
    #endregion

    public delegate void OnClick();
    public OnClick onClick;

    public Canvas ui;
    public Canvas cursorCanvas;
    public Canvas taskbarCanvas;

    public GameObject iconSpace;
    public GameObject cursor;
    public GameObject taskbar;
    public GameObject tooltip;

    Text[] iconTexts;

    Image[] taskbarImages;
    Text[] taskbarTexts;

    WindowScript activeWindow;

    public Color backgroundColour;
    public Color activeTitleBarColour;
    public Color inactiveTitleBarColour;
    public Color TaskbarColour; 
    public Color cursorColour;
    public Color toolTipColour; //includes the popup you see in the notification
    public Color SelectedColour; //Selected Icons

    public Sprite maximiseButton;
    public Sprite unmaximiseButton;

    public bool cursorShadow;

    public List<TitleBarScript> titleBarScripts;

    private void OnValidate()
    {
        Validate();

        Camera.main.backgroundColor = backgroundColour;
        cursor.GetComponent<Image>().color = cursorColour;

        iconTexts = iconSpace.GetComponentsInChildren<Text>();
        taskbarImages = taskbar.GetComponentsInChildren<Image>();
        taskbarTexts = taskbar.GetComponentsInChildren<Text>();

        UpdateTheme();
    }
    private void Awake()
    {
        OnValidate();
    }

    //This changes the colours of the theme
    public void UpdateTheme()
    {
        Camera.main.backgroundColor = backgroundColour;
        tooltip.GetComponentInChildren<Image>().color = toolTipColour;
        
        for (int i = 0; i < titleBarScripts.Count; i++)
        {
            if(titleBarScripts[i].GetComponentInParent<WindowScript>().activeWindow)
                titleBarScripts[i].gameObject.GetComponent<Image>().color = activeTitleBarColour;
            else
                titleBarScripts[i].gameObject.GetComponent<Image>().color = inactiveTitleBarColour;
        }

        for (int i = 0; i < iconTexts.Length; i++)
        {
            if (backgroundColour.r <= 0.5f && backgroundColour.g <= 0.5f && backgroundColour.b <= 0.5f)
            {
                iconTexts[i].color = Color.white;
            }
            else
            {
                iconTexts[i].color = Color.black;
            }
        }

        for (int i = 0; i < taskbarImages.Length; i++)
        {
            if (taskbarImages[i].gameObject.tag != "Icon")
            {
                taskbarImages[i].color = TaskbarColour;
            }
        }

        for (int i = 0; i < taskbarTexts.Length; i++)
        {
            if (TaskbarColour.r <= 0.5f && TaskbarColour.g <= 0.5f && TaskbarColour.b <= 0.5f)
            {
                taskbarTexts[i].color = Color.white;
            }
            else
            {
                taskbarTexts[i].color = Color.black;
            }
        }
    }

    //Sets the window activity and it's title bar colours.
    public void SetActiveWindow(WindowScript openWindow)
    {
        if (activeWindow != null)
        {
            activeWindow.activeWindow = false;
            activeWindow.SetWindowActivity();
        }
        activeWindow = openWindow;
        activeWindow.activeWindow = true;
        activeWindow.SetWindowActivity();
    }

    //Sets the opened window as an active window.
    public void OpenWindow(WindowScript openWindow)
    {
        if(activeWindow != null)
        {
            activeWindow.activeWindow = false;
        }
        activeWindow = openWindow;
        SetActiveWindow(openWindow);
    }
}
