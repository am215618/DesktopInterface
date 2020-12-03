using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines properties of the window, and the title bar
//[CreateAssetMenu(fileName = "Window", menuName = "Window/Default")]
public class Window : ScriptableObject
{
    public GameObject window;

    public Sprite titleBarSprite;
    public string titleBarText;
}
