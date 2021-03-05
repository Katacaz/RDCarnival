using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerReadyMenu : MonoBehaviour
{
    public bool[] playerReady;
    public bool allPlayersReady;

    public Sprite playerReadyIcon;
    public Sprite playerNotReadyIcon;
    public Image[] readyObject;

    public GameObject menu;
    public bool gameReady;
    public GameObject allPlayersReadyNotice;

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
        CheckReadyPlayers();
        UpdateReadyObject();
        if (allPlayersReady)
        {
            allPlayersReadyNotice.SetActive(true);
        } else
        {
            allPlayersReadyNotice.SetActive(false);
        }
        if (gameReady)
        {
            menu.SetActive(false);
            if (gameState.gameStarted)
            {
                Time.timeScale = 1f;
            }
        } else
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ReadyPlayer(int player)
    {
        playerReady[player - 1] = true;
        if (allPlayersReady)
        {
            gameReady = true;
        }

    }
    public void UnReadyPlayer(int player)
    {
        playerReady[player - 1] = false;
    }
    public bool CheckReady(int player)
    {
        return playerReady[player - 1];
    }
    public void CheckReadyPlayers()
    {
        allPlayersReady = true;
        for (int i = 0; i < playerReady.Length; i++)
        {
            if (playerReady[i] == false)
            {
                allPlayersReady = false;
            }
        }
    }
    public void UpdateReadyObject()
    {
        for (int i = 0; i < playerReady.Length; i++)
        {
            if (playerReady[i] == true)
            {
                readyObject[i].sprite = playerReadyIcon;
            } else
            {
                readyObject[i].sprite = playerNotReadyIcon;
            }
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
