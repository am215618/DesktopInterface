using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    //Gets the theme manager that is in the scene.
    ThemeManager themeManager;

    public RectTransform startMenuInterface;
    VerticalLayoutGroup layoutGroup;
    //Gets the start menu items
    public StartMenuItem shutdownItem;
    public List<StartMenuItem> startMenuItems;

    public GameObject startMenuButton;
    [SerializeField] GameObject[] buttons;
    bool initialised = false;

    private void OnValidate()
    {
        if (startMenuItems[startMenuItems.Count - 1] != shutdownItem)
        {
            startMenuItems.Remove(shutdownItem);
            startMenuItems.Add(shutdownItem);
        }
    }

    private void Awake() //Sets the theme manager to the instance in the scene.
    {
        themeManager = ThemeManager.instance;
        buttons = new GameObject[startMenuItems.Count];
        layoutGroup = startMenuInterface.GetComponent<VerticalLayoutGroup>();
        themeManager.onClick += CloseStartMenu;
    }

    //This sets all of the buttons to the each of items in the menu.
    public void LaunchStartMenu()
    {
        startMenuInterface.gameObject.SetActive(true);
        if (!initialised || buttons.Length != startMenuItems.Count)
            InitialiseStartMenu();
    }

    public void InitialiseStartMenu()
    {
        if (startMenuInterface.gameObject.activeSelf)
        {
            buttons = new GameObject[startMenuItems.Count];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = Instantiate(startMenuButton, startMenuInterface.transform);
                StartMenuButtonScript buttonScript = buttons[i].GetComponent<StartMenuButtonScript>();

                buttonScript.startMenuItem = startMenuItems[i];

                /*if (themeManager.TaskbarColour.r <= 0.5f && themeManager.TaskbarColour.g <= 0.5f && themeManager.TaskbarColour.b <= 0.5f)
                {
                    buttons[i].GetComponentInChildren<Text>().color = Color.white;
                }
                else
                {
                    buttons[i].GetComponentInChildren<Text>().color = Color.black;
                }*/
            }

            startMenuInterface.sizeDelta = new Vector2
                (160,
                layoutGroup.padding.bottom + (startMenuButton.GetComponent<RectTransform>().rect.height * startMenuItems.Count) + (layoutGroup.spacing * (startMenuItems.Count - 1)) + layoutGroup.padding.top);
            startMenuInterface.anchoredPosition = new Vector2(startMenuInterface.anchoredPosition.x, 29 + (startMenuButton.GetComponent<RectTransform>().rect.height / 2) * (startMenuItems.Count - 1));
            initialised = true;
        }
        else
        {
            startMenuInterface.gameObject.SetActive(false);
        }
    }

    public void CloseStartMenu()
    {
        startMenuInterface.gameObject.SetActive(false);
    }

    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
