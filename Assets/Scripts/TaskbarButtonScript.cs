using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TaskbarButtonScript : MonoBehaviour, IPointerClickHandler
{
    //variables to assign 
    ThemeManager themeManager;
    public GameObject window;

    public Sprite selectedButton;
    public Sprite defaultButton;

    Image taskbarImage;
    Text taskbarText;

    //sets the theme manager to the instance in the scene.
    private void Awake()
    {
        themeManager = ThemeManager.instance;
    }

    void Start() //This sets all the variables.
    {
        transform.SetParent(GameObject.Find("TaskbarObjects").transform);

        WindowScript windowScript = window.GetComponent<WindowScript>();
        taskbarImage = transform.GetChild(1).GetComponentInChildren<Image>();
        taskbarText = GetComponentInChildren<Text>();

        GetComponent<Image>().color = themeManager.TaskbarColour;
        if(GetComponent<Image>().color.r <= 0.5f && GetComponent<Image>().color.g <= 0.5f && GetComponent<Image>().color.b <= 0.5f)
        {
            GetComponentInChildren<Text>().color = Color.white;
        }
        else
        {
            GetComponentInChildren<Text>().color = Color.black;
        }

        taskbarImage.sprite = windowScript.titleBarIcon.sprite;
        taskbarText.text = windowScript.titleBarText.text;
    }

    //These variables arent used, but what they should do is set the state dependent on the window that it has opened.
    public void OnWindowActive()
    {
        Image buttonImage = GetComponent<Image>();
        buttonImage.sprite = selectedButton;
    }

    public void OnWindowInactive()
    {
        Image buttonImage = GetComponent<Image>();
        buttonImage.sprite = defaultButton;
    }

    public void OnWindowClosed()
    {
        taskbarImage = null;
        taskbarText = null;
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData) //sets the set of the window to active.
    {
        WindowScript windowScript = window.GetComponent<WindowScript>();

        window.transform.SetAsLastSibling();
        themeManager.SetActiveWindow(windowScript);
        if (windowScript.minimised)
        {
            window.SetActive(true);
            windowScript.minimised = false;
        }
    }
}
