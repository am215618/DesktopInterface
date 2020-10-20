using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    ThemeManager themeManager;

    public List<StartMenuItem> startMenuItems;
    [SerializeField] GameObject[] buttons;

    private void Awake()
    {
        themeManager = ThemeManager.themeManagerInstance;
    }

    private void OnValidate()
    {
        buttons = new GameObject[startMenuItems.Count];

        for (int i = 0; i < startMenuItems.Count; i++)
        {
            buttons[i] = GetComponentInChildren<Toggle>().gameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        buttons = new GameObject[startMenuItems.Count];

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
