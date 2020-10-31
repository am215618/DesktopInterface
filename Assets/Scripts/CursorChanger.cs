using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorChanger : MonoBehaviour
{
    public Image previewImage;

    public Sprite[] cursorSprites;
    public bool[] showCursorOutline;
    public GameObject cursorButton;
    GameObject[] cursorButtons;

    public bool previewHasNoSeparateOutline = true;

    //spawn buttons for each button sprite avaliable.
    private void Start()
    {
        cursorButtons = new GameObject[cursorSprites.Length];
        for (int i = 0; i < cursorButtons.Length; i++)
        {
            cursorButtons[i] = Instantiate(cursorButton, transform);
            cursorButtons[i].transform.GetChild(0).GetComponent<Image>().sprite = cursorSprites[i];
            cursorButtons[i].GetComponent<CursorButton>().showOutline = showCursorOutline[i];
        }
    }

    public void ChangeCursorSprite()
    {
        GameObject cursor = ThemeManager.instance.cursor;
        GameObject cursorOutline = cursor.transform.GetChild(0).gameObject;

        cursor.GetComponent<Image>().sprite = previewImage.sprite;
        cursorOutline.SetActive(previewHasNoSeparateOutline);

        if (cursor.GetComponent<Image>().color.r <= 0.5f && cursor.GetComponent<Image>().color.g <= 0.5f && cursor.GetComponent<Image>().color.b <= 0.5f)
        {
            cursorOutline.GetComponent<Image>().color = Color.white;
        }
        else
        {
            cursorOutline.GetComponent<Image>().color = Color.black;
        }
    }
}
