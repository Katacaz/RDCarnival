using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsRegion : MonoBehaviour
{
    public GameManager gameManager;

    public bool outOfBoundsArea;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            gameManager.Player1LeftArea();
        }
        if (other.GetComponent<Player2Controller>())
        {
            gameManager.Player2LeftArea();
        }
        if (other.GetComponent<KnockBackObject>())
        {

            if (!other.GetComponent<KnockBackObject>().isPlayer)
            {
                Destroy(other.gameObject);
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        OutOfBoundsChecker checker = other.GetComponent<OutOfBoundsChecker>();
        if (checker != null)
        {
            if (outOfBoundsArea)
            {
                checker.isOutOfBounds = true;
            } else
            {
                checker.isOutOfBounds = false;
            }
        }
        /*if (other.GetComponent<PlayerController>())
        {
            gameManager.Player1LeftArea();
        }
        if (other.GetComponent<Player2Controller>())
        {
            gameManager.Player2LeftArea();
        }
        if (other.GetComponent<KnockBackObject>())
        {

            if (!other.GetComponent<KnockBackObject>().isPlayer)
            {
                Destroy(other.gameObject);
            }
        }*/
    }
}
