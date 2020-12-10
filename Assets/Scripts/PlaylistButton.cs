using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaylistButton : MonoBehaviour
{
    //variables getting the music player and some important components required.
    MediaPlayer player;

    public int buttonID;
    public string songName;
    public float length;

    public Text idTxt, nameTxt, lengthTxt;

    void Start() //Sets those variables.
    {
        player = GetComponentInParent<MediaPlayer>();

        idTxt.text = buttonID.ToString();
        nameTxt.text = songName;
        lengthTxt.text = length.ToString();
    }

    public void PlayMusic() //Sets the ID of the music to play.
    {
        player.SetSound(buttonID);
    }
}
