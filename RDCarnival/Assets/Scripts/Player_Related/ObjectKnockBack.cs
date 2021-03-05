using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKnockBack : MonoBehaviour
{
    public float knockbackAmount;

    public float knockBackTime = 1f;
    private float knockBackCounter;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (knockbackAmount > 0)
        {
            knockBackCounter -= Time.deltaTime;
        }
    }

    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        //direction = new Vector3(1f, 1f, 1f);
        //Debug.Log("Object Knocked Back");
        //rb.AddForce(direction * knockbackAmount + transform.up * 0.5f, ForceMode.Impulse);
    }
}
