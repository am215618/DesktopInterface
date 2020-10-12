using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerClickHandler
{
    protected Image buttonImage;
    protected Text buttonText;

    protected bool buttonPressed;

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    void OnValidate()
    {
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<Text>();
    }

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<Text>();
    }

    void Update()
    {

    }
}
