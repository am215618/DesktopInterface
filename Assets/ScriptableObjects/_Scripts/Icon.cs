using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines the icons sprite, name and window to open 
[CreateAssetMenu(fileName = "Icon", menuName = "Desktop Icon")]
public class Icon : ScriptableObject
{
    public Sprite iconSprite;
    public string iconName;

    public GameObject window;
}
