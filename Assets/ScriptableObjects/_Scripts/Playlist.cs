using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Playlist", menuName = "Music Player/Playlist")]
public class Playlist : ScriptableObject
{
    //Literally a list of audio clips. Thats it.
    public List<AudioClip> music;
}
