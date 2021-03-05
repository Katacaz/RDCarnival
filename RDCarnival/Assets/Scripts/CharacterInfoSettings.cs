using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoSettings : MonoBehaviour
{

    CharacterInfo charInfo;
    int charID;
    CharacterManager charManager;
    TeamManager teamManager;

    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI characterTeamText;
    
    public Image teamIcon;

    public GameObject teamIconFrame;
    public GameObject characterActiveButton;
    public Image activeCharacterIcon;
    public Sprite npcActive;
    public Sprite npcNotActive;

    GameModeSettingsManager gameSettings;
    GameSettingsMenu settingsMenu;
    public bool gotInfo;
    private void Awake()
    {
        settingsMenu = FindObjectOfType<GameSettingsMenu>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gotInfo)
        {
            SetCharacterName();
            UpdateTeamIcon();
            UpdateTeamColor();
        }
    }

    public void InfoSetUp(GameModeSettingsManager gameModeSettingsManager, CharacterInfo characterInfo, int characterID, CharacterManager cManager, TeamManager tManager)
    {
        gotInfo = true;
        charInfo = characterInfo;
        charID = characterID;
        charManager = cManager;
        teamManager = tManager;
        gameSettings = gameModeSettingsManager;

        SetCharacterName();
        SetCharacterTeamIcon();
        UpdateTeamIcon();
        InitialCharacterActiveButtonSetup();
    }
    public void InitialCharacterActiveButtonSetup()
    {
        //sets whether the button is usable if player is NPC or not
        if (!charInfo.info.isNPC)
        {
            characterActiveButton.SetActive(false);
            charInfo.info.isUsed = true;
        }
        else
        {
            charInfo.info.isUsed = charInfo.info.isActive;
            if (charInfo.info.isActive)
            {
                activeCharacterIcon.sprite = npcActive;
            }
            else
            {
                activeCharacterIcon.sprite = npcNotActive;
            }
        }
    }
    public void ToggleCharacterActive()
    {
        charInfo.info.isActive = !charInfo.info.isActive;
        charInfo.info.isUsed = charInfo.info.isActive;
        if (charInfo.info.isActive)
        {
            activeCharacterIcon.sprite = npcActive;
        } else
        {
            activeCharacterIcon.sprite = npcNotActive;
        }
    }
    public void SetCharacterName()
    {
        characterNameText.text = charInfo.info.characterName;
    }

    public void SetCharacterTeamIcon()
    {
        teamIcon.sprite = teamManager.TeamIDtoIcon(charInfo.info.teamID);
    }
    public void UpdateLocalCharacterInfo()
    {
        charInfo = charManager.characters[charID];
    }
    public void UpdateGlobalCharacterInfo()
    {
        charManager.characters[charID] = charInfo;
    }

    public void NextTeam()
    {
        if (charInfo.info.teamID < teamManager.teamManager.teams.Length - 1)
        {
            charInfo.info.teamID++;
        } else
        {
            charInfo.info.teamID = 1;
        }
        UpdateGlobalCharacterInfo();
        UpdateTeamIcon();

    }
    public void UpdateTeamIcon()
    {
        foreach(TeamInfo team in teamManager.teamManager.teams)
        {
            if (charInfo.info.teamID == team.teamID)
            {
                teamIcon.sprite = team.teamIcon;
            }
        }
        if (characterTeamText != null)
        {
            if (charInfo != null)
            {
                characterTeamText.text = charInfo.info.teamID.ToString();
            }
        }
    }
    public void UpdateUsingTeams()
    {
        if (gameSettings.roundSettings.useTeams)
        {
            UsingTeams();
        } else
        {
            NotUsingTeams();
        }
    }
    public void NotUsingTeams()
    {
        charInfo.info.teamID = 0;
        UpdateGlobalCharacterInfo();
        teamIconFrame.SetActive(false);
    }
    public void UsingTeams()
    {
        
        charInfo.info.teamID = Random.Range(1, teamManager.teams.Count -1);
        UpdateGlobalCharacterInfo();
        teamIconFrame.SetActive(true);
    }
    public void UpdateTeamColor()
    {
        if (gameSettings.roundSettings.friendlyFire)
        {
            //If using friendly fire
            teamIcon.color = Color.white;
        } else
        {
            teamIcon.color = teamManager.teams[charInfo.info.teamID].teamColor;
        }
    }
}
