using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    public bool canPause;

    GameStateCheck gameState;

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
        if (!isPaused)
        {
            pauseMenu.SetActive(false);
            gameState.gamePaused = false;
        } else
        {
            pauseMenu.SetActive(true);
            gameState.gamePaused = true;
            Time.timeScale = 0f;
        }
        canPause = gameState.gameStarted;
        //Debug.Log(Time.timeScale.ToString());
    }

    public void TogglePauseGame()
    {
        if (canPause)
        {
            if (isPaused)
            {
                //Unpause Game
                Time.timeScale = 1f;
                isPaused = false;

            }
            else
            {
                //Pause Game
                Time.timeScale = 0f;
                isPaused = true;
            }
            
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
