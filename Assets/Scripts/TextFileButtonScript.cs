using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFileButtonScript : MonoBehaviour
{
    public void OpenTheDocument()
    {
        GetComponentInParent<NotesScript>().OpenDocument(GetComponentInChildren<Text>().text);
    }
}
