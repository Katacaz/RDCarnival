using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterRoundStats
{
    public string characterName;
    public int health;
    public int eliminations;
    public int deaths;
    public int score;
    public int lives;
    [Range(0, 8)]
    public int teamID;
    public bool isNPC;

    public bool isActive = true;
    public bool isUsed = true;
}
