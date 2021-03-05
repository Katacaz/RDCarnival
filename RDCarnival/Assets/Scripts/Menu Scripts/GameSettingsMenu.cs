using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject gameModeManager;
    CharacterManager charManager;
    TeamManager teamManager;
    GlobalGameModeSettingsManager globalGameModeSettings;
    GameModeSettings settings = new GameModeSettings();
    public CharacterInfoSettingsManager characterInfo;

    [Header("Menu Objects")]
    public Sprite optionTrueSprite;
    public Sprite optionFalseSprite;
    public Image isStockIcon;
    public TextMeshProUGUI stockAmount;
    public Image isTimerIcon;
    public TextMeshProUGUI timerAmount;
    public TextMeshProUGUI healthAmount;
    public Image isTeamsIcon;
    public Image isFriendlyFireIcon;
    public Image isPowerupsIcon;
    public Image isSpectateNPCs;
    

    [Header("MenuGroups")]
    public GameObject stockTrue;
    public GameObject timerTrue;
    public GameObject teamsTrue;

    [Header("Settings Summary Text")]
    public TextMeshProUGUI summaryText;

    [Header("Win Condition Setting")]
    public TextMeshProUGUI winConText;

    GameStateCheck gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameStateCheck>();
        gameState.gameModeSettings = true;
        globalGameModeSettings = FindObjectOfType<GlobalGameModeSettingsManager>();
        charManager = FindObjectOfType<CharacterManager>();
        teamManager = FindObjectOfType<TeamManager>();
        if (globalGameModeSettings != null)
        {
            settings = globalGameModeSettings.roundSettings;
        }
        characterInfo.SetUpCharacterSettings();
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        //Set Using Stock Icon
        if (settings.useLives)
        {
            isStockIcon.sprite = optionTrueSprite;
        } else
        {
            isStockIcon.sprite = optionFalseSprite;
        }
        stockTrue.SetActive(settings.useLives);
        stockAmount.text = "Lives: " + settings.lives.ToString();

        //Set Using Timer Icon
        if (settings.useTimer)
        {
            isTimerIcon.sprite = optionTrueSprite;
        } else
        {
            isTimerIcon.sprite = optionFalseSprite;
        }
        timerTrue.SetActive(settings.useTimer);
        timerAmount.text = "Time: " + settings.roundTimer.ToString();

        healthAmount.text = "Health: " + settings.health.ToString();

        if (settings.useTeams)
        {
            isTeamsIcon.sprite = optionTrueSprite;
        } else
        {
            isTeamsIcon.sprite = optionFalseSprite;
            
        }
        teamsTrue.SetActive(settings.useTeams);
        if (settings.friendlyFire)
        {
            isFriendlyFireIcon.sprite = optionTrueSprite;
        } else
        {
            isFriendlyFireIcon.sprite = optionFalseSprite;
        }

        if (settings.powerups)
        {
            isPowerupsIcon.sprite = optionTrueSprite;
        } else
        {
            isPowerupsIcon.sprite = optionFalseSprite;
        }
        if (settings.spectateNPCs)
        {
            isSpectateNPCs.sprite = optionTrueSprite;
        } else
        {
            isSpectateNPCs.sprite = optionFalseSprite;
        }
        SummaryTextUpdate();
    }

    public void SummaryTextUpdate()
    {
        string sumText = "Players take " + settings.health.ToString() + " hits to lose a life.";
        if (settings.useLives && settings.useTimer && settings.useTeams)
        {
            //If using Lives + Time + Teams
            sumText += " The game will end after " + settings.roundTimer.ToString() + " seconds OR one team remains.";
        } else if (settings.useLives && settings.useTimer && !settings.useTeams)
        {
            //if using Lives + Time (and no teams)
            sumText += " The game will end after " + settings.roundTimer.ToString() + " seconds OR one player remains.";
        } else if (settings.useLives && !settings.useTimer)
        {
            //if using lives not time
            sumText += " The game will end when one player remains.";
        } else if (settings.useTimer && !settings.useLives)
        {
            //if using time not lives
            sumText += " The game will end after " + settings.roundTimer.ToString() + " seconds.";
        } else if (!settings.useLives && !settings.useTimer)
        {
            //if not using time or lives
            sumText += " *Game will default to use Stock with 3 lives if not using Time or Stock.*";
        }

        if (settings.useTeams && settings.friendlyFire)
        {
            sumText += " Team members can hurt each other.";
        }
        if (settings.powerups)
        {
            sumText += " Powerups will be available.";
        }
        if (!settings.spectateNPCs)
        {
            sumText += " Game will end if there are only NPC's remaining";
        }
        if (settings.scoreSortMethod == 0)
        {
            //win by score
            sumText += " Winner determined by Score.";
        }
        else if (settings.scoreSortMethod == 1)
        {
            //win by kills
            sumText += " Winner determined by total eliminations.";
        }
        else if (settings.scoreSortMethod == 2)
        {
            //win by lives
            sumText += " Winner determined by total remaining lives.";
        }
        summaryText.text = sumText;

    }
    public void ToggleUseStock()
    {
        settings.useLives = !settings.useLives;
    }
    public void IncreaseLives()
    {
        if (settings.lives < 15)
        {
            settings.lives++;
        } else
        {
            settings.lives = 1;
        }
    }
    public void DecreaseLives()
    {
        if (settings.lives > 0)
        {
            settings.lives--;
        }
        else
        {
            settings.lives = 15;
        }
    }
    public void ToggleUseTimer()
    {
        settings.useTimer = !settings.useTimer;
    }
    public void IncreaseTimer(int amount)
    {
        if (settings.roundTimer <= (1800 - amount))
        {
            settings.roundTimer += amount;
        } else
        {
            settings.roundTimer = 1;
        }
    }
    public void DecreaseTimer(int amount)
    {
        if (settings.roundTimer >= (1 + amount))
        {
            settings.roundTimer -= amount;
        }
        else
        {
            settings.roundTimer = 1800;
        }
    }
    public void IncreaseHealth()
    {
        if (settings.health < 15)
        {
            settings.health++;
        } else
        {
            settings.health = 1;
        }
    }
    public void DecreaseHealth()
    {
        if (settings.health > 1)
        {
            settings.health--;
        }
        else
        {
            settings.health = 15;
        }
    }
    public void ToggleUseTeams()
    {
        //Debug.Log("Toggled Teams");
        settings.useTeams = !settings.useTeams;
        characterInfo.UpdateUsingTeams();

    }
    public void ToggleUseFriendlyFire()
    {
        settings.friendlyFire = !settings.friendlyFire;
    }
    public void TogglePowerUps()
    {
        settings.powerups = !settings.powerups;
    }
    public void ToggleSpectateNPCs()
    {
        settings.spectateNPCs = !settings.spectateNPCs;
    }
    public void NextWinCondition()
    {
        if (settings.scoreSortMethod < 2)
        {
            settings.scoreSortMethod++;
        } else
        {
            settings.scoreSortMethod = 0;
        }
        UpdateWinConText();
    }
    public void UpdateWinConText()
    {
        if (settings.scoreSortMethod == 0)
        {
            //Win by Score
            winConText.text = "Win by: Score";
        }
        if (settings.scoreSortMethod == 1)
        {
            //Win by Kills
            winConText.text = "Win by: Eliminations";
        }
        if (settings.scoreSortMethod == 2)
        {
            //Win by Lives
            winConText.text = "Win by: Lives";
        }
    }
    public void StartGame()
    {
        gameState.gameModeSettings = false;
        globalGameModeSettings = FindObjectOfType<GlobalGameModeSettingsManager>();
        if (!settings.useTeams)
        {
            settings.friendlyFire = true;
        }
        globalGameModeSettings.roundSettings = settings;
        settingsMenu.SetActive(false);
        characterInfo.gameObject.SetActive(false);
        gameModeManager.SendMessage("StartGame");
    }
}
