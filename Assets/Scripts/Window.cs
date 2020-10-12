using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Window", menuName = "Window")]
public class Window : ScriptableObject
{
    public Sprite titleBarSprite;
    public string titleBarText;

    public int windowWidth = 200;
    public int windowHeight = 200;
}
