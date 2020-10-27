using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskbarButtonScript : ButtonScript
{
    [SerializeField] ThemeManager themeManager;
    public GameObject window;

    public Sprite selectedButton;
    public Sprite defaultButton;

    [SerializeField] Image taskbarImage;
    [SerializeField] Text taskbarText;

    private void Awake()
    {
        themeManager = ThemeManager.themeManagerInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.Find("TaskbarObjects").transform);
        if (window == null)
        {
            window = GameObject.Find("Window(Clone)");
        }

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
}
