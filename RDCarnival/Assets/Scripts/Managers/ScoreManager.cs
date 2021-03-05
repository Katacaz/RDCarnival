using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    CharacterManager charManager;

    public int elimScoreMultiplier = 1;

    public GameObject scoreboard;
    public bool scoreboardState;
    public GameObject scoreboardItem;
    public Transform playerScoreboardList;

    public List<ScoreInfo> scores;
    private List<TeamInfo> teamScores;
    private GameModeSettingsManager gameSettings;

    private TeamManager teamManager;

    public Color deadCharColor;
    // Start is called before the first frame update
    void Start()
    {
        charManager = FindObjectOfType<CharacterManager>();
        gameSettings = FindObjectOfType<GameModeSettingsManager>();
        teamManager = FindObjectOfType<TeamManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddElimScore(string characterName, int amount)
    {
        foreach (CharacterInfo c in charManager.characters)
        {
            if (c.info.characterName == characterName)
            {
                //if the name of the character matches who is recieving point.
                c.info.score += (amount * elimScoreMultiplier);

            }
        }
        UpdateScoreboard();
    }
    public void AddScore(string characterName, int amount)
    {
        foreach (CharacterInfo c in charManager.characters)
        {
            if (c.info.characterName == characterName)
            {
                //if the name of the character matches who is recieving point.
                c.info.score += amount;

            }
        }
        UpdateScoreboard();
    }
    public void SubtractScore(string characterName, int amount)
    {
        foreach (CharacterInfo c in charManager.characters)
        {
            if (c.info.characterName == characterName)
            {
                //if the name of the character matches who is recieving point.
                c.info.score += amount;

            }
        }
        UpdateScoreboard();
    }


    public void OnScoreboard()
    {
        scoreboardState = !scoreboardState;
        if (scoreboardState)
        {
            GenerateScoreInfo();
            scoreboard.SetActive(true);
            scores.Sort(SortByTeamID);
            scores.Sort(SortByScore);
            scores.Reverse();
            SetUpScoreboard();
        }
        else
        {

            scoreboard.SetActive(false);
            EmptyScoreboard();
        }
    }
    public void UpdateScoreboard()
    {
        GenerateScoreInfo();
        SortScoreBoard();
        UpdateTeamScore();
        if (scoreboardState)
        {    
            EmptyScoreboard();
            SetUpScoreboard();
        }
    }
    public void SortScoreBoard()
    {
        scores.Sort(SortByTeamID);
        if (gameSettings.roundSettings.scoreSortMethod == 0)
        {
            //sorting by score
            scores.Sort(SortByScore);
        }
        else if (gameSettings.roundSettings.scoreSortMethod == 1)
        {
            //sorting by kills
            scores.Sort(SortByKills);
        }
        else if (gameSettings.roundSettings.scoreSortMethod == 2)
        {
            //sorting by lives
            scores.Sort(SortByLives);
        }
        scores.Reverse();
    }
    public void SetUpScoreboard()
    {
        //Get array of players
        /*foreach (CharacterInfo c in charManager.characters)
        {
            GameObject itemGO = (GameObject)Instantiate(scoreboardItem, playerScoreboardList);
            PlayerScoreboardItem item = itemGO.GetComponent<PlayerScoreboardItem>();
            if (item != null)
            {
                Color teamColor = FindObjectOfType<TeamManager>().TeamIDtoColor(c.info.teamID);
                item.SetUp(c.info.characterName, c.info.eliminations, c.info.deaths, c.info.score, teamColor);
            }
        }*/

        foreach (ScoreInfo score in scores)
        {
            GameObject itemGO = (GameObject)Instantiate(scoreboardItem, playerScoreboardList);
            PlayerScoreboardItem item = itemGO.GetComponent<PlayerScoreboardItem>();
            if (item != null)
            {

                Color teamColor = FindObjectOfType<TeamManager>().TeamIDtoColor(score.teamID);
               
                item.SetUp(score.username, score.kills, score.deaths, score.score, teamColor);
                
                
                if (score == scores[0])
                {
                    //if the top score
                    item.usernameText.fontSize = item.usernameText.fontSize * 1.2f;
                    item.killsText.fontSize = item.killsText.fontSize * 1.2f;
                    item.deathsText.fontSize = item.deathsText.fontSize * 1.2f;
                    item.scoreText.fontSize = item.scoreText.fontSize * 1.2f;
                }
                else if (score == scores[1])
                {
                    //if the 2nd score
                    item.usernameText.fontSize = item.usernameText.fontSize * 1.1f;
                    item.killsText.fontSize = item.killsText.fontSize * 1.1f;
                    item.deathsText.fontSize = item.deathsText.fontSize * 1.1f;
                    item.scoreText.fontSize = item.scoreText.fontSize * 1.1f;
                }
            }
        }
        //loop through and set up list for each player


    }
    public void EmptyScoreboard()
    {
        foreach(Transform child in playerScoreboardList)
        {
            Destroy(child.gameObject);
        }
    }

    public void GenerateScoreInfo()
    {
        //First clear the current scores
        scores.Clear();

        foreach (CharacterInfo c in charManager.characters)
        {
            if (c.info.isUsed)
            {
                ScoreInfo characterScore = ScriptableObject.CreateInstance(typeof(ScoreInfo)) as ScoreInfo;
                characterScore.username = c.info.characterName;
                characterScore.kills = c.info.eliminations;
                characterScore.deaths = c.info.deaths;
                characterScore.score = c.info.score;
                characterScore.lives = c.info.lives;
                characterScore.teamID = c.info.teamID;

                scores.Add(characterScore);
            }
        }
    }

    public ScoreInfo FindScore(int position)
    {
        ScoreInfo info = ScriptableObject.CreateInstance(typeof(ScoreInfo)) as ScoreInfo;
        info.username = "UNKNOWN";
        info.kills = 0;
        info.deaths = 0;
        info.score = 0;
        info.lives = 0;
        info.teamID = 0;
        UpdateScoreboard();
        if (position <= scores.Count)
        {
            if (scores[position] != null)
            {
                info = scores[position];
            }
        }
        return info;
    }
    public void UpdateTeamScore()
    {
        foreach (TeamInfo team in teamManager.teams)
        {
            team.totalTeamScore = 0;
            foreach (CharacterInfo c in charManager.characters)
            {
                if (c.info.isUsed)
                {
                    if (c.info.teamID == team.teamID)
                    {
                        team.totalTeamScore += c.info.score;
                    }
                }
            }
        }
        teamScores = teamManager.teams;
        teamScores.Sort(SortByTeamScore);
        teamScores.Reverse();
    }
    public TeamInfo FindTeamScore(int position)
    {
        TeamInfo info = new TeamInfo();
        UpdateScoreboard();
        
        if (position <= teamScores.Count)
        {
            if (teamScores[position] != null)
            {
                info = teamScores[position];
            }
        }
        return info;
    }

    static int SortByScore(ScoreInfo s1, ScoreInfo s2)
    {
        return s1.score.CompareTo(s2.score);
    }
    static int SortByKills(ScoreInfo s1, ScoreInfo s2)
    {
        return s1.kills.CompareTo(s2.kills);
    }
    static int SortByLives(ScoreInfo s1, ScoreInfo s2)
    {
        return s1.lives.CompareTo(s2.lives);
    }
    static int SortByTeamID(ScoreInfo s1, ScoreInfo s2)
    {
        return s1.teamID.CompareTo(s2.teamID);
    }
    static int SortByTeamScore(TeamInfo t1, TeamInfo t2)
    {
        return t1.totalTeamScore.CompareTo(t2.totalTeamScore);
    }
}

public class ScoreInfo : ScriptableObject
{
    public string username;
    public int kills;
    public int deaths;
    public int score;
    public int lives;
    public int teamID;
}
