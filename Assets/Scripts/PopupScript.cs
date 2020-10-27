using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupScript : MonoBehaviour
{
    public Text title;
    public Text description;
    public Image icon;

    public void ClosePopup()
    {
        Destroy(gameObject);
    }
}
