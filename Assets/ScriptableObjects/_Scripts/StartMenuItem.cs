using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Start Menu Item", menuName = "Start Menu Item")]
public class StartMenuItem : ScriptableObject
{
    public int buttonID;
    public Sprite sprite;
    public string menuName;

    public GameObject window;
}
