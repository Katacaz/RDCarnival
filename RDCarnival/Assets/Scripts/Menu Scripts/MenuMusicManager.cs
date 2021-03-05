using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    public AudioSource musicSource;

    [Header("Music")]
    public AudioClip mainMusic;

    [Header("SFX")]
    public AudioSource sfxSource;

    public AudioClip buttonClickSFX;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = mainMusic;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClick()
    {
        sfxSource.clip = buttonClickSFX;
        sfxSource.Play();
    }
}
