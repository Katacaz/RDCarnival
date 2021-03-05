using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScoreboardItem : MonoBehaviour
{

    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI killsText; 
    public TextMeshProUGUI deathsText; 
    public TextMeshProUGUI scoreText;

    public void SetUp(string username, int kills, int deaths, int score, Color teamColor)
    {
        usernameText.text = username;
        usernameText.color = teamColor;
        killsText.text = "K: " + kills.ToString();
        killsText.color = teamColor;
        deathsText.text = "D: " + deaths.ToString();
        deathsText.color = teamColor;
        scoreText.text = score.ToString();
        scoreText.color = teamColor;
    }
    
}
