using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminationManager : MonoBehaviour
{

    CharacterManager charManager;
    ScoreManager scoreManager;

    public int elimScorePoints = 10;

    private void Awake()
    {
        charManager = GetComponent<CharacterManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RewardElimination(string name)
    {
        foreach (CharacterInfo c in charManager.characters)
        {
            if (c.info.characterName == name)
            {
                
                c.info.eliminations++;
                scoreManager.AddElimScore(name, elimScorePoints);

                //Debug.Log(name + " earned an elimination! Total: " + c.info.eliminations.ToString());
            }
        }
    }
    public void IncreastDeathCounter(string name)
    {
        foreach (CharacterInfo c in charManager.characters)
        {
            if (c.info.characterName == name)
            {

                c.info.deaths++;
            }
        }
    }
}
