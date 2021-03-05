using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public KeyCode keyToSpawn;

    public GameObject objectToSpawn;

    public float objectMinSpeed = 1f;
    public float objectMaxSpeed = 10f;

    public float objectDestroyTime = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToSpawn))
        {
            GameObject obj = Instantiate(objectToSpawn);
            if (obj.GetComponent<MoveAtPlayer>())
            {
                obj.GetComponent<MoveAtPlayer>().moveSpeed = Random.Range(objectMinSpeed, objectMaxSpeed);
            }
            Destroy(obj, objectDestroyTime);
        }
    }
}
