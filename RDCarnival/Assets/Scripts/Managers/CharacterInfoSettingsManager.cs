using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoSettingsManager : MonoBehaviour
{

    public GameObject characterInfoGameSettingsPrefab;
    public Transform characterInfoField;

    public GameModeSettingsManager gameSettings;
    CharacterManager charManager;
    TeamManager teamManager;
    List<GameObject> characterSettings = new List<GameObject>();

    private void Awake()
    {
        charManager = FindObjectOfType<CharacterManager>();
        teamManager = FindObjectOfType<TeamManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //SetUpCharacterSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UsingCharacterTeams()
    {
        foreach (GameObject character in characterSettings)
        {
            character.GetComponent<CharacterInfoSettings>().UsingTeams();
        }
    }
    public void NotUsingCharacterTeams()
    {
        foreach (GameObject character in characterSettings)
        {
            character.GetComponent<CharacterInfoSettings>().NotUsingTeams();
        }
    }
    public void SetUpCharacterSettings()
    {
        if (characterInfoGameSettingsPrefab != null)
        {
            for (int i = 0; i < (charManager.characters.Length); i++) 
            {
                GameObject charSettings = Instantiate(characterInfoGameSettingsPrefab, characterInfoField);
                charSettings.GetComponent<CharacterInfoSettings>().InfoSetUp(gameSettings, charManager.characters[i], i, charManager, teamManager );
                charSettings.GetComponent<CharacterInfoSettings>().UpdateUsingTeams();
                characterSettings.Add(charSettings);
            }

        }
    }
    public void UpdateUsingTeams()
    {
        foreach (GameObject g in characterSettings)
        {
            if (gameSettings.roundSettings.useTeams)
            {
                g.GetComponent<CharacterInfoSettings>().UsingTeams();
            }
            else
            {
                g.GetComponent<CharacterInfoSettings>().NotUsingTeams();
            }
        }
    }
    public void ClearCharacterSettings()
    {
        foreach(GameObject g in characterSettings)
        {
            if (g != null)
            {
                Destroy(g);
            }
        }
        characterSettings.Clear();
    }
    
}
