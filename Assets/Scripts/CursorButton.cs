using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CursorButton : MonoBehaviour
{
    //Toggles if the outline of the cursor is shown.
    public bool showOutline;
    CursorChanger cursorChanger;

    public void Start()
    {
        //Sets the cursor changer to the parent of the object this is attached to.
        cursorChanger = GetComponentInParent<CursorChanger>();
    }
    
    //This will change the cursor.
    public void ChangeCursor()
    {
        cursorChanger.previewImage.sprite = transform.GetChild(0).GetComponent<Image>().sprite;
        cursorChanger.previewHasNoSeparateOutline = showOutline;
    }
}
