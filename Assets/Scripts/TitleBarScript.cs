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
        titleBarImage.color = ThemeManager.instance.activeTitleBarColour;
    }
}
