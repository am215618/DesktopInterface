using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerExitHandler
{
    //Sets the icon
    public Icon icon;
    Image iconImage;
    Text iconText;
    Canvas canvas;

    GameObject draggingIcon;
    RectTransform draggingTransform;

    [SerializeField] GameObject window;

    public bool canDrag;

    int clickCount = 0;
    int openOnClickCount = 2;

    float clickDelay;
    float maxClickDelay;
    // Start is called before the first frame update
    void Start()
    {
        maxClickDelay = ThemeManager.instance.maxClickDelay;

        iconImage = transform.GetChild(0).GetComponentInChildren<Image>();
        iconText = GetComponentInChildren<Text>();

        canvas = ThemeManager.instance.ui;

        iconImage.sprite = icon.iconSprite;
        iconText.text = icon.iconName;
        window = icon.window;
    }

    void Update()
    {
        clickDelay -= Time.deltaTime;
        if (clickDelay <= 0) clickCount = 0;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            draggingIcon = Instantiate(this.gameObject);

            draggingIcon.transform.SetParent(canvas.transform, false);
            draggingIcon.transform.SetAsLastSibling();

            IconScript draggingIconScript = draggingIcon.GetComponent<IconScript>();
            Destroy(draggingIconScript);

            var image = draggingIcon.GetComponent<Image>();

            image.color = new Color(0f, 0f, 0.5f, 1f);
            image.GetComponentInChildren<Image>().sprite = null;
            image.GetComponentInChildren<Image>().color = ThemeManager.instance.SelectedColour;
            image.GetComponentInChildren<Text>().color = Color.white;

            draggingIcon.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if(canDrag)
            draggingIcon.GetComponent<RectTransform>().anchoredPosition += data.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            this.transform.position = draggingIcon.transform.position;

            if (draggingIcon != null)
                Destroy(draggingIcon);
        }
    }

    void OnMouseDown()
    {
        clickCount++;
        clickDelay = maxClickDelay;

        Debug.Log(clickCount);

        if (clickCount == 1)
        {
            GetComponent<Image>().color = ThemeManager.instance.SelectedColour;
            if (GetComponent<Image>().color.r <= 0.5f && GetComponent<Image>().color.g <= 0.5f && GetComponent<Image>().color.b <= 0.5f)
            {
                GetComponentInChildren<Text>().color = Color.white;
            }
            else
            {
                GetComponentInChildren<Text>().color = Color.black;
            }
        }
        else if (clickCount == openOnClickCount)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Instantiate(window, canvas.transform);
            clickCount = 0;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickCount++;
        clickDelay = maxClickDelay;

        Debug.Log(clickCount);

        if(clickCount == 1)
        {
            GetComponent<Image>().color = ThemeManager.instance.SelectedColour;
        }
        else if (clickCount == openOnClickCount)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Instantiate(window, canvas.transform);
            clickCount = 0;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        clickCount = 0;
    }
}
