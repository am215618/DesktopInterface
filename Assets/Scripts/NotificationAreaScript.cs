using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationAreaScript : MonoBehaviour
{
    public bool displaySeconds; //for the clock.
    RectTransform rectTransform;
    Text clockText;
    public GameObject NotificationsSpace;

    private void Start() //Sets the variables
    {
        rectTransform = GetComponent<RectTransform>();
        clockText = GetComponentInChildren<Text>();
    }

    private void Update() //Constantly updates the time.
    {
        UpdateTime();
    }

    void CheckDisplaySeconds() //Changes the display clock depending of the seconds appear.
    {
        if (displaySeconds)
        {
            rectTransform.sizeDelta = new Vector2((67 + NotificationsSpace.GetComponent<RectTransform>().rect.width), 24);
            NotificationsSpace.GetComponent<RectTransform>().anchoredPosition = new Vector2(-61 - (NotificationsSpace.transform.childCount * 10), 0);
        }
        else if (!displaySeconds)
        {
            rectTransform.sizeDelta = new Vector2((47 + NotificationsSpace.GetComponent<RectTransform>().rect.width), 24);
            NotificationsSpace.GetComponent<RectTransform>().anchoredPosition = new Vector2(-41 - (NotificationsSpace.transform.childCount * 10), 0);
        }
    }
    
    void UpdateTime() //Sets the time to the current time.
    {
        DateTime time = DateTime.Now;

        string hour = zero(time.Hour);
        string minute = zero(time.Minute);
        string second = zero(time.Second);

        if (displaySeconds)
        {
            clockText.text = hour + ":" + minute + ":" + second;
        }
        else
        {
            clockText.text = hour + ":" + minute;
        }
        CheckDisplaySeconds();
    }

    string zero(int x) //allows for the correct display of the time.
    {
        return x.ToString().PadLeft(2, '0');
    }
}
