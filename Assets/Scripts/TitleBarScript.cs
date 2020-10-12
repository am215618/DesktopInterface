using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TitleBarScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    bool isBeingHeld = false;
    WindowScript windowScript;
    public RectTransform draggingTransform;

    void Start()
    {
        windowScript = GetComponent<WindowScript>();
    }

    void Update()
    {
        //gameObject.GetComponent<RectTransform>().rect.width = windowScript.gameObject.GetComponent<RectTransform>().width;
    }

    void SetDraggedPosition(PointerEventData eventData)
    {
        if (isBeingHeld && eventData.pointerEnter != null && eventData.pointerEnter.transform as RectTransform != null)
            draggingTransform = eventData.pointerEnter.transform as RectTransform;

        var rt = GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingTransform, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = draggingTransform.rotation;
        }
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        if (isBeingHeld)
            draggingTransform = transform as RectTransform;
        else
            draggingTransform = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
