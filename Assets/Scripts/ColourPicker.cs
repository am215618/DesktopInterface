using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourPicker : MonoBehaviour
{
    public enum ComponentChanging { Cursor, ActiveTitleBar, InactiveTitleBar, Taskbar, Background, Tooltip, Selected } //A enum of the areas that we can change the colour.
    public ComponentChanging changingComponent;

    //Get the image that it is assigned to.
    public Image image;
    public Image applyToImage;

    //Defining
    public Color currentColour;

    //RGBA values.
    public float red = 1f;
    public float green = 1f;
    public float blue = 1f;
    public float alpha = 1f;

    [SerializeField] Slider[] sliders;

    // Start is called before the first frame update
    public void Start() 
    {
        sliders = GetComponentsInChildren<Slider>();

        switch (changingComponent) //Sets the colours and other variables dependent on the component that it is being applied to.
        {
            case ComponentChanging.Cursor:
                applyToImage = ThemeManager.instance.cursor.GetComponent<Image>();
                currentColour = ThemeManager.instance.cursorColour;

                red = ThemeManager.instance.cursorColour.r;
                green = ThemeManager.instance.cursorColour.g;
                blue = ThemeManager.instance.cursorColour.b;
                alpha = ThemeManager.instance.cursorColour.a;
                break;
            case ComponentChanging.ActiveTitleBar:
                currentColour = ThemeManager.instance.activeTitleBarColour;

                red = ThemeManager.instance.activeTitleBarColour.r;
                green = ThemeManager.instance.activeTitleBarColour.g;
                blue = ThemeManager.instance.activeTitleBarColour.b;
                alpha = ThemeManager.instance.activeTitleBarColour.a;
                break;
            case ComponentChanging.InactiveTitleBar:
                currentColour = ThemeManager.instance.inactiveTitleBarColour;

                red = ThemeManager.instance.inactiveTitleBarColour.r;
                green = ThemeManager.instance.inactiveTitleBarColour.g;
                blue = ThemeManager.instance.inactiveTitleBarColour.b;
                alpha = ThemeManager.instance.inactiveTitleBarColour.a;
                break;
            case ComponentChanging.Taskbar:
                currentColour = ThemeManager.instance.TaskbarColour;

                red = ThemeManager.instance.TaskbarColour.r;
                green = ThemeManager.instance.TaskbarColour.g;
                blue = ThemeManager.instance.TaskbarColour.b;
                alpha = ThemeManager.instance.TaskbarColour.a;
                break;
            case ComponentChanging.Background:
                currentColour = ThemeManager.instance.backgroundColour;

                red = ThemeManager.instance.backgroundColour.r;
                green = ThemeManager.instance.backgroundColour.g;
                blue = ThemeManager.instance.backgroundColour.b;
                alpha = ThemeManager.instance.backgroundColour.a;
                break;
            case ComponentChanging.Tooltip:
                currentColour = ThemeManager.instance.toolTipColour;

                red = ThemeManager.instance.toolTipColour.r;
                green = ThemeManager.instance.toolTipColour.g;
                blue = ThemeManager.instance.toolTipColour.b;
                alpha = ThemeManager.instance.toolTipColour.a;
                break;
            case ComponentChanging.Selected:
                currentColour = ThemeManager.instance.SelectedColour;

                red = ThemeManager.instance.SelectedColour.r;
                green = ThemeManager.instance.SelectedColour.g;
                blue = ThemeManager.instance.SelectedColour.b;
                alpha = ThemeManager.instance.SelectedColour.a;
                break;
        }

        //Sets the slider values.
        sliders[0].value = red;
        sliders[1].value = green;
        sliders[2].value = blue;
        sliders[3].value = alpha;

        SetColour();
    }

    //Each of the below functions would set the colour value.
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

    void SetColour() //Sets the colour of the preview to that.
    {
        currentColour = new Color(red, green, blue, alpha);
        if (image != null)
        {
            image.color = currentColour;
        }
    }

    public void ApplyColour() //Applies all the colours to the actual component being changed.
    {
        if(applyToImage != null)
            applyToImage.color = currentColour;

        switch (changingComponent)
        {
            case ComponentChanging.Cursor: //Changes the cursor style and colour, as well as wether or not it needs an outline.
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
                ThemeManager.instance.cursorColour = currentColour;
                cursorOutline.SetActive(true);
                break;

            case ComponentChanging.ActiveTitleBar:
                ThemeManager.instance.activeTitleBarColour = currentColour;
                break;

            case ComponentChanging.InactiveTitleBar:
                ThemeManager.instance.inactiveTitleBarColour = currentColour;
                break;

            case ComponentChanging.Taskbar:
                ThemeManager.instance.TaskbarColour = currentColour;
                break;

            case ComponentChanging.Background:
                Camera.main.backgroundColor = currentColour;
                ThemeManager.instance.backgroundColour = currentColour;
                break;

            case ComponentChanging.Tooltip:
                ThemeManager.instance.toolTipColour = currentColour;
                break;

            case ComponentChanging.Selected:
                ThemeManager.instance.SelectedColour = currentColour;
                break;

        }
    }

    public Color GetColour() //Returns the current colour, so that this could be accessed in other scripts.
    {
        return currentColour;
    }
}
