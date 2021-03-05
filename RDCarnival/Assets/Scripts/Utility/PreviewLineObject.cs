using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewLineObject : MonoBehaviour
{
    //public float speed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(transform.forward * speed * Time.deltaTime);
    }
    public void launch(float speed)
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
