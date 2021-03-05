using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource bgmSource;
    GameStateCheck gameState;
    [Header("Music")]
    public AudioClip gameSettingsMusic;
    public AudioClip gamePlayMusic;
    float gameplayMusicTime;
    public AudioClip gamePauseMusic;
    float gamePauseMusicTime;
    public AudioClip gameEndMusic;
    int musicState;
    int tempState = -1;
    [Header("Transition Effects")]
    public AudioSource sfxSource;
    public AudioClip gamePlayTransitionSFX;
    public AudioClip gamePauseTransitionSFX;
    public AudioClip gameUnPauseTransitionSFX;
    public AudioClip gameEndTransitionSFX;

    private void Awake()
    {
        gameState = FindObjectOfType<GameStateCheck>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMusicState();
        if (tempState != musicState)
        {
            ChangeMusic();
            tempState = musicState;
        }
        gameplayMusicTime = bgmSource.time;
    }
    public void UpdateMusicState()
    {
        if (gameState.gameModeSettings)
        {
            musicState = 0;
        } else if (gameState.gamePlay && !gameState.gamePaused)
        {
            musicState = 1;
        } else if (gameState.gamePaused)
        {
            musicState = 2;
        } else if (gameState.gameEnd)
        {
            musicState = 3;
        }
    }
    public void ChangeMusic()
    {
        if (tempState == 1)
        {
            if (musicState == 2)
            {
                //If the game paused
                gameplayMusicTime = bgmSource.time;
                bgmSource.clip = gamePauseMusic;
                bgmSource.time = gameplayMusicTime;
                bgmSource.Play();
                sfxSource.clip = gamePauseTransitionSFX;
                sfxSource.Play();
            }
        }
        if (tempState == 2)
        {
            if (musicState == 1)
            {
                //if unpaused
                gamePauseMusicTime = bgmSource.time;
                bgmSource.clip = gamePlayMusic;
                bgmSource.time = gamePauseMusicTime;
                bgmSource.Play();
                sfxSource.clip = gameUnPauseTransitionSFX;
                sfxSource.Play();
            }
        }
        if (musicState == 0)
        {
            //In the game settings menu
            bgmSource.clip = gameSettingsMusic;
            bgmSource.Play();

        }
        if (musicState == 1)
        {
            //When the game starts
            bgmSource.clip = gamePlayMusic;
            bgmSource.Play();
            sfxSource.clip = gamePlayTransitionSFX;
            sfxSource.Play();
        }
        if (musicState == 3)
        {
            //When the game ends
            if (gameEndMusic != null)
            {
                bgmSource.clip = gameEndMusic;
                bgmSource.Play();
                sfxSource.clip = gameEndTransitionSFX;
                sfxSource.Play();
            }
        }
    }
}
