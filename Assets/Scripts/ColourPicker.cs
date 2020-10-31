using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourPicker : MonoBehaviour
{
    public enum ComponentChanging { Cursor, TitleBar, Taskbar, Background, Tooltip, Selected }
    public ComponentChanging changingComponent;

    //Get the image that it is assigned to.
    public Image image;
    public Image applyToImage;

    //Defining
    public Color currentColour;

    public float red = 1f;
    public float green = 1f;
    public float blue = 1f;
    public float alpha = 1f;

    [SerializeField] Slider[] sliders;

    // Start is called before the first frame update
    void Start()
    {
        sliders = GetComponentsInChildren<Slider>();
        SetColour();

        switch (changingComponent)
        {
            case ComponentChanging.Cursor:
                applyToImage = ThemeManager.instance.cursor.GetComponent<Image>();
                currentColour = ThemeManager.instance.cursorColour;

                red = ThemeManager.instance.cursorColour.r;
                green = ThemeManager.instance.cursorColour.g;
                blue = ThemeManager.instance.cursorColour.b;
                alpha = ThemeManager.instance.cursorColour.a;

                sliders[0].value = red;
                sliders[1].value = green;
                sliders[2].value = blue;
                sliders[3].value = alpha;

                SetColour();
                break;
            case ComponentChanging.TitleBar:
                break;
            case ComponentChanging.Taskbar:
                break;
            case ComponentChanging.Background:
                break;
            case ComponentChanging.Tooltip:
                break;
            case ComponentChanging.Selected:
                break;
        }
    }

    public void SetRed(float _red)
    {
        red = _red;
        SetColour();
    }

    public void SetGreen(float _green)
    {
        green = _green;
        SetColour();
    }

    public void SetBlue(float _blue)
    {
        blue = _blue;
        SetColour();
    }

    public void SetAlpha(float _alpha)
    {
        alpha = _alpha;
        SetColour();
    }

    void SetColour()
    {
        currentColour = new Color(red, green, blue, alpha);
        image.color = currentColour;
    }

    public void ApplyColour()
    {
        applyToImage.color = currentColour;
        switch (changingComponent)
        {
            case ComponentChanging.Cursor:
                GameObject cursor = ThemeManager.instance.cursor;
                GameObject cursorOutline = cursor.transform.GetChild(0).gameObject;

                if (cursor.GetComponent<Image>().color.r <= 0.5f && cursor.GetComponent<Image>().color.g <= 0.5f && cursor.GetComponent<Image>().color.b <= 0.5f)
                {
                    cursorOutline.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    cursorOutline.GetComponent<Image>().color = Color.black;
                }
                cursorOutline.SetActive(true);
                break;
        }
    }

    public Color GetColour()
    {
        return currentColour;
    }
}
