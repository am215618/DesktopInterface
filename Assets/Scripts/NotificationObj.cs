using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;


[ExecuteInEditMode()]
#endif
public class NotificationObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Notification")]
    public static void AddNotification() //Adds the notification to the notification area.
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("DefaultObjects/Notification"));
        obj.transform.parent = ThemeManager.instance.taskbarCanvas.GetComponentInChildren<NotificationAreaScript>().transform.GetChild(2);
    }
#endif

    //Variables, properties among other variables.
    public Notification notification;
    public GameObject toolTip;
    public GameObject Popup;

    public Image notificationImage;
    public bool spawnPopupBaloon;

    float notificationCooldown;

    void Start() //Sets the sprites to the ones in properties.
    {
        notificationImage.sprite = notification.notificationSprite;
        notificationCooldown = notification.notificationLifespan;

        if(spawnPopupBaloon)
            StartCoroutine(SpawnPopup());
    }

    void Update()
    {
        if (!notification.stayOnPermamently)
        {
            //Counts down the notification timer and makes it dissapear after a certain length of time.
            notificationCooldown -= Time.deltaTime;

            if (notificationCooldown < 0) NotificationExpired();
        }
    }

    IEnumerator SpawnPopup()
    {
        ThemeManager tm = ThemeManager.instance;
        yield return new WaitForSeconds(1f);
        
        //Sets a local popup variable to an instanced varient of the popup.
        GameObject tmpPopup = Instantiate(Popup, gameObject.transform);

        //set up a popup script local variable to modify the properties of the popup.
        PopupScript popUpScript = tmpPopup.GetComponent<PopupScript>();
        popUpScript.title.text = notification.notificationTitle;
        popUpScript.description.text = notification.notificationText;
        popUpScript.icon.sprite = notification.notificationSprite;

        //Sets the colour.
        tmpPopup.GetComponent<Image>().color = tm.toolTipColour;
        tmpPopup.transform.GetChild(0).GetComponent<Image>().color = tm.toolTipColour;

        //popup dissappears after 5 seconds.
        yield return new WaitForSeconds(5f);
        Destroy(tmpPopup);
    }

    void ShowToolTip() 
    {
        string ttstring = notification.notificationToolTipText; //Sets the tooltip to display the text defined.
        ToolTipScript.instance.ShowToolTip(ttstring);
    }

    public void NotificationExpired() //Destroys the expired notification.
    {
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData) //Shows a tooltip when hovered over.
    {
        ShowToolTip();
    }

    public void OnPointerExit(PointerEventData eventData) //Hides the tooltip when its hovered away.
    {
        ShowToolTip();
        ToolTipScript.instance.HideToolTip();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //do whatever is intended here.
    }
}
