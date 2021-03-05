using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class TeamInfo
{
    public string teamName;
    public int teamID;
    public Sprite teamIcon;
    public Color teamColor;
    public List<CharacterInfo> teamMembers;
    public int totalTeamScore;
    public int totalTeamMembers;
}
