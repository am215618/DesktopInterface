using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupScript : MonoBehaviour
{
    //Variables for the popup.
    public Text title;
    public Text description;
    public Image icon;

    //Closes the popup
    public void ClosePopup()
    {
        Destroy(gameObject);
    }
}
