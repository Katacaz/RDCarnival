using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CharacterInfo charInfo;
    private AggroDetection aggroDetection;
    private Health healthTarget;
    private float attackTimer;
    public float attackRefreshRate = 2.5f;

    public GameObject cannonBallPrefab;
    public int damageAmount = 1;
    public Transform leftCannonFirePoint;
    public Transform rightCannonFirePoint;

    public bool usingDualCannons;

    public GameObject leftCannon;
    public GameObject rightCannon;

    public GameObject cannonFireEffectPrefab;


    private Animator anim;

    public AudioClip cannonFireSND;
    public AudioSource audioSource;

    GameStateCheck gameState;
    CharacterManager charManager;
    GameModeSettingsManager gameSettings;
    public CharacterInfo currentTarget;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAgrro += AggroDetection_OnAgrro;
        gameState = FindObjectOfType<GameStateCheck>();
        charManager = FindObjectOfType<CharacterManager>();
        charInfo = GetComponent<CharacterInfo>();
        gameSettings = FindObjectOfType<GameModeSettingsManager>();
    }

    private void AggroDetection_OnAgrro(CharacterInfo target)
    {
        if (CheckValidTarget(target))
        {
            currentTarget = target;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FindRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        SetCannonAppearance();
        if (!gameState.gamePaused)
        {
            if (currentTarget != null)
            {
                attackTimer += Time.deltaTime * Time.timeScale;

                if (CanAttack())
                {
                    Attack();
                }
            }
            if (!CheckValidTarget(currentTarget))
            {
                FindRandomTarget();
            }
        }
    }

    public void SetCannonAppearance()
    {
        if (usingDualCannons)
        {
            rightCannon.SetActive(true);
        } else
        {
            rightCannon.SetActive(false);
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack()
    {
        attackTimer = 0f;
        transform.LookAt(currentTarget.transform);
        //Quaternion leftCannonBaseRotation = leftCannon.transform.rotation;
        //leftCannon.transform.LookAt(healthTarget.transform);
        InstantiateAtPosition(cannonFireEffectPrefab, leftCannonFirePoint, 2.0f);
        GameObject leftCannonBall = Instantiate(cannonBallPrefab);
        Physics.IgnoreCollision(leftCannonBall.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
        leftCannonBall.transform.position = leftCannonFirePoint.transform.position;
        leftCannonBall.transform.rotation = leftCannonFirePoint.rotation;
        leftCannonBall.GetComponent<CannonBall>().damage = damageAmount;
        leftCannonBall.GetComponent<CannonBall>().characterName = this.GetComponent<CharacterInfo>().info.characterName;
        leftCannonBall.GetComponent<CannonBall>().characterTeamID = this.GetComponent<CharacterInfo>().info.teamID;
        audioSource.PlayOneShot(cannonFireSND);
        //leftCannon.transform.rotation = leftCannonBaseRotation;
        if (usingDualCannons)
        {
            //Quaternion rightCannonBaseRotation = rightCannon.transform.rotation;
            //rightCannon.transform.LookAt(healthTarget.transform);
            InstantiateAtPosition(cannonFireEffectPrefab, rightCannonFirePoint, 2.0f);
            GameObject rightCannonBall = Instantiate(cannonBallPrefab);
            Physics.IgnoreCollision(rightCannonBall.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
            Physics.IgnoreCollision(rightCannonBall.GetComponent<Collider>(), leftCannonBall.GetComponent<Collider>(), true);
            rightCannonBall.transform.position = rightCannonFirePoint.transform.position;
            rightCannonBall.transform.rotation = rightCannonFirePoint.transform.rotation;
            rightCannonBall.GetComponent<CannonBall>().damage = damageAmount;
            rightCannonBall.GetComponent<CannonBall>().characterName = this.GetComponent<CharacterInfo>().info.characterName;
            rightCannonBall.GetComponent<CannonBall>().characterTeamID = this.GetComponent<CharacterInfo>().info.teamID;
            //rightCannon.transform.rotation = rightCannonBaseRotation;
        }



        anim.SetTrigger("Shoot");
    }

    public void InstantiateAtPosition(GameObject obj, Transform position, float deathTime)
    {
        if (obj != null)
        {
            GameObject o = Instantiate(obj);
            o.transform.position = position.position;
            if (deathTime != 0)
            {
                Destroy(o, deathTime);
            }
        }
    }

    public bool CheckValidTarget(CharacterInfo character)
    {
        bool isValid = true;
        if (gameSettings.roundSettings.useTeams)
        {
            if (character.info.teamID == charInfo.info.teamID)
            {
                //If character is on the same team
                isValid = false;
            }
        }
        if (!character.info.isActive)
        {
            //If character is dead
            isValid = false;
        }
        if (character.info.characterName == charInfo.info.characterName)
        {
            //if targeting self
            isValid = false;
        }
        return isValid;
    }
    public void Hurt(string characterName)
    {
        foreach (CharacterInfo c in charManager.characters)
        {
            if (c.info.characterName == characterName)
            {
                if (CheckValidTarget(c))
                {
                    currentTarget = c;
                }
            }
        }
    }
    public void FindRandomTarget()
    {
        int randTarget = UnityEngine.Random.Range(0, charManager.characters.Length);
        if (CheckValidTarget(charManager.characters[randTarget]))
        {
            currentTarget = charManager.characters[randTarget];
        } else
        {
            FindRandomTarget();
        }
    }
}
