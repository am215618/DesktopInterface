using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorScript : MonoBehaviour, IPointerClickHandler
{
    //Cursor Variables
    Canvas canvas;
    Color cursorColour;

    Image outline;
    public GameObject shadow;
    public float cursorShadowOffset;
    bool cursorShadow;

    void Start()
    {
        //Sets the variables
        cursorColour = ThemeManager.instance.cursorColour;
        canvas = transform.parent.GetComponent<Canvas>();
        outline = transform.GetChild(0).GetComponent<Image>();
        cursorShadow = ThemeManager.instance.cursorShadow;

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

    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            ThemeManager.instance.onClick?.Invoke();
        }
    }

    void LateUpdate()
    {
        //toggles the default cursor (the normal one) to not visible.
        Cursor.visible = false;
        //checks the cursor position and puts a slight offset so that the cursor looks like its in the correct position but it isn't.
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out mousePos);
        transform.position = canvas.transform.TransformPoint(mousePos) - new Vector3(-16, 16, 0);
        shadow.transform.position = transform.position + new Vector3(cursorShadowOffset, -cursorShadowOffset, 0);
    }

    public void ToggleShadow(bool showShadow)
    {
        shadow.SetActive(showShadow);
    }

    void OnMouseDown()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    void Clicked()
    {
        Debug.Log("Click");
    }
}
