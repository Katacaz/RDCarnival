using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerups : MonoBehaviour
{
    public bool usedByEnemy = false;

    [Header("Dual Cannon")]
    public bool dualCannonActive;
    public float dualCannonTimer;
    private float dualCannonCounter;
    public Cannon cannon;
    public GameObject dualCannonMarker;
    public Image dualCannonImage;

    [Header("Cannon Fire Rate Upgrade")]
    public bool fireRateUpActive;
    public float fireRateUpFactor;
    public float fireRateUpTimer;
    private float fireRateUpCounter;
    private float baseFireRate;
    public GameObject fireRateUpMarker;
    public Image fireRateUpImage;

    [Header("Boost")]
    public bool boostActive;
    public float boostMultiplier;
    public float boostTimer;
    private float boostCounter;
    public PlayerMovement playerMovement;
    public EnemyMovement enemyMovement;

    [Header("Shield")]
    public bool shieldActive;
    public float shieldHealth;
    public float shieldTimer;
    private float shieldCounter;

    // Start is called before the first frame update
    void Start()
    {
        baseFireRate = cannon.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (dualCannonActive)
        {
            if (dualCannonCounter > 0)
            {
                dualCannonCounter -= Time.deltaTime;
            } else
            {
                StopDualCannon();
            }
            if (dualCannonImage != null)
            {
                dualCannonImage.fillAmount = (dualCannonCounter / dualCannonTimer);
            }
        }

        if (fireRateUpActive)
        {
            if (fireRateUpCounter > 0)
            {
                fireRateUpCounter -= Time.deltaTime;
            } else
            {
                StopFireRateUp();
            }
            if (fireRateUpImage != null)
            {
                fireRateUpImage.fillAmount = (fireRateUpCounter / fireRateUpTimer);
            }
        }
    }

    public void StartDualCannon()
    {
        dualCannonCounter = dualCannonTimer;
        dualCannonActive = true;
        cannon.dualCannons = true;
        dualCannonMarker.SetActive(true);
    }
    public void StopDualCannon()
    {
        dualCannonMarker.SetActive(false);
        dualCannonActive = false;
        dualCannonCounter = 0;
        cannon.dualCannons = false;
    }

    public void StartFireRateUp()
    {
        fireRateUpMarker.SetActive(true);
        fireRateUpCounter = fireRateUpTimer;
        fireRateUpActive = true;
        cannon.fireRate = cannon.fireRate / fireRateUpFactor;
    }
    public void StopFireRateUp()
    {
        fireRateUpMarker.SetActive(false);
        fireRateUpActive = false;
        fireRateUpCounter = 0;
        cannon.fireRate = baseFireRate;
    }
}
