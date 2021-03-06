﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMenuButtonScript : MonoBehaviour
{
    public StartMenuItem startMenuItem; //The properties.
    StartMenuScript startMenu;

    Text itemText;
    Image itemImage;
    GameObject window; //Setting the window that it would open when clicked on.

    bool IsOver = false;

    public void Start()
    {
        startMenu = GetComponentInParent<VerticalLayoutGroup>().GetComponentInParent<StartMenuScript>();

        itemText = GetComponentInChildren<Text>();
        itemImage = transform.GetChild(1).GetComponent<Image>();

        SetProperties();
    }

    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            OpenWindow();
            startMenu.CloseStartMenu();
        }
    }

    public void SetProperties()
    {
        itemText.text = startMenuItem.menuName;
        itemImage.sprite = startMenuItem.sprite;
        window = startMenuItem.window; //Sets the window variable to the one set in the properties.
    }

    public void OpenWindow()
    {
        Instantiate(window, ThemeManager.instance.ui.transform); //Creates a new window instance.
        transform.parent.GetComponentInParent<StartMenuScript>().startMenuInterface.gameObject.SetActive(false);
    }
}
