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
    [SerializeField] Toggle toggle;

    public void OnValidate()
    {
        toggle = GetComponent<Toggle>();
        window = startMenuItem.window;
    }

    public void Start()
    {
        toggle = GetComponent<Toggle>();
        startMenu = GetComponentInParent<StartMenuScript>();
        window = startMenuItem.window;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(window, transform.parent.parent.parent.parent.parent);
    }
}
