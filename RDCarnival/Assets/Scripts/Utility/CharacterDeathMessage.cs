using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterDeathMessage : MonoBehaviour
{
    public TextMeshProUGUI deathMessageText;
    public TextMeshProUGUI remainingPlayersText;

    private RespawnManager respawnManager;

    private void Awake()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
        Destroy(this.gameObject, 2f);
    }

    public void SetDeathMessage(string playerName)
    {
        deathMessageText.text = playerName + " has been Eliminated!";
        remainingPlayersText.text = respawnManager.CheckRemainingPlayers().ToString() + " players remain.";
    }
}
