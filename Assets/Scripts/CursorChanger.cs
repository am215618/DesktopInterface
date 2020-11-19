using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorChanger : MonoBehaviour
{
    //Gets the preview image.
    public Image previewImage;

    public List<Sprite> cursorSprites; //A list of cursor sprites that the player could use.
    public bool[] showCursorOutline; //Wether or not the outline will show.
    public GameObject cursorButton; //This is a prefab of a button templete.
    GameObject[] cursorButtons; //List of buttons that the player can click on

    //check if the cursor preview has no outline.
    public bool previewHasNoSeparateOutline = true;

    //spawn buttons for each button sprite avaliable.
    void Start()
    {
        cursorButtons = new GameObject[cursorSprites.Count];
        for (int i = 0; i < cursorButtons.Length; i++)
        {
            cursorButtons[i] = Instantiate(cursorButton, transform);
            cursorButtons[i].transform.GetChild(0).GetComponent<Image>().sprite = cursorSprites[i];
            cursorButtons[i].GetComponent<CursorButton>().showOutline = showCursorOutline[i];
        }
    }

    public void ChangeCursorSprite()
    {
        //Get the game objects for the cursor and the outline.
        GameObject cursor = ThemeManager.instance.cursor;
        GameObject cursorOutline = cursor.transform.GetChild(0).gameObject;

        //Toggle visibility if the cursor sprite allows it.
        cursor.GetComponent<Image>().sprite = previewImage.sprite;
        cursor.GetComponent<CursorScript>().shadow.GetComponent<Image>().sprite = previewImage.sprite;
        cursorOutline.SetActive(previewHasNoSeparateOutline);

        //Change the colour of the outline of the cursor, in respect of the colour of the cursor.
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
