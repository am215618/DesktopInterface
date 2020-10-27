using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Window", menuName = "Window/Default")]
public class Window : ScriptableObject
{
    public GameObject window;

    public Sprite titleBarSprite;
    public string titleBarText;

    public int windowWidth = 200;
    public int windowHeight = 200;
}
