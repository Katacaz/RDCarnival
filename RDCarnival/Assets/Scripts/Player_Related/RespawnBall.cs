using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    public GameObject playerToMove;

    public float moveSpeed = 15f;

    public Player playerController;

    public GameObject respawnEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * Time.deltaTime * moveSpeed);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        RespawnSafeArea spawnArea = other.GetComponent<RespawnSafeArea>();
        if (spawnArea != null)
        {
            RespawnPlayer();
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        RespawnSafeArea spawnArea = other.GetComponent<RespawnSafeArea>();
        if (spawnArea != null)
        {
            RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        if (respawnEffect != null)
        {
            GameObject effect = Instantiate(respawnEffect);
            effect.transform.position = this.transform.position;
            Destroy(effect, 3.0f);
        }
        playerToMove.transform.position = this.transform.position;
        playerToMove.transform.rotation = Quaternion.Euler(playerToMove.transform.eulerAngles.x, this.transform.eulerAngles.y, playerToMove.transform.eulerAngles.z);
        playerToMove.SetActive(true);
        if (playerController != null)
        {
            playerController.isRespawnBall = false;
        }
        Destroy(this.gameObject);
    }
}
