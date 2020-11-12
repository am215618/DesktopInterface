using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class NotificationObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Notification")]
    public static void AddNotification()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("DefaultObjects/Notification"));
        obj.transform.parent = ThemeManager.instance.taskbarCanvas.GetComponentInChildren<NotificationAreaScript>().transform.GetChild(2);
    }
#endif

    public Notification notification;
    public GameObject toolTip;
    public GameObject Popup;

    public Image notificationImage;
    public bool spawnPopupBaloon;

    float notificationCooldown;

    // Start is called before the first frame update
    void Start()
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
            notificationCooldown -= Time.deltaTime;

            if (notificationCooldown < 0) NotificationExpired();
        }
    }

    IEnumerator SpawnPopup()
    {
        yield return new WaitForSeconds(1f);
        
        GameObject tmpPopup = Instantiate(Popup, gameObject.transform);

        PopupScript popUpScript = tmpPopup.GetComponent<PopupScript>();
        popUpScript.title.text = notification.notificationTitle;
        popUpScript.description.text = notification.notificationText;
        popUpScript.icon.sprite = notification.notificationSprite;

        tmpPopup.GetComponent<Image>().color = ThemeManager.instance.toolTipColour;
        tmpPopup.transform.GetChild(0).GetComponent<Image>().color = ThemeManager.instance.toolTipColour;

        yield return new WaitForSeconds(5f);
        Destroy(tmpPopup);
    }

    void ShowToolTip()
    {
        string ttstring = notification.notificationToolTipText;
        ToolTipScript.instance.ShowToolTip(ttstring);
    }

    public void NotificationExpired()
    {
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowToolTip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShowToolTip();
        ToolTipScript.instance.HideToolTip();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //if(eventData.pointerPress)
    }
}
