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

    [HideInInspector] public bool activeWindow = false;

    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    void Start()
    {
        rect = GetComponent<RectTransform>();
        //titleBarIcon = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        //titleBarText = GetComponentInChildren<Text>();

        //if (titleBarIcon == null)
        //{
        //    Destroy(titleBarIcon.gameObject);
        //    titleBarText.rectTransform.sizeDelta = new Vector2(window.windowWidth, titleBarText.rectTransform.sizeDelta.y);
        //}
        //else
        //{
        //    titleBarIcon.sprite = window.titleBarSprite;
        //}
        //titleBarText.text = window.titleBarText;
        if (spawnTaskbarObj)
        {
            instancedTaskbarObj = Instantiate(taskbarObject);
            instancedTaskbarObj.GetComponent<TaskbarButtonScript>().window = this.gameObject;
        }
        //instancedTaskbarObj.GetComponent<TaskbarButtonScript>().OnWindowActive();
    }

    private void OnDeselect(BaseEventData eventData)
    {
        //instancedTaskbarObj.GetComponent<TaskbarButtonScript>().OnWindowInactive();
    }

    public void Minimise()
    {
        gameObject.SetActive(false);
    }

    public void Maximise()
    {
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
