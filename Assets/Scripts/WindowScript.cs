using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WindowScript : MonoBehaviour
{
    public Window window;
    RectTransform rect;

    public Image titleBarIcon;
    public Text titleBarText;

    public GameObject taskbarObject;

    [HideInInspector] public bool activeWindow = false;

    /*private void OnValidate()
    {
        rect = GetComponent<RectTransform>();
        titleBarIcon = transform.GetChild(1).GetComponent<Image>();
        titleBarText = GetComponentInChildren<Text>();

        titleBarIcon.sprite = window.titleBarSprite;
        titleBarText.text = window.titleBarText;
    }*/

    void Start()
    {
        rect = GetComponent<RectTransform>();
        titleBarIcon = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        titleBarText = GetComponentInChildren<Text>();

        if (titleBarIcon == null)
        {
            Destroy(titleBarIcon.gameObject);
            titleBarText.rectTransform.sizeDelta = new Vector2(window.windowWidth, titleBarText.rectTransform.sizeDelta.y);
        }
        else
        {
            titleBarIcon.sprite = window.titleBarSprite;
        }
        titleBarText.text = window.titleBarText;

        Instantiate(taskbarObject);
        taskbarObject.gameObject.GetComponent<TaskbarButtonScript>().window = this.gameObject;
    }

    public void CloseWindow()
    {
        window.windowWidth = Convert.ToInt32(Math.Round(rect.sizeDelta.x));
        window.windowHeight = Convert.ToInt32(Math.Round(rect.sizeDelta.y));
        Destroy(gameObject);
        taskbarObject.GetComponent<TaskbarButtonScript>().OnWindowClosed();
    }
}
