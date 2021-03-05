using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public CharacterManager charManager;
    public GlobalTeamManager teamManager;
    public List<TeamInfo> teams;
    private void Awake()
    {
        charManager = FindObjectOfType<CharacterManager>();
        teamManager = FindObjectOfType<GlobalTeamManager>();
        teams = teamManager.teams.ToList<TeamInfo>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetTeams()
    {
        foreach (TeamInfo team in teams)
        {
            team.totalTeamMembers = 0;
            team.teamMembers.Clear();
        }

    }
    public void SeperateTeams()
    {
        ResetTeams();
        //first get totals for each team
        foreach (CharacterInfo c in charManager.characters)
        {
            foreach (TeamInfo team in teams)
            {
                if (c.info.teamID == team.teamID)
                {
                    team.teamMembers.Add(c);
                    team.totalTeamMembers++;
                }
            }
        }
    }
    public string TeamIDtoName(int teamID)
    {
        string teamName = "";
        foreach(TeamInfo team in teams)
        {
            if (teamID == team.teamID)
            {
                teamName = team.teamName;
            }
        }

        return teamName;
    }

    public Color TeamIDtoColor(int teamID)
    {
        Color teamColor = Color.gray;
        foreach (TeamInfo team in teams)
        {
            if (teamID == team.teamID)
            {
                teamColor = team.teamColor;
            }
        }
        return teamColor;
    }
    public Sprite TeamIDtoIcon(int teamID)
    {
        Sprite teamIcon = null;
        foreach(TeamInfo team in teams)
        {
            if (teamID == team.teamID)
            {
                teamIcon = team.teamIcon;
            }
        }
        return teamIcon;
    }
    public List<CharacterInfo> FindTeamMembersByID(int teamID)
    {
        List<CharacterInfo> teamMembers = new List<CharacterInfo>();
        foreach(TeamInfo team in teams)
        {
            if (teamID == team.teamID)
            {
                teamMembers = team.teamMembers;
            }
        }
        return teamMembers;
    }
    public int FindTotalTeamMembers(int teamID)
    {
        int totalTeamMembers = 0;
        foreach(TeamInfo team in teams)
        {
            if (teamID == team.teamID)
            {
                totalTeamMembers = team.totalTeamMembers;
            }
        }
        return totalTeamMembers;
    }
}
