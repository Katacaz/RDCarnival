using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentPlayer = 1;
    public bool soloTesting = true;
    public GameObject[] players;

    private GameObject[] allCharacters;
    public int totalCharacters;

    CameraController cam;

    public KeyCode playerSwapKey;

    public Transform respawnPosition;

    public TextMeshProUGUI player1Warning;
    public TextMeshProUGUI player2Warning;

    public GameObject gameEndObject;
    bool gameEnding;
    public int gameOverSceneID;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        FindAllCharacters();
        if (respawnPosition == null)
        {
            respawnPosition.position = new Vector3 (0, 0, 0);

        }
    }

    private void FindAllCharacters()
    {
        allCharacters = GameObject.FindGameObjectsWithTag("Player");
        totalCharacters = 0;
        foreach (GameObject character in allCharacters)
        {
            if (character.GetComponent<CharacterTracker>().characterActive)
            {
                totalCharacters++;
            }
        }
        //totalCharacters = allCharacters.Length;
    }
    public void Player1LeftArea()
    {
        Debug.Log("Player 1 has left the play area.");
        players[0].transform.position = respawnPosition.position;
        players[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
        players[0].GetComponent<CharacterTracker>().characterActive = false;
        players[0].SetActive(false);
        FindAllCharacters();

    }
    public void Player2LeftArea()
    {
        Debug.Log("Player 2 has left the play area");
        players[1].transform.position = respawnPosition.position;
        players[1].GetComponent<Rigidbody>().velocity = Vector3.zero;
        players[1].GetComponent<CharacterTracker>().characterActive = false;
        players[1].SetActive(false);
        FindAllCharacters();
    }
    // Update is called once per frame
    void Update()
    {
        if (soloTesting)
        {
            if (Input.GetKeyDown(playerSwapKey))
            {
                NextPlayer();
            }
        }

        if (players[0].GetComponent<OutOfBoundsChecker>().isOutOfBounds)
        {
            player1Warning.text = "WARNING: RETURN TO THE WATER\n" + Mathf.RoundToInt(players[0].GetComponent<OutOfBoundsChecker>().timerLimit - players[0].GetComponent<OutOfBoundsChecker>().timerCounter).ToString();
        } else
        {
            player1Warning.text = "";
        }
        if (players[1].GetComponent<OutOfBoundsChecker>().isOutOfBounds)
        {
            player2Warning.text = "WARNING: RETURN TO THE WATER\n" + Mathf.RoundToInt(players[1].GetComponent<OutOfBoundsChecker>().timerLimit - players[1].GetComponent<OutOfBoundsChecker>().timerCounter).ToString();
        }
        else
        {
            player2Warning.text = "";
        }
        if (!gameEnding)
        {
            if (totalCharacters == 1)
            {
                gameEnding = true;
                gameEndObject.SetActive(true);
                SceneManager.LoadScene(gameOverSceneID);
            }
        }
    }

    void NextPlayer()
    {
        if (currentPlayer < players.Length)
        {
            currentPlayer++;
            
        } else
        {
            currentPlayer = 1;
        }
        cam.ChangeTarget(players[currentPlayer - 1]);
    }
}
