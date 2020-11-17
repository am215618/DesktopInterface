using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorScript : MonoBehaviour
{
    //Variables
    Canvas canvas;
    Color cursorColour;

    Image outline;

    void Start()
    {
        //Sets the variables
        cursorColour = ThemeManager.instance.cursorColour;
        canvas = transform.parent.GetComponent<Canvas>();
        outline = transform.GetChild(0).GetComponent<Image>();

        //Changes the colour of the cursor's outline, which is dependent on the colour.
        if (cursorColour.r <= 0.5f && cursorColour.g <= 0.5f && cursorColour.b <= 0.5f)
        {
            outline.color = Color.white;
        }
        else
        {
            outline.color = Color.black;
        }

        //toggles the default cursor (the normal one) to not visible.
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        //toggles the default cursor (the normal one) to not visible.
        Cursor.visible = false;
        //checks the cursor position and puts a slight offset so that the cursor looks like its in the correct position but it isn't.
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out mousePos);
        transform.position = canvas.transform.TransformPoint(mousePos) - new Vector3(-16.1f, 16.1f, 0);
    }
}
