using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNameManager : MonoBehaviour
{
    public bool useRandomNCPNames = true;
    CharacterManager charManager;
    [Range(0, 100)]
    public float probabilityOfNoTitle;
    public string[] titles;
    public string[] firstNames;
    [Range(0, 100)]
    public float probabilityOfNoSurname;
    public string[] lastNames;

    

    public List<string> names;

    void Awake()
    {
        charManager = FindObjectOfType<CharacterManager>();

    }
    private void Start()
    {
        if (useRandomNCPNames)
        {
            GenerateNewNameList(charManager.characters.Length);
            SetNCPNames();
        }
    }

    public void SetNCPNames()
    {
        int characterNumber = 0;
        foreach(CharacterInfo c in charManager.characters)
        {
            
            if (c.info.isNPC)
            {
                //Debug.Log(c.info.characterName + " has been set to: " + names[characterNumber]);
                c.info.characterName = names[characterNumber];
                characterNumber++;
            }
        }
        charManager.UpdateCharacterNames();
    }

    public void GenerateNewNameList(int amount)
    {
        ClearNameList();
        for (int i = 0; i < amount; i++)
        {
            names.Add(GetRandomName());
        }
    }

    public string GetRandomName()
    {
        string name = "";
        //Check probability to use a title
        float rng = Random.Range(0, 100);
        string title = "";
        if (rng >= probabilityOfNoTitle)
        {
            title = titles[Random.Range(0, titles.Length)];
            if (title != null)
            {
                name += (title + " ");
            }
        } 
        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        if (firstName != null)
        {
            name += firstName;
        }
        rng = Random.Range(0, 100);
        string lastname = "";
        if (rng >= probabilityOfNoSurname)
        {
            lastname = lastNames[Random.Range(0, lastNames.Length)];
            if (lastname != null)
            {
                name += (" " + lastname);
            }
        }

        int loopLimit = 10;
        for (int i = 0; i < loopLimit; i++)
        {
            if (names.Contains(name))
            {
                Debug.Log(name + " already used");
                //If name already generated try generate a new one
                if (rng >= probabilityOfNoTitle)
                {
                    title = titles[Random.Range(0, titles.Length)];
                    if (title != null)
                    {
                        name += (title + " ");
                    }
                }
                firstName = firstNames[Random.Range(0, firstNames.Length)];
                if (firstName != null)
                {
                    name += firstName;
                }
                rng = Random.Range(0, 100);
                if (rng >= probabilityOfNoSurname)
                {
                    lastname = lastNames[Random.Range(0, lastNames.Length)];
                    if (lastname != null)
                    {
                        name += (" " + lastname);
                    }
                }
            } else
            {
                break;
            }
        }
        if (names.Contains(name))
        {
            //If it couldn't generate a unique name
            name += " II";
        }

        return name;
    }

    public void ClearNameList()
    {
        names.Clear();      
    }
}
