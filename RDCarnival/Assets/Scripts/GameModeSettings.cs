using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameModeSettings
{

    public bool useLives;
    public int lives;
    [Range(1,15)]
    public int health = 4;

    public bool useTimer;
    public int roundTimer;

    public bool useTeams;
    public bool friendlyFire;

    public bool powerups;

    [Header("Score Sort Method")]
    public int scoreSortMethod = 0;
    // 0 - by score, 1 - by kills, 2 - by lives

    public bool spectateNPCs = false;
}
