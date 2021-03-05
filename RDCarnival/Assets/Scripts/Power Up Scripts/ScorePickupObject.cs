using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickupObject : MonoBehaviour
{
    public int pickupValue = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterInfo>() != null)
        {
            Debug.Log(other.GetComponent<CharacterInfo>().info.characterName + " has earned " + pickupValue.ToString() + " Points.");
            FindObjectOfType<ScoreManager>().AddScore(other.GetComponent<CharacterInfo>().info.characterName, pickupValue);
            Destroy(this.gameObject);
        }
    }
}
