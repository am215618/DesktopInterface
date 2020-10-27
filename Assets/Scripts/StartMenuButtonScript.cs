using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMenuButtonScript : MonoBehaviour, IPointerClickHandler
{
    public StartMenuItem startMenuItem;

    StartMenuScript startMenu;
    [SerializeField] GameObject window;

    public void Start()
    {
        startMenu = GetComponentInParent<StartMenuScript>();
        window = startMenuItem.window;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(window, transform.parent.parent.parent.parent.parent.parent);
    }
}
