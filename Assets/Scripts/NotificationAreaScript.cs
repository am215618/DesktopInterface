using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationAreaScript : MonoBehaviour
{
    public bool displaySeconds;
    RectTransform rectTransform;
    Text clockText;
    RectTransform objectsRect;
    public GameObject NotificationsSpace;
    int numberOfNotifications;
    bool isChecked = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        clockText = GetComponentInChildren<Text>();
        objectsRect = clockText.gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        UpdateTime();
    }

    void CheckDisplaySeconds()
    {
        if (displaySeconds)
        {
            //rectTransform.anchoredPosition = new Vector3(-38, 13.5f, 0);
            rectTransform.sizeDelta = new Vector2((67 + NotificationsSpace.GetComponent<RectTransform>().rect.width), 24);
            NotificationsSpace.GetComponent<RectTransform>().anchoredPosition = new Vector2(-61 - (NotificationsSpace.transform.childCount * 10), 0);
        }
        else if (!displaySeconds)
        {
            //rectTransform.anchoredPosition = new Vector3(-28, 13.5f, 0);
            //rectTransform.sizeDelta = new Vector2(880 - (20 * numberOfNotifications), 0);
            rectTransform.sizeDelta = new Vector2((47 + NotificationsSpace.GetComponent<RectTransform>().rect.width), 24);
            NotificationsSpace.GetComponent<RectTransform>().anchoredPosition = new Vector2(-41 - (NotificationsSpace.transform.childCount * 10), 0);
        }
    }
    
    void UpdateTime()
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

    string zero(int x)
    {
        return x.ToString().PadLeft(2, '0');
    }
}
