using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualCannonPickUpObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerPowerups>() != null)
        {
            other.GetComponent<PlayerPowerups>().StartDualCannon();
            Destroy(this.gameObject);
        }
    }
}
