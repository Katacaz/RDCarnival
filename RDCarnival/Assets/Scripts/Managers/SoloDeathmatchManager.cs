using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoloDeathmatchManager : MonoBehaviour
{

    [Header("Timer")]
    public bool timerStarted;
    private float roundTimer;
    private float timerCounter;
    private float timeRatio;
    public GameObject timerObject;
    public TextMeshProUGUI timerText;
    public Image ratioImage;
    //public Animator timerAnimator;

    [Header("Managers")]
    CharacterManager characterManager;
    RespawnManager respawnManager;
    EliminationManager eliminationManager;
    TeamManager teamManager;
    GameModeSettingsManager gameModeSettingsManager;

    public CharacterInfo mainPlayerInfo;

    [Header("End Game Screen")]
    public GameObject gameEndScreen;
    public TextMeshProUGUI winnerNameText;
    public TextMeshProUGUI winnerElimsText;
    public TextMeshProUGUI secondNameText;
    public TextMeshProUGUI secondScoreText;
    public TextMeshProUGUI thirdNameText;
    public TextMeshProUGUI thirdScoreText;

    public GameObject winningTeamObject;
    public TextMeshProUGUI winningTeamText;
    public Image winningTeamIcon;

    public GameObject gameModeSettingsMenu;

    int highestScore = 0;
    string highestScoreName;
    int secondScore = 0;
    string secondScoreName;
    int thirdScore = 0;
    string thirdScoreName;

    public int startDelayTime = 3;
    public TextMeshProUGUI startTimerCountdown;
    private bool startTimerDone = false;

    PauseMenu pauseMenu;
    GameStateCheck gameState;

    public int remainingPlayers;
    private void Awake()
    {
        Time.timeScale = 0f;
        gameEndScreen.SetActive(false);
        characterManager = GetComponent<CharacterManager>();
        respawnManager = GetComponent<RespawnManager>();
        eliminationManager = GetComponent<EliminationManager>();
        teamManager = GetComponent<TeamManager>();
        gameModeSettingsManager = GetComponent<GameModeSettingsManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        gameState = FindObjectOfType<GameStateCheck>();
        teamManager.charManager = characterManager;
        gameModeSettingsMenu.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartGame();


    }
    public void StartGame()
    {
        
        teamManager.SeperateTeams();
        SetGameSettings();
        
        StartCoroutine(startDelay());
    }
    public void SetGameSettings()
    {
        gameModeSettingsManager.UpdateGameModeSettings();
        GameModeSettings settings = gameModeSettingsManager.roundSettings;
        if (!settings.useLives && !settings.useTimer)
        {
            //if for some reason said not using stock OR timer - default to use 3 lives
            gameModeSettingsManager.roundSettings.useLives = true;
            gameModeSettingsManager.roundSettings.lives = 3;
        }
        foreach (CharacterInfo character in characterManager.characters)
        {
            character.info.health = settings.health;
            character.GetComponent<Health>().UpdateHealth();
        }

        if (settings.useLives)
        {
            respawnManager.isStock = true;
            foreach (CharacterInfo character in characterManager.characters)
            {
                if (settings.lives <= 0)
                {
                    gameModeSettingsManager.roundSettings.lives = 1;
                }
                character.info.lives = gameModeSettingsManager.roundSettings.lives;
            }
        }
        if (settings.useTimer)
        {
            if (settings.roundTimer < 10)
            {
                gameModeSettingsManager.roundSettings.roundTimer = 10;
            }
            timerStarted = true;
            roundTimer = settings.roundTimer;
            timerCounter = roundTimer;
        } else
        {
            timerObject.SetActive(false);
        }

        foreach(CharacterInfo c in characterManager.characters)
        {
            if (!c.info.isUsed)
            {
                c.gameObject.SetActive(false);
            }
        }

    }

    public void CheckForLastStanding()
    {
        if (!gameModeSettingsManager.roundSettings.spectateNPCs)
        {
            if (respawnManager.CheckRemainingUserPlayers() <= 0)
            {
                timerStarted = false;
                RoundEnd();
            }
        }
        if (gameModeSettingsManager.roundSettings.useTeams)
        {
            //If using teams, check for last team standing
            if (respawnManager.CheckRemainingTeams() <= 1)
            {
                timerStarted = false;
                RoundEnd();
            }
        } else
        {
            //If not using teams, check for last player standing
            if (respawnManager.CheckRemainingPlayers() <= 1)
            {
                timerStarted = false;
                RoundEnd();
            }
        }

    }

    IEnumerator startDelay()
    {
        gameState.gamePlay = true;
        for (int i = startDelayTime; i > 0; i-- ){
            startTimerCountdown.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);

        }
        startTimerCountdown.text = "GO!";
        yield return new WaitForSecondsRealtime(0.5f);
        startTimerCountdown.gameObject.SetActive(false);
        startTimerDone = true;
        gameState.gameStarted = true;
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameState.gamePaused)
        {
            if (startTimerDone)
            {
                if (timerStarted)
                {
                    if (timerCounter > 0)
                    {
                        timerCounter -= Time.deltaTime;

                    }
                    else
                    {
                        timerStarted = false;
                        RoundEnd();
                    }
                    UpdateTimerUI();
                }
                if (gameModeSettingsManager.roundSettings.useLives)
                {
                    CheckForLastStanding();
                }
            }
        }
    }

    public void StartRound()
    {
        Time.timeScale = 1f;
        
        //respawnManager.SetStockLives();
        //Debug.Log("Round Started");
    }
    public void UpdateTimerUI()
    {
        if (gameModeSettingsManager.roundSettings.useTimer)
        {
            timerObject.SetActive(true);
            timeRatio = timerCounter / roundTimer;
            ratioImage.fillAmount = 1 - timeRatio;
            timerText.text = Mathf.RoundToInt(timerCounter).ToString();
            //timerAnimator.SetFloat("Time", timerCounter);
        } else
        {
            timerObject.SetActive(false);
        }
    }

    public void RoundEnd()
    {
        Time.timeScale = 0f;
        gameState.gameStarted = false;
        gameState.gamePlay = false;
        gameState.gameEnd = true;
        
        FindWinner();
        if (gameModeSettingsManager.roundSettings.useTeams)
        {
            FindWinningTeam();
        } else
        {
            winningTeamObject.SetActive(false);
        }
        winnerNameText.text = highestScoreName;
        winnerElimsText.text = highestScore.ToString();
        secondNameText.text = secondScoreName;
        secondScoreText.text = secondScore.ToString();
        thirdNameText.text = thirdScoreName;
        thirdScoreText.text = thirdScore.ToString();
        gameEndScreen.SetActive(true);
    }

    public void FindWinner()
    {

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        ScoreInfo firstInfo = ScriptableObject.CreateInstance(typeof(ScoreInfo)) as ScoreInfo;
        firstInfo = scoreManager.FindScore(0);
        ScoreInfo secondInfo = ScriptableObject.CreateInstance(typeof(ScoreInfo)) as ScoreInfo;
        secondInfo = scoreManager.FindScore(1);
        ScoreInfo thirdInfo = ScriptableObject.CreateInstance(typeof(ScoreInfo)) as ScoreInfo;
        thirdInfo = scoreManager.FindScore(2);
        
        highestScore = firstInfo.score;
        highestScoreName = firstInfo.username;

        secondScore = secondInfo.score;
        secondScoreName = secondInfo.username;

        thirdScore = thirdInfo.score;
        thirdScoreName = thirdInfo.username;

    }
    public void FindWinningTeam()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        TeamInfo winningTeam = new TeamInfo();
        winningTeam = scoreManager.FindTeamScore(0);
        if (winningTeamText != null)
        {
            winningTeamText.text = winningTeam.teamName;
        }
        if (winningTeamIcon != null)
        {
            winningTeamIcon.sprite = winningTeam.teamIcon;
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
