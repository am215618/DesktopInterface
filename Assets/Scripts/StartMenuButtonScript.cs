using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMenuButtonScript : MonoBehaviour
{
    public StartMenuItem startMenuItem; //The properties.

    Text itemText;
    Image itemImage;
    GameObject window; //Setting the window that it would open when clicked on.

    public void Start()
    {
        itemText = GetComponentInChildren<Text>();
        itemImage = transform.GetChild(1).GetComponent<Image>();

        SetProperties();
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
        GetComponentInParent<StartMenuScript>().CloseStartMenu();
    }
}
