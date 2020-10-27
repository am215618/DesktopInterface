using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NotificationObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Notification notification;
    public GameObject toolTip;
    public GameObject Popup;

    public Image notificationImage;
    public bool spawnPopupBaloon;

    float notificationCooldown;
    GameObject tmpToolTip;

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
        tmpPopup.GetComponent<PopupScript>().title.text = notification.notificationTitle;
        tmpPopup.GetComponent<PopupScript>().description.text = notification.notificationText;
        tmpPopup.GetComponent<PopupScript>().icon.sprite = notification.notificationSprite;
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
}
