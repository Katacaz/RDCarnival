using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSettingsManager : MonoBehaviour
{

    public GameModeSettings roundSettings;

    private void Awake()
    {
        UpdateGameModeSettings();
    }
    public void UpdateGameModeSettings()
    {
        GlobalGameModeSettingsManager settingsManager = FindObjectOfType<GlobalGameModeSettingsManager>();

        if (settingsManager != null)
        {
            roundSettings = settingsManager.roundSettings;
        }
    }
}
