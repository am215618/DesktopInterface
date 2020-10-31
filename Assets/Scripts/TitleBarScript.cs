using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TitleBarScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    WindowScript windowScript;
    [SerializeField] RectTransform draggingTransform;
    [SerializeField] Canvas canvas;

    void Start()
    {
        windowScript = GetComponentInParent<WindowScript>();
        draggingTransform = transform.parent.GetComponentInParent<RectTransform>();
        canvas = ThemeManager.instance.ui;
    }

    void Update()
    {
        //gameObject.GetComponent<RectTransform>().rect.width = windowScript.gameObject.GetComponent<RectTransform>().width;
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggingTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        draggingTransform.SetAsLastSibling();
    }
}
