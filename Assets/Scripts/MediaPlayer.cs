using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MediaPlayer : MonoBehaviour
{
    [Header("Put playlist here:")]
    public Playlist playlist;
    AudioSource source;

    [Header("Volume")]
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Text volumeText;

    [Header("Buttons")]
    public Button playButton;
    public Button pauseButton;

    [Header("Slider for Playing Music")]
    public Slider progressSlider;
    public Text progressText;
    public Text currentlyPlayingText;

    [Header("Playlist")]
    public GameObject playlistDialog;
    public GameObject playlistItemPrefab;
    GameObject[] playlistItems;

    int currentSongIndex;

    void Start()
    {
        //Sets the default settings
        source = GetComponent<AudioSource>();
        progressText.text = "0:00 / 0:00";
        volumeText.text = "Volume: 100%";

        //Adds the songs
        AddSongs();

        //Sets the playlist area to inactive by default.
        playlistDialog.SetActive(false);
    }

    void Update()
    {
        if (source.isPlaying) //Sets the position of the playing slider to 
        {
            progressSlider.value = source.time / source.clip.length;
            progressText.text = Mathf.Floor(source.time) + " / " + Mathf.Floor(source.clip.length);
        }
    }

    public void SetSound(int id) //Sets the sound to the track selected.
    {
        currentSongIndex = id;
        source.clip = playlist.music[id];
        PlayMusic();
    }

    public void UpdateSongBackward()
    {
        source.Stop(); //Stops the current song.

        if (currentSongIndex > 0) //Deducts the song index
        {
            currentSongIndex--;
            source.clip = playlist.music[currentSongIndex]; //sets the relevent variables and plays the song.
            currentlyPlayingText.text = "Currently playing: " + playlist.music[currentSongIndex].name;
        }
        else
        {
            //start again.
            source.clip = playlist.music[0];
        }
        PlayMusic();
    }

    public void UpdateSongForward()
    {
        source.Stop(); //Stops the current song.

        if (currentSongIndex < playlist.music.Count) //Adds to the song index
        {
            currentSongIndex++;
            source.clip = playlist.music[currentSongIndex]; //sets the relevent variables
        }
        else 
        {
            //start again.
            currentSongIndex = 0;
            source.clip = playlist.music[0];
        }

        //plays the song.
        currentlyPlayingText.text = "Currently playing: " + playlist.music[currentSongIndex].name;
        PlayMusic();
    }

    public void PauseMusic() //pauses the music and swaps some buttons' visibilty
    {
        source.Pause();
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void PlayMusic() //plays the music, or picks up from where it was paused.
    {
        if (source.clip == null)
        {
            source.clip = playlist.music[0];
        }
        source.Play();
        currentlyPlayingText.text = "Currently playing: " + source.clip.name;
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void StopMusic() //stops the music and pulls it back to the beginning.
    {
        source.Stop();
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        progressSlider.value = 0;
        currentlyPlayingText.text = "Currently playing: ";
    }

    public void SetVolume(float volume) //Sets the volume of the media player
    {
        audioMixer.SetFloat("MediaPlayerVolume", volume);
        volumeText.text = "Volume: " + Mathf.Floor(((volume / 80) * 100) + 100) + "%";
    }

    public void TogglePlaylistView() //toggles wether or not the playlist shown.
    {
        playlistDialog.SetActive(!playlistDialog.activeSelf);
    }

    public void AddSongs() //Adds the songs into the playlist.
    {
        playlistItems = new GameObject[playlist.music.Count];
        for (int i = 0; i < playlist.music.Count; i++)
        {
            playlistItems[i] = Instantiate(playlistItemPrefab, GetComponentInChildren<VerticalLayoutGroup>().transform);
            playlistItems[i].GetComponent<PlaylistButton>().buttonID = i;
            playlistItems[i].GetComponent<PlaylistButton>().songName = playlist.music[i].name;
            playlistItems[i].GetComponent<PlaylistButton>().length = Mathf.Floor(playlist.music[i].length);
        }
    }
}
