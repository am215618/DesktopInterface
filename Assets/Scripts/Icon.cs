using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Icon", menuName = "Desktop Icon")]
public class Icon : ScriptableObject
{
    public Sprite iconSprite;
    public string iconName;
}
