using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cannon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [Range(0.5f, 1.5f)]
    public float fireRate = 1f;
    [Range(1, 10)]
    public int damage = 1;
    private float timer;
    public bool dualCannons;

    [Header("Cannon Ball Fire Locations")]
    public Transform cannonFirePointRight;
    public Transform cannonFirePointLeft;

    [Header("Prefabs")]
    public GameObject cannonballPrefab;
    public GameObject cannonFireEffect;

    [Header("Cannon Models")]
    public GameObject rightCannon;
    public GameObject leftCannon;

    [Header("Audio")]
    public AudioClip shootSND;
    public AudioSource audioSource;

    [Header("Targeting")]
    public Sprite noTarget;
    public Sprite targetSeen;
    public Image targetingIcon;
    public LayerMask raycastLayers;
    public TextMeshProUGUI healthNumberText;

    [Header("Aiming")]
    public GameObject mainCamera;
    public GameObject aimCamera;
    public bool isAiming;
    public Camera playerCamera;
    public float aimDistance = 50;

    [Header("Extra: Quack & Squeak")]
    public AudioClip quackSND;
    public AudioClip squeakSND;
    public float randomPitchMin;
    public float randomPitchMax;

    CharacterInfo info;

    bool fireButtonHeld;
    private void Awake()
    {
        info = GetComponent<CharacterInfo>();
    }

    void Update()
    {
        AimCannons();
        CheckForTarget();
        SetCannonAppearance();
        timer += Time.deltaTime;


        if (timer >= fireRate)
        {
            if (fireButtonHeld)
            {
                timer = 0f;
                FireCannon();
            }
        }

        if (isAiming)
        {
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);
        } else
        {
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
        }
    }

    public void AimCannons()
    {
        Vector3 aimSpot = playerCamera.transform.position;
        aimSpot += playerCamera.transform.forward * aimDistance;
        leftCannon.transform.LookAt(aimSpot);
        rightCannon.transform.LookAt(aimSpot);
    }
    void SetCannonAppearance()
    {
        if (dualCannons)
        {
            leftCannon.SetActive(true);
        } else
        {
            leftCannon.SetActive(false);
        }
    }
    void CheckForTarget()
    {
        Ray ray = new Ray(cannonFirePointRight.position, cannonFirePointRight.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 200, raycastLayers))
        {
            //Debug.Log("Raycast hit: " + hitInfo.collider.name);
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                
                targetingIcon.sprite = targetSeen;
                healthNumberText.text = health.currentHealth.ToString();
            }
            else
            {
                targetingIcon.sprite = noTarget;
                healthNumberText.text = "";
            }
        }
        else
        {
            targetingIcon.sprite = noTarget;
            healthNumberText.text = "";
        }
    }
    private void FireCannon()
    {

        GameObject effect = Instantiate(cannonFireEffect);
        effect.transform.position = cannonFirePointRight.position;
        Destroy(effect, 3f);
        //Debug.Log("Shot Cannon");
        Debug.DrawRay(cannonFirePointRight.position, cannonFirePointRight.forward * 100, Color.red, 2f);
        GameObject cannonball = Instantiate(cannonballPrefab);
        Physics.IgnoreCollision(cannonball.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
        cannonball.transform.position = cannonFirePointRight.position;
        cannonball.transform.rotation = cannonFirePointRight.rotation;
        cannonball.GetComponent<CannonBall>().damage = damage;
        cannonball.GetComponent<CannonBall>().characterName = info.info.characterName;
        cannonball.GetComponent<CannonBall>().characterTeamID = info.info.teamID;
        cannonball.GetComponent<CannonBall>().moveSpeed += GetComponent<PlayerController>().moveSpeed;
        audioSource.PlayOneShot(shootSND);

        if (dualCannons)
        {
            GameObject effect2 = Instantiate(cannonFireEffect);
            effect2.transform.position = cannonFirePointLeft.position;
            Destroy(effect2, 3f);
            //Debug.Log("Shot Cannon");
            Debug.DrawRay(cannonFirePointLeft.position, cannonFirePointLeft.forward * 100, Color.red, 2f);
            GameObject cannonball2 = Instantiate(cannonballPrefab);
            Physics.IgnoreCollision(cannonball2.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
            Physics.IgnoreCollision(cannonball2.GetComponent<Collider>(), cannonball.GetComponent<Collider>(), true);
            cannonball2.transform.position = cannonFirePointLeft.position;
            cannonball2.transform.rotation = cannonFirePointLeft.rotation;
            cannonball2.GetComponent<CannonBall>().damage = damage;
            cannonball2.GetComponent<CannonBall>().characterName = info.info.characterName;
            cannonball2.GetComponent<CannonBall>().characterTeamID = info.info.teamID;
            cannonball2.GetComponent<CannonBall>().moveSpeed += GetComponent<PlayerController>().moveSpeed;
            audioSource.PlayOneShot(shootSND);
        }
        //Ray ray = new Ray(cannonFirePointRight.position, cannonFirePointRight.forward);
        //RaycastHit hitInfo;

        /*if (Physics.Raycast(ray, out hitInfo, 100))
        {
            Debug.Log("Raycast hit: " + hitInfo.collider.name);
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }*/
    }

    public void OnFire()
    {
        fireButtonHeld = true;
        /*if (timer >= fireRate)
        {
            timer = 0f;
            FireCannon();
        }*/
    }
    public void OnStopFire()
    {
        fireButtonHeld = false;
    }
    public void OnAim()
    {
        
        isAiming = true;
    }
    public void OnStopAim()
    {
        isAiming = false;
    }
    public void OnQuack()
    {
        PlaySoundWithRandomPitch(quackSND);
    }
    public void OnSqueak()
    {
        PlaySoundWithRandomPitch(squeakSND);
    }
    public void PlaySoundWithRandomPitch(AudioClip clip)
    {
        float basePitch = audioSource.pitch;
        float randomPitch = UnityEngine.Random.Range(randomPitchMin, randomPitchMax);
        audioSource.pitch = randomPitch;
        audioSource.PlayOneShot(clip);
        audioSource.pitch = basePitch;
    }

    public void OnDeath()
    {
        isAiming = false;
        fireButtonHeld = false;
    }
    /*private void OnEnable()
    {
        isAiming = false;
        fireButtonHeld = false;
    }*/
}
