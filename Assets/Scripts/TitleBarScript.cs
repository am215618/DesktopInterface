using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TitleBarScript : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    //Variables
    WindowScript windowScript;
    RectTransform draggingTransform; 
    Canvas canvas;
    Image titleBarImage;

    void Start()
    {
        //Sets the variables
        windowScript = GetComponentInParent<WindowScript>();
        draggingTransform = windowScript.GetComponent<RectTransform>();
        canvas = ThemeManager.instance.ui;
        titleBarImage = GetComponent<Image>();

        //Sets the colour of the titlebar to the active colour.
        titleBarImage.color = ThemeManager.instance.activeTitleBarColour;
        if (ThemeManager.instance.activeTitleBarColour.r <= 0.5f && ThemeManager.instance.activeTitleBarColour.g <= 0.5f && ThemeManager.instance.activeTitleBarColour.b <= 0.5f)
            GetComponentInChildren<Text>().color = Color.white;
        else
            GetComponentInChildren<Text>().color = Color.black;
    }

    //When the title bar is being dragged it will move the entire window.
    public void OnDrag(PointerEventData eventData)
    {
        draggingTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //Sets the window to the last sibling and on top of everything in that canvas.
    public void OnPointerDown(PointerEventData eventData)
    {
        draggingTransform.SetAsLastSibling();
        ThemeManager.instance.SetActiveWindow(windowScript);

        //If the window is on top then it would change the colour to the active colour, otherwise it will change to the inactive colour.
        if (windowScript.activeWindow)
        {
            titleBarImage.color = ThemeManager.instance.activeTitleBarColour;
        }
        else
        {
            titleBarImage.color = ThemeManager.instance.inactiveTitleBarColour;
        }
        //Changes the colour of the text, which is dependent of the title bar.
        if (ThemeManager.instance.activeTitleBarColour.r <= 0.5f && ThemeManager.instance.activeTitleBarColour.g <= 0.5f && ThemeManager.instance.activeTitleBarColour.b <= 0.5f)
            GetComponentInChildren<Text>().color = Color.white;
        else
            GetComponentInChildren<Text>().color = Color.black;
    }
}
