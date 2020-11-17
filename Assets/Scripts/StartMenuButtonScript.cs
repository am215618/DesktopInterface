using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMenuButtonScript : MonoBehaviour, IPointerClickHandler
{
    public StartMenuItem startMenuItem; //The properties.

    GameObject window; //Setting the window that it would open when clicked on.

    public void Start()
    {
        window = startMenuItem.window; //Sets the window variable to the one set in the properties.
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(window, ThemeManager.instance.ui.transform); //Creates a new window instance.
    }
}
