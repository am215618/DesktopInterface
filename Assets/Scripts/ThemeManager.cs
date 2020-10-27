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

    public GameObject iconSpace;
    public GameObject cursor;
    public GameObject taskbar;

    Text[] iconTexts;

    Image[] taskbarImages;
    Text[] taskbarTexts;

    public Color backgroundColour;
    //public Color titleBarColour;
    public Color TaskbarColour;
    public Color cursorColour;
    public Color toolTipColour;
    public Color SelectedColour;

    public Sprite maximiseButton;
    public Sprite unmaximiseButton;

    private void OnValidate()
    {
        Camera.main.backgroundColor = backgroundColour;
        cursor.GetComponent<Image>().color = cursorColour;

        iconTexts = iconSpace.GetComponentsInChildren<Text>();
        taskbarImages = taskbar.GetComponentsInChildren<Image>();
        taskbarTexts = taskbar.GetComponentsInChildren<Text>();

        UpdateTheme();
    }

    void Start()
    {
        Camera.main.backgroundColor = backgroundColour;
        cursor.GetComponent<Image>().color = cursorColour;

        iconTexts = iconSpace.GetComponentsInChildren<Text>();
        taskbarImages = taskbar.GetComponentsInChildren<Image>();
        taskbarTexts = taskbar.GetComponentsInChildren<Text>();

        UpdateTheme();
    }

    public void UpdateTheme()
    {
        for (int i = 0; i < iconTexts.Length; i++)
        {
            if (backgroundColour.r <= 0.5f && backgroundColour.g <= 0.5f && backgroundColour.b <= 0.5f)
            {
                iconTexts[i].color = Color.white;
            }
            else
            {
                iconTexts[i].color = Color.black;
            }
        }

        for (int i = 0; i < taskbarImages.Length; i++)
        {
            if (taskbarImages[i].gameObject.tag != "Icon")
            {
                taskbarImages[i].color = TaskbarColour;
            }
        }

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
