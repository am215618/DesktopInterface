using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Sets the properties of the start menu item
[CreateAssetMenu(fileName = "Start Menu Item", menuName = "Start Menu Item")]
public class StartMenuItem : ScriptableObject
{
    public Sprite sprite;
    public string menuName;

    public GameObject window;
}
