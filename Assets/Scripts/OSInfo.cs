using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This sets the name of the project and displays it when the build if the build is a dev build or the project is in editor
public class OSInfo : MonoBehaviour
{
    [TextArea(2,10)]
    public string OSName;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        if (Debug.isDebugBuild)
        {
            text.text = OSName;
        }
        else
        {
            text.text = "";
        }
    }
}
