using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    public List<StartMenuItem> startMenuItems;
    [SerializeField] GameObject[] buttons;

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
        }
    }
}
