using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggroDetection : MonoBehaviour
{
    GameStateCheck gameState;
    private void Awake()
    {
        gameState = FindObjectOfType<GameStateCheck>();
    }
    public event Action<CharacterInfo> OnAgrro = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if (!gameState.gamePaused)
        {
            var player = other.GetComponent<CharacterInfo>();

            if (player)
            {
                OnAgrro(player);
                //Debug.Log("Player in Range");

            }
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        var player = other.CompareTag("Player");
        if (player)
        {
            int randomChar = UnityEngine.Random.Range(0, FindObjectOfType<CharacterManager>().characters.Length);
            CharacterInfo newTarget = FindObjectOfType<CharacterManager>().characters[randomChar];
            OnAgrro(newTarget);
        }
    }*/
}
