using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutOfBoundsChecker : MonoBehaviour
{

    public bool isOutOfBounds;

    public float timerLimit = 10.0f;
    public float timerCounter;

    private bool triggeredOutOfBounds;

    public UnityEvent OutOfBounds;

    private void Update()
    {
        if (isOutOfBounds)
        {
            if (timerCounter < timerLimit)
            {
                timerCounter += Time.deltaTime;
            } else
            {
                if (!triggeredOutOfBounds)
                {
                    Debug.Log(this.gameObject.name + " has been eliminated by Out of Bounds");
                    OutOfBounds.Invoke();
                }
            }
        } else
        {
            if (timerCounter != 0)
            {
                timerCounter = 0;
            }
        }
    }
}
