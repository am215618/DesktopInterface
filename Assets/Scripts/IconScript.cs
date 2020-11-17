using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;


[ExecuteInEditMode()]
#endif
public class IconScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerExitHandler
{
#if UNITY_EDITOR
    //This creates a clone of the icon in the scene in the icon space.
    [MenuItem("GameObject/UI/Icon")]
    public static void AddIcon()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("DefaultObjects/Icon"));
        obj.transform.parent = ThemeManager.instance.ui.GetComponentInChildren<GridLayoutGroup>().transform;
    }
#endif

    //Variables.
    ThemeManager tm;

    public Icon icon;
    Image iconImage;
    Text iconText;
    Canvas canvas;

    GameObject draggingIcon;

    public GameObject window;

    public bool canDrag;

    int clickCount = 0;
    int openOnClickCount = 2;

    float clickDelay;
    float maxClickDelay;

    void Awake()
    {
        tm = ThemeManager.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        //sets some variables
        maxClickDelay = 1;

        iconImage = transform.GetChild(0).GetComponentInChildren<Image>();
        iconText = GetComponentInChildren<Text>();

        canvas = GetComponentInParent<Canvas>();

        if (icon != null)
        {
            iconImage.sprite = icon.iconSprite;
            iconText.text = icon.iconName;
            window = icon.window;
        }
    }

    //Updates the click delay relative to time.
    void Update()
    {
        clickDelay -= Time.deltaTime;
        if (clickDelay <= 0) clickCount = 0;
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            //Creates a clone of the icon and moves it when the other icon is selected
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
            //moves the cloned object.
            draggingIcon.GetComponent<RectTransform>().anchoredPosition += data.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //moves the original icon to the cloned icons position and removes the clone from the scene.
        if (canDrag)
        {
            this.transform.position = draggingIcon.transform.position;

            if (draggingIcon != null)
                Destroy(draggingIcon);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Counts the number of clicks and changes the delay to the maximum click delay, which is ticked down in Update()
        clickCount++;
        clickDelay = maxClickDelay;

        //one click will make the icon in a selected state.
        if (clickCount == 1)
        {
            GetComponent<Image>().color = ThemeManager.instance.SelectedColour;
        }
        else if (clickCount == openOnClickCount) //Opens the window attached to the icon and makes the click count equal to 0.
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Instantiate(window, canvas.transform);
            clickCount = 0;
        }
    }

    public void OnPointerExit(PointerEventData eventData) //makes the click count equal to 0 and makes the colour null.
    {
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        clickCount = 0;
    }
}
