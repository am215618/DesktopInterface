using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class WindowScript : MonoBehaviour, IPointerClickHandler
{
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

        maximiseButton.sprite = ThemeManager.themeManagerInstance.maximiseButton;
        //instancedTaskbarObj.GetComponent<TaskbarButtonScript>().OnWindowActive();
    }

    private void OnDeselect(BaseEventData eventData)
    {
        //instancedTaskbarObj.GetComponent<TaskbarButtonScript>().OnWindowInactive();
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
            maximiseButton.sprite = ThemeManager.themeManagerInstance.unmaximiseButton;

            RectTransform iconSpace = GameObject.Find("IconSpace").GetComponent<RectTransform>();

            rect.sizeDelta = new Vector2(Camera.main.pixelWidth, Mathf.Round(iconSpace.rect.height));
            rect.position = new Vector3(rect.rect.width / 2, Mathf.Round(-(rect.rect.height / 2) + Camera.main.pixelHeight));

            maximised = true;
        }
        else
        {
            rect.sizeDelta = originalWindowSize;
            maximiseButton.sprite = ThemeManager.themeManagerInstance.maximiseButton;
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
        Destroy(gameObject);
        //taskbarObject.GetComponent<TaskbarButtonScript>().OnWindowClosed();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }
}
