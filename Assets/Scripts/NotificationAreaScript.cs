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
    RectTransform clockRect;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        clockText = GetComponentInChildren<Text>();
        clockRect = clockText.gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        DateTime time = DateTime.Now;

        string hour = zero(time.Hour);
        string minute = zero(time.Minute);
        string second = zero(time.Second);

        if (displaySeconds)
        {
            clockText.text = hour + ":" + minute + ":" + second;
            clockRect.sizeDelta = new Vector2(57, clockRect.rect.height);
            clockRect.anchoredPosition = new Vector2(-32, 0);
            rectTransform.anchoredPosition = new Vector3(-38, 13.5f, 0);
        }
        else
        {
            clockText.text = hour + ":" + minute;
            clockRect.sizeDelta = new Vector2(37, clockRect.rect.height);
            clockRect.anchoredPosition = new Vector2(-22, 0);
            rectTransform.anchoredPosition = new Vector3(-28, 13.5f, 0);
        }

        rectTransform.sizeDelta = new Vector2
            (clockRect.rect.width + 10,
             rectTransform.rect.height);
    }

    string zero(int x)
    {
        return x.ToString().PadLeft(2, '0');
    }
}
