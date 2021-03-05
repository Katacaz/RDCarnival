using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{

    public float spinSpeedX;
    public float spinSpeedY;
    public float spinSpeedZ;

    public bool scaleSpin;
    public float spinScaleX;
    public float spinScaleY;
    public float spinScaleZ;

    // Update is called once per frame
    void Update()
    {
        //Rotate the object at a speed of what is designated in editor
        transform.Rotate(spinSpeedX * Time.deltaTime, spinSpeedY * Time.deltaTime, spinSpeedZ * Time.deltaTime);
        if (scaleSpin)
        { 
            spinSpeedX += (spinScaleX * Time.deltaTime);
            spinSpeedY += (spinScaleY * Time.deltaTime);  
            spinSpeedZ += (spinScaleZ * Time.deltaTime);
        }
    }
}
