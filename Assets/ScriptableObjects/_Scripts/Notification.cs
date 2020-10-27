using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Notification", menuName = "Notification")]
public class Notification : ScriptableObject
{
    public Sprite notificationSprite;
    public string notificationTitle;
    public string notificationText;

    public string notificationToolTipText;

    public bool stayOnPermamently;

    public float notificationLifespan;
}
