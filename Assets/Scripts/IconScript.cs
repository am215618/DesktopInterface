using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Sets the icon
    public Icon icon;
    Image iconImage;
    Text iconText;

    GameObject draggingIcon;
    RectTransform draggingTransform;

    public float startingPositionX;
    public float startingPositionY;
    bool isBeingHeld = false;

    //OnValidate will modify the private variables in the editor.
    void OnValidate()
    {
        iconImage = transform.GetChild(0).GetComponent<Image>();
        iconText = GetComponentInChildren<Text>();

        iconImage.sprite = icon.iconSprite;
        iconText.text = icon.iconName;
    }

    // Start is called before the first frame update
    void Start()
    {
        iconImage = GetComponentInChildren<Image>();
        iconText = GetComponentInChildren<Text>();

        iconImage.sprite = icon.iconSprite;
        iconText.text = icon.iconName;
    }

    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //We set the
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        draggingIcon = Instantiate(this.gameObject);

        draggingIcon.transform.SetParent(canvas.transform, false);
        draggingIcon.transform.SetAsLastSibling();

        IconScript draggingIconScript = draggingIcon.GetComponent<IconScript>();
        Destroy(draggingIconScript);

        var image = draggingIcon.GetComponent<Image>();

        image.color = new Color(0f, 0f, 0.5f, 1f);
        image.GetComponentInChildren<Image>().sprite = null;
        image.GetComponentInChildren<Image>().color = new Color(0, 0, 0.5f, 1);
        image.GetComponentInChildren<Text>().color = Color.white;

        //image.SetNativeSize();

        if (isBeingHeld)
            draggingTransform = transform as RectTransform;
        else
            draggingTransform = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData data)
    {
        if (draggingIcon != null)
            SetDraggedPosition(data);
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (isBeingHeld && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            draggingTransform = data.pointerEnter.transform as RectTransform;

        var rt = draggingIcon.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingTransform, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = draggingTransform.rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = draggingIcon.transform.position;

        if (draggingIcon != null)
            Destroy(draggingIcon);
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
}
