using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    public Color backgroundColour;
    public Color titleBarColour;

    private void OnValidate()
    {
        Camera.main.backgroundColor = backgroundColour;
    }

    private void Start()
    {
        Camera.main.backgroundColor = backgroundColour;
    }

}
