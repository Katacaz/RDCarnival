using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackObject : MonoBehaviour
{
    Rigidbody body;

    public float knockbackMultiplier = 2f;

    public bool thisScriptResponsibleForKnockback = true;

    public Vector3 knockBackDirection;
    public float knockbackAmount;

    public bool isPlayer;

    public bool isBeingKnockedBack;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        KnockBackObject kbo = collision.collider.GetComponent<KnockBackObject>();
        if (kbo != null)
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Debug.Log("Collision with object with Rigidbody");
                if ((rb.velocity.magnitude > this.body.velocity.magnitude))
                {
                    //If other object is faster
                    knockBackDirection = (rb.transform.position - transform.position).normalized;
                    knockbackAmount = rb.velocity.magnitude * knockbackMultiplier;
                    isBeingKnockedBack = true;
                    rb.velocity = rb.velocity / 2f;

                } else
                {
                    //if this object is faster
                    isBeingKnockedBack = false;
                }
                if (isBeingKnockedBack)
                {
                    if (thisScriptResponsibleForKnockback)
                    {
                        Debug.Log(this.transform.name + " knocked Back");
                        KnockBackThis(knockBackDirection, knockbackAmount);
                    }
                    else
                    {
                        SendMessage("KnockBack");
                    }
                }
            }
        }
    }

    public void KnockBackThis(Vector3 direction, float amount)
    {
        Debug.Log("Object Knocked Back by: " + amount);
        body.AddForce((-direction * amount) + (Vector3.up * amount * 0.1f), ForceMode.Impulse);
        
    }
}
