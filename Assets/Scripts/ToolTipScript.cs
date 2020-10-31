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

    public Vector3 toolTipOffset;

    void Awake()
    {
        instance = this;
        image = GetComponentInChildren<Image>();
        toolTipText = image.GetComponentInChildren<Text>();
        backgroundRectTransform = image.GetComponentInParent<RectTransform>();
        HideToolTip();
    }

    void Update()
    {
        image.color = ThemeManager.instance.toolTipColour;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, Input.mousePosition + toolTipOffset, null, out localPoint);
        transform.localPosition = localPoint;

        Vector2 anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
        if(anchoredPosition.x + backgroundRectTransform.rect.width > transform.parent.GetComponent<RectTransform>().rect.width)
        {
            anchoredPosition.x = transform.parent.GetComponent<RectTransform>().rect.width - backgroundRectTransform.rect.width - toolTipOffset.x;
        }
        else if (anchoredPosition.x - backgroundRectTransform.rect.width < 0)
        {
            anchoredPosition.x = backgroundRectTransform.rect.width + toolTipOffset.x;
        }

        if (anchoredPosition.y + backgroundRectTransform.rect.height > transform.parent.GetComponent<RectTransform>().rect.height)
        {
            anchoredPosition.y = transform.parent.GetComponent<RectTransform>().rect.height - backgroundRectTransform.rect.height - toolTipOffset.y;
        }
        else if (anchoredPosition.y - backgroundRectTransform.rect.height < 0)
        {
            anchoredPosition.y = backgroundRectTransform.rect.height + toolTipOffset.y;
        }

        transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }

    public void ShowToolTip(string toolTipString)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();

        toolTipText.text = toolTipString;
        float textPaddingSize = 2f;
        Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth + textPaddingSize * 2f, toolTipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
}
