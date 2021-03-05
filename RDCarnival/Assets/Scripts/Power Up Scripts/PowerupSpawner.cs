using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] powerups;
    public bool canSpawn;

    public Transform spawnPoint;
    public GameObject spawnedObject;
    public bool objectSpawned;

    public float spawnTimer = 5f;
    private float spawnCounter;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCollected();
        if (canSpawn)
        {
            if (spawnCounter >= spawnTimer)
            {
                if (!objectSpawned)
                {
                    SpawnPowerup();
                }
            } else
            {
                spawnCounter += Time.deltaTime;
            }
        }
    }

    public void CheckIfCollected()
    {
        if (objectSpawned)
        {
            if (spawnedObject == null)
            {
                spawnCounter = 0;
                objectSpawned = false;
                
            }
        }
    }
    public GameObject RandomPowerup()
    {
        int obj = Random.Range(0, powerups.Length);
        return powerups[obj];
    }
    public void SpawnPowerup()
    {
        this.spawnedObject = Instantiate(RandomPowerup(), spawnPoint);
        objectSpawned = true;
    }
}
