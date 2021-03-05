using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnInteractCallButton : MonoBehaviour
{
    public Button onInteractEvent;
    public Button onBackEvent;

    public void OnInteract()
    {
        onInteractEvent.onClick.Invoke();
    }

    public void OnBack()
    {
        onBackEvent.onClick.Invoke();
    }


}
