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
    public Canvas cursorCanvas;

    public GameObject cursor;
    GameObject taskbar;
    [SerializeField] Image[] taskbarImages;
    [SerializeField] Text[] taskbarTexts;

    public Color backgroundColour;
    //public Color titleBarColour;
    public Color TaskbarColour;
    public Color cursorColour;

    private void OnValidate()
    {
        taskbar = GameObject.Find("Taskbar");
        cursor = GameObject.Find("Cursor");

        Camera.main.backgroundColor = backgroundColour;
        cursor.GetComponent<Image>().color = cursorColour;
        UpdateTheme();
    }

    void Start()
    {
        taskbar = GameObject.Find("Taskbar");
        cursor = GameObject.Find("Cursor");

        Camera.main.backgroundColor = backgroundColour;
        cursor.GetComponent<Image>().color = cursorColour;
        UpdateTheme();
    }

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
}
