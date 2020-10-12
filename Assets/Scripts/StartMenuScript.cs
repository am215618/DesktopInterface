using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour, IPointerClickHandler
{
    public Window[] windows;
    public Toggle[] startMenuItems;

    Dropdown dropdown;

    public WindowScript window;

    public void OnPointerClick(PointerEventData eventData)
    {
        startMenuItems = GameObject.Find("Dropdown List").GetComponentsInChildren<Toggle>();
        for (int i = 0; i < startMenuItems.Length; i++)
        {
            startMenuItems[i].GetComponent<StartMenuButtonScript>().buttonID = i;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        
        //Add Shutdown to the end of the list
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
