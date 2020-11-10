using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TitleBarScript : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    WindowScript windowScript;
    [SerializeField] RectTransform draggingTransform;
    [SerializeField] Canvas canvas;
    Image titleBarImage;

    void Start()
    {
        windowScript = GetComponentInParent<WindowScript>();
        draggingTransform = transform.parent.GetComponentInParent<RectTransform>();
        canvas = ThemeManager.instance.ui;
        titleBarImage = GetComponent<Image>();

        titleBarImage.color = ThemeManager.instance.activeTitleBarColour;
        if (ThemeManager.instance.activeTitleBarColour.r <= 0.5f && ThemeManager.instance.activeTitleBarColour.g <= 0.5f && ThemeManager.instance.activeTitleBarColour.b <= 0.5f)
            GetComponentInChildren<Text>().color = Color.white;
        else
            GetComponentInChildren<Text>().color = Color.black;
    }

    void Update()
    {
        //gameObject.GetComponent<RectTransform>().rect.width = windowScript.gameObject.GetComponent<RectTransform>().width;
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggingTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        draggingTransform.SetAsLastSibling();
        ThemeManager.instance.SetActiveWindow(windowScript);
        if (windowScript.activeWindow)
        {
            titleBarImage.color = ThemeManager.instance.activeTitleBarColour;
        }
        else
        {
            titleBarImage.color = ThemeManager.instance.inactiveTitleBarColour;
        }
        if (ThemeManager.instance.activeTitleBarColour.r <= 0.5f && ThemeManager.instance.activeTitleBarColour.g <= 0.5f && ThemeManager.instance.activeTitleBarColour.b <= 0.5f)
            GetComponentInChildren<Text>().color = Color.white;
        else
            GetComponentInChildren<Text>().color = Color.black;
    }
}
