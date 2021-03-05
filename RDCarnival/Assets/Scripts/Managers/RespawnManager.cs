using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RespawnManager : MonoBehaviour
{

    public bool canRespawn;
    [Header("Stock Settings")]
    public bool isStock;
    public int lives;

    public Transform[] respawnLocations;

    public float respawnTime = 2.0f;

    CharacterManager charManager;

    public float respawnSafeDistance = 5.0f;

    public GameObject playerEliminatedMessagePrefab;

    public TeamManager teamManager;

    // Start is called before the first frame update
    void Start()
    {
        charManager = FindObjectOfType<CharacterManager>();
        teamManager = FindObjectOfType<TeamManager>();
    }

    public int CheckRemainingPlayers()
    {
        int totalRemaining = 0;
        foreach (CharacterInfo character in charManager.characters)
        {
            if (character.info.isUsed)
            {
                if (character.info.isActive)
                {
                    totalRemaining++;
                }
            }
        }
        return totalRemaining;
    }
    public int CheckRemainingTeams()
    {
        List<TeamInfo> teamsRemaining = new List<TeamInfo>();

        int remainingTeams;
        foreach(CharacterInfo character in charManager.characters)
        {
            if (character.info.isUsed)
            {
                if (character.info.isActive)
                {
                    if (!teamsRemaining.Contains(teamManager.teamManager.teams[character.info.teamID]))
                    {
                        teamsRemaining.Add(teamManager.teamManager.teams[character.info.teamID]);
                    }
                }
            }
        }
        remainingTeams = teamsRemaining.Count;
        return remainingTeams;
    }
    public int CheckRemainingUserPlayers()
    {
        //This function used to check how many actual players remain
        int remainingPlayers = 0;
        foreach (CharacterInfo character in charManager.characters)
        {
            if (character.info.isActive)
            {
                if (!character.info.isNPC)
                {
                    remainingPlayers++;
                }
            }
        }
        return remainingPlayers;
    }
    public int CheckRemainingNpcPlayers()
    {
        //This function used to check how many NPC players remain
        int remainingPlayers = 0;
        foreach (CharacterInfo character in charManager.characters)
        {
            if (character.info.isUsed)
            {
                if (character.info.isActive)
                {
                    if (character.info.isNPC)
                    {
                        remainingPlayers++;
                    }
                }
            }
        }
        return remainingPlayers;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStockLives()
    {
        
        foreach (CharacterInfo c in charManager.characters)
        {
            c.info.lives = lives;
        }
    }
    public void RespawnCharacter(GameObject character)
    {
        if (character.GetComponent<PlayerController>())
        {
            character.GetComponent<PlayerController>().StopKnockBack();
        }
        bool willRespawn = true;
        if (isStock)
        {
            //if playing a Stock game mode
            if (character.GetComponent<CharacterInfo>().info.lives > 1)
            {
                //if player has lives remaining keep allowing respawn and minus life.
                character.GetComponent<CharacterInfo>().info.lives--;

            } else
            {
                //if no more lives, prevent respawn
                willRespawn = false;
                character.GetComponent<CharacterInfo>().info.isActive = false;

                GameObject deathMessage = Instantiate(playerEliminatedMessagePrefab);
                deathMessage.GetComponent<CharacterDeathMessage>().SetDeathMessage(character.GetComponent<CharacterInfo>().info.characterName);
                if (character.GetComponent<PlayerController>())
                {
                    Player playerController = character.GetComponent<PlayerController>().playerController;
                    playerController.PlayerSpectate();
                }
            }
        }
        if (willRespawn)
        {

            if (character.GetComponent<PlayerController>())
            {
                Player playerController = character.GetComponent<PlayerController>().playerController;
                playerController.RespawnPlayer();
            }
            else
            {
                //If it's not a player, it will perform old respawn at specific location
                bool validSpawn = false;
                if (respawnLocations.Length > 0)
                {

                    int location = Random.Range(0, respawnLocations.Length);

                    validSpawn = respawnLocations[location].GetComponent<RespawnPointChecker>().safeSpawn;

                    if (!validSpawn)
                    {
                        //Debug.Log(respawnLocations[location].name + " is not a safe respawn point");
                        RespawnCharacter(character);

                    }
                    else
                    {
                        if (respawnLocations[location].GetComponent<RespawnPointChecker>().usedSpawn == false)
                        {
                            //if respawn location has not spawned anything recently
                            if (character.GetComponent<NavMeshAgent>() != null)
                            {
                                // if the respawning character is an AI
                                character.GetComponent<NavMeshAgent>().Warp(respawnLocations[location].position);
                            }
                            else
                            {

                                character.transform.position = respawnLocations[location].position;
                            }
                            respawnLocations[location].GetComponent<RespawnPointChecker>().usedSpawn = true;
                            StartCoroutine(respawnWait(character));

                        }
                        else
                        {
                            //Debug.Log(respawnLocations[location].name + " was recently used");
                            RespawnCharacter(character);
                        }

                    }



                }
            }
        } else
        {
            
            character.SetActive(false);
            //Debug.Log(character.GetComponent<CharacterInfo>().info.characterName + " has been eliminated.");
        }
    }

    IEnumerator respawnWait(GameObject character)
    {
        yield return new WaitForSeconds(respawnTime);
        character.SetActive(true);
    }
}
