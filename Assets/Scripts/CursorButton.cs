using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorButton : MonoBehaviour
{
    public bool cursorID;
    public bool showOutline;
    CursorChanger cursorChanger;

    public void Start()
    {
        cursorChanger = GetComponentInParent<CursorChanger>();
    }

    public void ChangeCursor()
    {
        cursorChanger.previewImage.sprite = transform.GetChild(0).GetComponent<Image>().sprite;
        cursorChanger.previewHasNoSeparateOutline = showOutline;
    }
}
