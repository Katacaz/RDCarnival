using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChangeTest : MonoBehaviour
{
    public Material[] skyboxes;
    public int currentSkybox;
    public float t;
    Skybox camSkybox;
    // Start is called before the first frame update
    void Start()
    {
        camSkybox = GetComponent<Skybox>();
    }

    public void ChangeSkybox(Material sB)
    {
        camSkybox.material = sB;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentSkybox < (skyboxes.Length - 1))
            {
                currentSkybox++;
            } else
            {
                currentSkybox = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentSkybox > 0)
            {
                currentSkybox--;
            } else
            {
                currentSkybox = skyboxes.Length;
            }
        }

        if (skyboxes[currentSkybox] != null)
        {
            ChangeSkybox(skyboxes[currentSkybox]);
        }
    }
}
