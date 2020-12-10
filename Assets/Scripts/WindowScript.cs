using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;


[ExecuteInEditMode()]
#endif
public class WindowScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
#if UNITY_EDITOR
    //This would add the object into the scene and put it as a child to the desktop canvas
    [MenuItem("GameObject/UI/Window")]
    public static void AddWindow()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("DefaultObjects/WindowTemplete"));
        obj.transform.parent = ThemeManager.instance.ui.transform;
    }
#endif
    //variables for defining the window.
    RectTransform rect;

    public bool spawnTaskbarObj;

    public Image titleBarIcon;
    public Text titleBarText;

    public GameObject taskbarObject;
    GameObject instancedTaskbarObj;

    public bool minimised;
    public bool maximised;

    Image maximiseButton;

    Vector2 originalWindowSize;

    [HideInInspector] public bool activeWindow = false;
    public bool destroyOnClose;
    private void Awake() 
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    void Start()
    {
        rect = GetComponent<RectTransform>();
        if (spawnTaskbarObj) //Sets a new game object to a instance of a taskbar object.
        {
            instancedTaskbarObj = Instantiate(taskbarObject);
            instancedTaskbarObj.GetComponent<TaskbarButtonScript>().window = this.gameObject;
        }
        ThemeManager.instance.OpenWindow(this);
    }

    public void SetWindowActivity() //sets the title bar's colour whenever the window changes activity.
    {
        if (GetComponentInChildren<TitleBarScript>() != null)
        {
            if (activeWindow)
            {
                GetComponentInChildren<TitleBarScript>().GetComponent<Image>().color = ThemeManager.instance.activeTitleBarColour;
            }
            else
            {
                GetComponentInChildren<TitleBarScript>().GetComponent<Image>().color = ThemeManager.instance.inactiveTitleBarColour;
            }
            if (ThemeManager.instance.activeTitleBarColour.r <= 0.5f && ThemeManager.instance.activeTitleBarColour.g <= 0.5f && ThemeManager.instance.activeTitleBarColour.b <= 0.5f)
                GetComponentInChildren<TitleBarScript>().GetComponentInChildren<Text>().color = Color.white;
            else
                GetComponentInChildren<TitleBarScript>().GetComponentInChildren<Text>().color = Color.black;
        }
    }

    public void Minimise() //hides the object.
    {
        minimised = true;
        gameObject.SetActive(false);
    }

    public void Maximise()
    {
        if (!maximised)
        {
            //teleports the window to the top left and makes it bigger.
            originalWindowSize = rect.sizeDelta;
            maximiseButton.sprite = ThemeManager.instance.unmaximiseButton;

            RectTransform iconSpace = GameObject.Find("IconSpace").GetComponent<RectTransform>();

            rect.sizeDelta = new Vector2(Camera.main.pixelWidth, Mathf.Round(iconSpace.rect.height));
            rect.position = new Vector3(rect.rect.width / 2, Mathf.Round(-(rect.rect.height / 2) + Camera.main.pixelHeight));

            GetComponentInChildren<TitleBarScript>().enabled = false;

            maximised = true;
        }
        else
        {
            //returns the window to its original size.
            rect.sizeDelta = originalWindowSize;
            rect.anchoredPosition = new Vector2(Mathf.RoundToInt(rect.anchoredPosition.x), Mathf.RoundToInt(rect.anchoredPosition.y));
            maximiseButton.sprite = ThemeManager.instance.maximiseButton;
            GetComponentInChildren<TitleBarScript>().enabled = true;
            maximised = false;
        }
    }

    public void CloseWindow() //destroys the taskbar object and the window.
    {
        Destroy(instancedTaskbarObj);
        if (destroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData) //Sets the window to be on top of the others.
    {
        transform.SetAsLastSibling();
        ThemeManager.instance.SetActiveWindow(this);
    }

    public void OnPointerDown(PointerEventData eventData) //Sets the window to be on top of the others.
    {
        ThemeManager.instance.SetActiveWindow(this);
    }
}
