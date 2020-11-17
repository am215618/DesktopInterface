using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipScript : MonoBehaviour
{
    //a static instance would allow the script to be accessed anywhere as long as there is one object with this script attached.
    public static ToolTipScript instance;

    void Awake() //Sets the instance to the object its attached too. There can only be one of this type of instance.
    {
        instance = this;
    }

    //private variables.
    Image image;
    Text toolTipText;
    RectTransform backgroundRectTransform;

    //Here we set those private variables, made the tooltip the colour of the Tooltip and hides the tooltip.
    void Start()
    {
        image = GetComponentInChildren<Image>();
        toolTipText = image.GetComponentInChildren<Text>();
        backgroundRectTransform = GetComponentInParent<RectTransform>();
        image.color = ThemeManager.instance.toolTipColour;

        if (image.color.r <= 0.5f && image.color.g <= 0.5f && image.color.b <= 0.5f)
            toolTipText.color = Color.white;
        else
            toolTipText.color = Color.black;

        HideToolTip();
    }

    void Update()
    {
        //This updates the tooltips' position to the mouse position.
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint;

        Vector2 anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
        if (anchoredPosition.x + backgroundRectTransform.rect.width > transform.parent.GetComponent<RectTransform>().rect.width)
        {
            anchoredPosition.x = transform.parent.GetComponent<RectTransform>().rect.width - backgroundRectTransform.rect.width;
        }

        if (anchoredPosition.y + backgroundRectTransform.rect.height > transform.parent.GetComponent<RectTransform>().rect.height)
        {
            anchoredPosition.y = transform.parent.GetComponent<RectTransform>().rect.height - backgroundRectTransform.rect.height;
        }
    }

    //Shows the tooltip when it is called.
    public void ShowToolTip(string toolTipString)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();

        //Sets the properties of the tooltip, including the text, some padding and the size of the background.
        toolTipText.text = toolTipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth + textPaddingSize * 2f, toolTipText.preferredHeight + textPaddingSize * 2f);
        image.GetComponent<RectTransform>().sizeDelta = backgroundSize;
    }

    //Hides the tooltip
    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
}
