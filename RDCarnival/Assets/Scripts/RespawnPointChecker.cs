using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointChecker : MonoBehaviour
{
    public bool safeSpawn = true;

    public bool usedSpawn;
    public float spawnCooldown = 2.0f;
    private float spawnCounter;

    public float safeCheckCooldown = 1.0f;
    private float safeCheckCounter;

    CharacterManager charManager;

    public float safeSpawnDistance = 5;
    // Start is called before the first frame update
    void Start()
    {
        charManager = FindObjectOfType<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCounter > 0)
        {
            spawnCounter -= Time.deltaTime;
        } else
        {
            if (usedSpawn)
            {
                usedSpawn = false;
            }
        }
        if (safeCheckCounter > 0)
        {
            safeCheckCounter -= Time.deltaTime;
        } else
        {
            safeCheckCounter = safeCheckCooldown;
            safeSpawn = !characterInRange();
        }
    }

    public bool characterInRange()
    {
        bool charInRange = false;
        float distanceToPlayer;
        foreach (CharacterInfo c in charManager.characters)
        {
            distanceToPlayer = Vector3.Distance(c.gameObject.transform.position, this.transform.position);
            if (distanceToPlayer < safeSpawnDistance)
            {
                //if character is too close
                charInRange = true;
                return charInRange;
            }
        }


        return charInRange;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterInfo>() != null)
        {
            safeSpawn = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterInfo>() != null)
        {
            safeSpawn = true;
        }
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, safeSpawnDistance);
    }
}
