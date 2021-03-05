using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtPlayer : MonoBehaviour
{

    public GameObject target;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
