using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public CharacterInfo[] characters;

    public string[] characterNames;

    private void Awake()
    {
        characters = FindObjectsOfType<CharacterInfo>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacterNames();
    }
    public void UpdateCharacterNames()
    {
        characterNames = new string[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            characterNames[i] = characters[i].info.characterName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
