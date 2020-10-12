using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuButtonScript : MonoBehaviour
{
    public int buttonID;

    [SerializeField] public Toggle toggle;

    StartMenuScript startMenu;
    WindowScript window;

    public void Start()
    {
        toggle = GetComponent<Toggle>();
        //toggle.navigation.mode = Navigation.Mode.None;
    }

    public void Click()
    {
        
        /*if (!toggle.isOn)
        {
            Debug.Log("Click Successful");
            /*if (buttonID == startMenu.startMenuItems.Length)
            {
                Application.Quit();
            }
            else
            {
                Instantiate(window);
                for (int i = 0; i < startMenu.windows.Length; i++)
                {
                    window.window = startMenu.windows[i];
                }
            }
        }*/
        
        /**/
    } 
}
