using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    //Gets the theme manager that is in the scene.
    ThemeManager themeManager;

    //Gets the start menu items
    public List<StartMenuItem> startMenuItems;
    [SerializeField] GameObject[] buttons;

    private void Awake() //Sets the theme manager to the instance in the scene.
    {
        themeManager = ThemeManager.instance;
        buttons = new GameObject[startMenuItems.Count];
    }

    //This sets all of the buttons to the each of items in the menu.
    void Start()
    {
        for (int i = 0; i < startMenuItems.Count; i++)
        {
            buttons[i] = GetComponentsInChildren<Toggle>()[i].gameObject;
            buttons[i].GetComponent<StartMenuButtonScript>().startMenuItem = startMenuItems[i];
            if(themeManager.TaskbarColour.r <= 0.5f && themeManager.TaskbarColour.g <= 0.5f && themeManager.TaskbarColour.b <= 0.5f)
            {
                buttons[i].GetComponentInChildren<Text>().color = Color.white;
            }
            else
            {
                buttons[i].GetComponentInChildren<Text>().color = Color.black;
            }
        }
    }
}
