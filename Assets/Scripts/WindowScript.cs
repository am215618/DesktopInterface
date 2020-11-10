using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]

public class WindowScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Window")]
    public static void AddWindow()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("DefaultObjects/WindowTemplete"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
#endif

    //public Window window;
    RectTransform rect;

    public bool spawnTaskbarObj;

    public Image titleBarIcon;
    public Text titleBarText;

    public GameObject taskbarObject;
    GameObject instancedTaskbarObj;

    public bool minimised;
    public bool maximised;

    [SerializeField] Image maximiseButton;

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
        if (spawnTaskbarObj)
        {
            instancedTaskbarObj = Instantiate(taskbarObject);
            instancedTaskbarObj.GetComponent<TaskbarButtonScript>().window = this.gameObject;
        }
        ThemeManager.instance.OpenWindow(this);
        if (GetComponentInChildren<TitleBarScript>() != null)
        {
            if (maximiseButton != null)
            {
                maximiseButton.sprite = ThemeManager.instance.maximiseButton;
            }
        }
        //instancedTaskbarObj.GetComponent<TaskbarButtonScript>().OnWindowActive();
    }

    void Update()
    {

    }

    public void SetWindowActivity()
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

    public void Minimise()
    {
        minimised = true;
        gameObject.SetActive(false);
    }

    public void Maximise()
    {
        if (!maximised)
        {
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
            rect.sizeDelta = originalWindowSize;
            rect.anchoredPosition = new Vector2(Mathf.RoundToInt(rect.anchoredPosition.x), Mathf.RoundToInt(rect.anchoredPosition.y));
            maximiseButton.sprite = ThemeManager.instance.maximiseButton;
            GetComponentInChildren<TitleBarScript>().enabled = true;
            maximised = false;
        }
        //teleport it to the top left
        //make the window bigger
    }

    public void CloseWindow()
    {
        //window.windowWidth = Convert.ToInt32(Math.Round(rect.sizeDelta.x));
        //window.windowHeight = Convert.ToInt32(Math.Round(rect.sizeDelta.y));
        Destroy(instancedTaskbarObj);
        if (destroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        //taskbarObject.GetComponent<TaskbarButtonScript>().OnWindowClosed();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        ThemeManager.instance.SetActiveWindow(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ThemeManager.instance.SetActiveWindow(this);
    }
}
