using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] ThemeManager themeManager;

    //Theme Settings
    [Space]
    public GameObject themeSettingsArea;
    public GameObject cursorSettingsArea;

    [Space] //Game Settings
    public GameObject gameSettingsArea;
    public AudioMixer audioMixer;

    public Button enterFullScreen;
    public Button exitFullScreen;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    [SerializeField] ColourPicker[] colourPickers;

    [Space]
    public GameObject aboutScreen;

    //Sets the colour pickers to the ones that are children of the theme settings area.
    private void OnValidate()
    {
        colourPickers = themeSettingsArea.GetComponentsInChildren<ColourPicker>();
    }

    void Start()
    {
        //Sets the theme manager to the one in the scene.
        themeManager = ThemeManager.instance;

        //Toggles wether or not the game is in full screen already.
        if (Screen.fullScreen)
        {
            enterFullScreen.gameObject.SetActive(false);
            exitFullScreen.gameObject.SetActive(true);
        }
        else
        {
            enterFullScreen.gameObject.SetActive(true);
            exitFullScreen.gameObject.SetActive(false);
        }

        resolutions = Screen.resolutions;

        //Clear the dropdown list.
        resolutionDropdown.ClearOptions();

        //Make a new list of options, with a different resolution.
        List<string> options = new List<string>();

        int currentResIndex = 0;
        //we create a list of nicely formatted strings.
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        //Adds the options to the dropdown box.
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //The functions below sets the screen to the one selected.
    public void CursorSettings()
    {
        cursorSettingsArea.SetActive(true);
        themeSettingsArea.SetActive(false);
        gameSettingsArea.SetActive(false);
        aboutScreen.SetActive(false);
    }

    public void ThemeSettings()
    {
        cursorSettingsArea.SetActive(false);
        themeSettingsArea.SetActive(true);
        gameSettingsArea.SetActive(false);
        aboutScreen.SetActive(false);
    }

    public void GameSettings()
    {
        cursorSettingsArea.SetActive(false);
        themeSettingsArea.SetActive(false);
        gameSettingsArea.SetActive(true);
        aboutScreen.SetActive(false);
    }

    public void AboutScreen()
    {
        cursorSettingsArea.SetActive(false);
        themeSettingsArea.SetActive(false);
        gameSettingsArea.SetActive(false);
        aboutScreen.SetActive(true);
    }

    //Sets the volume slider to whatever the volume is in the game.
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    //Sets wether or not the game is in full screen.
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (isFullScreen)
        {
            enterFullScreen.gameObject.SetActive(false);
            exitFullScreen.gameObject.SetActive(true);
        }
        else
        {
            enterFullScreen.gameObject.SetActive(true);
            exitFullScreen.gameObject.SetActive(false);
        }
    }

    //Sets the resolution of the game.
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Applies the colours to their respective components.
    public void ApplyAllThemeSettings()
    {
        colourPickers = themeSettingsArea.GetComponentsInChildren<ColourPicker>();
        for (int i = 0; i < colourPickers.Length; i++)
        {
            colourPickers[i].ApplyColour();
        }
    }

    //Changes whether or not the cursor has a shadow
    public void ChangeCursorShadowAppearance(bool shadow)
    {
        themeManager.cursorShadow = shadow;
        themeManager.cursor.GetComponent<CursorScript>().ToggleShadow(shadow);
    }

    //Deliberatly crashes the system (not implemented)
    public void DeliberateCrash()
    {
        
    }
}
