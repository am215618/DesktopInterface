using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
