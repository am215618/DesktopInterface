using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    #region Singleton
    public static ThemeManager themeManagerInstance;

    void Awake()
    {
        themeManagerInstance = this;
    }
    #endregion

    public Canvas ui;

    GameObject taskbar;
    [SerializeField] Image[] taskbarImages;
    [SerializeField] Text[] taskbarTexts;

    public Color backgroundColour;
    //public Color titleBarColour;
    public Color TaskbarColour;

    private void OnValidate()
    {
        taskbar = GameObject.Find("Taskbar");

        Camera.main.backgroundColor = backgroundColour;
        UpdateTheme();
    }

    void Start()
    {
        taskbar = GameObject.Find("Taskbar");

        Camera.main.backgroundColor = backgroundColour;
        UpdateTheme();
    }

    void LateUpdate()
    {
        
    }

    /*public void OpenStartMenu()
    {
        taskbarImages = taskbar.GetComponentsInChildren<Image>();
    }*/

       
    public void UpdateTheme()
    {
        taskbarImages = taskbar.GetComponentsInChildren<Image>();
        for (int i = 0; i < taskbarImages.Length; i++)
        {
            if (taskbarImages[i].gameObject.tag != "Icon")
            {
                taskbarImages[i].color = TaskbarColour;
            }
        }

        taskbarTexts = taskbar.GetComponentsInChildren<Text>();
        for (int i = 0; i < taskbarTexts.Length; i++)
        {
            if (TaskbarColour.r <= 0.5f && TaskbarColour.g <= 0.5f && TaskbarColour.b <= 0.5f)
            {
                taskbarTexts[i].color = Color.white;
            }
            else
            {
                taskbarTexts[i].color = Color.black;
            }
        }
    }

    public void SetTheme()
    {

    }
}
