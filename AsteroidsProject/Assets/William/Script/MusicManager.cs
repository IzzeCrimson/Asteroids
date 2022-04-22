using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public Slider volumeSlider;
    public Text songName;
    public Text playSongButton;
    int selectedSong;
    bool playSong;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        playSong = false;
        selectedSong = 0;
        SetSong();

    }

    void SetSong()
    {
        audioSource.clip = audioClips[selectedSong];
        songName.text = audioSource.clip.name;

    }

    public void OnPressNext()
    {

        selectedSong = (selectedSong + 1) % audioClips.Length;
        SetSong();
        KeepPlaying();

    }

    public void OnPressPrevious()
    {

        selectedSong = (selectedSong - 1) % audioClips.Length;

        if (selectedSong < 0)
        {
            selectedSong += audioClips.Length;
        }

        SetSong();
        KeepPlaying();
    }

    public void PlaySong()
    {
        playSong = !playSong;
        
        if (playSong)
        {
            audioSource.Play();
            playSongButton.text = "Stop Playing";
        }

        if (!playSong)
        {
            audioSource.Stop();
            playSongButton.text = "Start Playing";
        }

    }

    void KeepPlaying()
    {

        if (playSong)
        {
            audioSource.Play();
        }

    }

    public void ChangeVolume()
    {

        audioSource.volume = volumeSlider.value;

    }




}
