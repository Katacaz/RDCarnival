using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnerManager : MonoBehaviour
{
    public PowerupSpawner[] spawners;
    public bool powerupsEnabled;
    private bool stateChanged;

    GameModeSettingsManager settings;

    private void Awake()
    {
        spawners = FindObjectsOfType<PowerupSpawner>();
        settings = FindObjectOfType<GameModeSettingsManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (powerupsEnabled != settings.roundSettings.powerups)
        {
            stateChanged = true;
        }
        if ( stateChanged)
        {
            powerupsEnabled = settings.roundSettings.powerups;
            stateChanged = false;
            if (powerupsEnabled)
            {
                EnableAllSpawners();
            } else
            {
                DisableAllSpawners();
            }
        }
    }
    public void DisableAllSpawners()
    {
        foreach (PowerupSpawner spawner in spawners)
        {
            spawner.canSpawn = false;
        }
    }
    public void EnableAllSpawners()
    {
        foreach (PowerupSpawner spawner in spawners)
        {
            spawner.canSpawn = true;
        }
    }
}
