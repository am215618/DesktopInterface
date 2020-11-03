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

    private void OnValidate()
    {
        colourPickers = themeSettingsArea.GetComponentsInChildren<ColourPicker>();
    }

    void Start()
    {
        themeManager = ThemeManager.instance;

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

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void ThemeSettings()
    {
        themeSettingsArea.SetActive(true);
        gameSettingsArea.SetActive(false);
        aboutScreen.SetActive(false);
    }

    public void GameSettings()
    {
        themeSettingsArea.SetActive(false);
        gameSettingsArea.SetActive(true);
        aboutScreen.SetActive(false);
    }

    public void AboutScreen()
    {
        themeSettingsArea.SetActive(false);
        gameSettingsArea.SetActive(false);
        aboutScreen.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ApplyAllThemeSettings()
    {
        colourPickers = themeSettingsArea.GetComponentsInChildren<ColourPicker>();
        for (int i = 0; i < colourPickers.Length; i++)
        {
            colourPickers[i].ApplyColour();
        }
    }

    public void DeliberateCrash()
    {
        
    }
}
