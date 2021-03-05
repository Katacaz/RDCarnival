using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class RespawnCannon : MonoBehaviour
{

    public GameObject characterBallPrefab;

    float h, v;
    float lookH, lookV;

    public GameObject horizontalRotator;
    public GameObject verticalRotator;
    public float rotatePower = 5f;


    public float shootSpeed = 10f;
    public Transform firePoint;
    public GameObject linePreviewObject;

    public float linePreviewInterval = 0.1f;
    private float linePreviewCounter;

    public bool canShoot;
    public bool newShot;

    public LayerMask layersToIgnore;

    public Player playerController;

    public GameObject shootEffect;

    public bool startForceFireTimer;
    public float forceFireTimer = 10f;
    private float forceFireCounter;

    public GameObject forceFireTimerUI;
    public Image forceFireTimerBar;
    public TextMeshProUGUI timerText;

    public bool playerAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startForceFireTimer)
        {
            if (forceFireTimerUI != null)
            {
                forceFireTimerUI.SetActive(true);
            }

            if (forceFireCounter >= forceFireTimer)
            {
                forceFireCounter = 0;
                startForceFireTimer = false;
                if (!canShoot)
                {
                    verticalRotator.transform.rotation = Quaternion.Euler(90, 0, 0);
                }
                ForceFireCannon();
            }
            else
            {
                forceFireCounter += Time.deltaTime;
            }

            if (forceFireTimerBar != null)
            {
                forceFireTimerBar.fillAmount = (forceFireCounter / forceFireTimer);
            }
            if (timerText != null)
            {
                timerText.text = (Mathf.RoundToInt(forceFireTimer) - Mathf.RoundToInt(forceFireCounter)).ToString();
            }
        }
        if (playerAlive)
        {
            firePoint.gameObject.SetActive(true);
            if (linePreviewCounter >= linePreviewInterval)
            {
                linePreviewCounter = 0;
                CreatePreviewLine();
            }
            else
            {
                linePreviewCounter += Time.deltaTime;
            }
        } else
        {
            firePoint.gameObject.SetActive(false);
        }
        
        horizontalRotator.transform.rotation *= Quaternion.AngleAxis(lookH * rotatePower, Vector3.up);
        verticalRotator.transform.rotation *= Quaternion.AngleAxis(lookV * rotatePower, Vector3.right);

        var vAngles = verticalRotator.transform.localEulerAngles;
        vAngles.z = 0;
        var angle = verticalRotator.transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
        {
            vAngles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            vAngles.x = 40;
        }
        verticalRotator.transform.localEulerAngles = new Vector3(vAngles.x, 0, 0);
        


    }

    public void ForceFireCannon()
    {
        
        lookH = 0;
        lookV = 0;
        newShot = false;
        if (shootEffect != null)
        {
            GameObject effect = Instantiate(shootEffect);
            effect.transform.position = firePoint.transform.position;
            Destroy(effect, 3.0f);
        }
        canShoot = false;
        Debug.Log("Fired Respawn Cannon");
        GameObject respawnBall = Instantiate(characterBallPrefab);
        respawnBall.transform.position = firePoint.transform.position;
        respawnBall.transform.rotation = firePoint.transform.rotation;
        respawnBall.GetComponent<RespawnBall>().playerToMove = playerController.playerReference;
        respawnBall.GetComponent<RespawnBall>().playerController = playerController;
        playerController.respawnBallCamController.Follow = respawnBall.transform;
        playerController.isRespawnBall = true;
        playerController.isRespawning = false;
    }
    public void CreatePreviewLine()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        //firePoint.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, 100));
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 200, ~layersToIgnore))
        {
            
            if (hitInfo.collider)
            {
                if (hitInfo.collider.GetComponent<RespawnSafeArea>())
                {
                    firePoint.GetComponent<LineRenderer>().startColor = Color.green;
                    firePoint.GetComponent<LineRenderer>().endColor = Color.green;
                    canShoot = true;
                }
                else
                {
                    firePoint.GetComponent<LineRenderer>().startColor = Color.red;
                    firePoint.GetComponent<LineRenderer>().endColor = Color.red;
                    canShoot = false;
                }
                float distanceToPoint = Vector3.Distance(firePoint.position, hitInfo.point);
                firePoint.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0,0, distanceToPoint));
            } else
            {
                //If there is no collider
                firePoint.GetComponent<LineRenderer>().startColor = Color.red;
                firePoint.GetComponent<LineRenderer>().endColor = Color.red;
                canShoot = false;
                firePoint.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0,0,100));
            }
            
        }
        else
        {
            //If there is no collision
            firePoint.GetComponent<LineRenderer>().startColor = Color.red;
            firePoint.GetComponent<LineRenderer>().endColor = Color.red;
            canShoot = false;
            firePoint.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, 100));
        }
        /*GameObject previewLine = Instantiate(linePreviewObject);
        Destroy(previewLine, 10f);
        previewLine.transform.position = firePoint.transform.position;
        previewLine.transform.rotation = firePoint.transform.rotation;
        previewLine.transform.SetParent(firePoint);
        
        previewLine.GetComponent<PreviewLineObject>().launch(shootSpeed);
        */
    }
    public void OnRotate(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        lookH = input.x;
        lookV = input.y;
    }
    public void StartForceTimer()
    {
        forceFireCounter = 0;
        startForceFireTimer = true;
    }
    public void OnShoot()
    {
        if (playerAlive)
        {
            if (canShoot)
            {
                if (newShot)
                {
                    startForceFireTimer = false;
                    lookH = 0;
                    lookV = 0;
                    newShot = false;
                    if (shootEffect != null)
                    {
                        GameObject effect = Instantiate(shootEffect);
                        effect.transform.position = firePoint.transform.position;
                        Destroy(effect, 3.0f);
                    }
                    canShoot = false;
                    Debug.Log("Fired Respawn Cannon");
                    GameObject respawnBall = Instantiate(characterBallPrefab);
                    respawnBall.transform.position = firePoint.transform.position;
                    respawnBall.transform.rotation = firePoint.transform.rotation;
                    respawnBall.GetComponent<RespawnBall>().playerToMove = playerController.playerReference;
                    respawnBall.GetComponent<RespawnBall>().playerController = playerController;
                    playerController.respawnBallCamController.Follow = respawnBall.transform;
                    playerController.isRespawnBall = true;
                    playerController.isRespawning = false;
                }

            }
        }
    }
}
