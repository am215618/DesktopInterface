using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Defines what the icons in the explorer window are.
[CreateAssetMenu(fileName = "Explorer Window", menuName = "Window/Explorer")]
public class Explorer : Window
{
    public List<Icon> icons;
}
