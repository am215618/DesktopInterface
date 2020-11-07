using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipScript : MonoBehaviour
{
    public static ToolTipScript instance;

    Image image;
    Text toolTipText;
    RectTransform backgroundRectTransform;

    void Awake()
    {
        instance = this;
        image = GetComponentInChildren<Image>();
        toolTipText = image.GetComponentInChildren<Text>();
        backgroundRectTransform = GetComponentInParent<RectTransform>();
        HideToolTip();
    }

    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint;

        Vector2 anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
        if (anchoredPosition.x + backgroundRectTransform.rect.width > transform.parent.GetComponent<RectTransform>().rect.width)
        {
            anchoredPosition.x = transform.parent.GetComponent<RectTransform>().rect.width - backgroundRectTransform.rect.width;
        }
        /*else if (anchoredPosition.x - backgroundRectTransform.rect.width < 0)
        {
            anchoredPosition.x = backgroundRectTransform.rect.width;
        }*/

        if (anchoredPosition.y + backgroundRectTransform.rect.height > transform.parent.GetComponent<RectTransform>().rect.height)
        {
            anchoredPosition.y = transform.parent.GetComponent<RectTransform>().rect.height - backgroundRectTransform.rect.height;
        }
        /*else if (anchoredPosition.y - backgroundRectTransform.rect.height < 0)
        {
            anchoredPosition.y = backgroundRectTransform.rect.height;
        }*/

        //transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }

    public void ShowToolTip(string toolTipString)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();

        toolTipText.text = toolTipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth + textPaddingSize * 2f, toolTipText.preferredHeight + textPaddingSize * 2f);
        image.GetComponent<RectTransform>().sizeDelta = backgroundSize;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
}
