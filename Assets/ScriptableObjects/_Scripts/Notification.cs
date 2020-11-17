using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sets properties of the notification: sprite, text, and what the popup ballon says.
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
