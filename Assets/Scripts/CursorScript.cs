using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorScript : MonoBehaviour
{
    Canvas canvas;
    Color cursorColour;

    Image outline;

    void Start()
    {
        cursorColour = ThemeManager.instance.cursorColour;
        canvas = transform.parent.GetComponent<Canvas>();
        outline = transform.GetChild(0).GetComponent<Image>();

        if (cursorColour.r <= 0.5f && cursorColour.g <= 0.5f && cursorColour.b <= 0.5f)
        {
            outline.color = Color.white;
        }
        else
        {
            outline.color = Color.black;
        }

        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Update()
    {
        Cursor.visible = false;
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out mousePos);
        transform.position = canvas.transform.TransformPoint(mousePos) - new Vector3(-16.1f, 16.1f, 0);
    }
}
