using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float moveSpeed = 15.0f;

    Rigidbody body;
    public float deathTime = 5.0f;
    float deathCounter = 0f;

    public int damage;

    public GameObject collisionDestroyEffectPrefab;
    public GameObject timeoutDestroyEffectPrefab;

    [Header("Owner Info")]
    public string characterName;
    public int characterTeamID;

    GameModeSettingsManager gameSettings;
    GameStateCheck gameState;
    private void Awake()
    {
        gameState = FindObjectOfType<GameStateCheck>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameSettings = FindObjectOfType<GameModeSettingsManager>();
        //body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameState.gamePaused)
        {
            if (deathCounter < deathTime)
            {
                deathCounter += Time.deltaTime * Time.timeScale;
            }
            else
            {
                if (timeoutDestroyEffectPrefab != null)
                {
                    GameObject effect = Instantiate(timeoutDestroyEffectPrefab);
                    effect.transform.position = this.transform.position;
                    Destroy(effect, 3.0f);
                }
                Destroy(this.gameObject);
            }
            transform.position += (transform.forward * moveSpeed * Time.deltaTime * Time.timeScale);
        }
        //body.MovePosition(transform.forward * moveSpeed * Time.deltaTime);



    }

    public void SetOwnerInfo(string ownerName, int ownerTeamID)
    {
        characterName = ownerName;
        characterTeamID = ownerTeamID;
    }
    private void FixedUpdate()
    {
        
        //body.AddForce(transform.forward * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;

        var health = other.GetComponent<Health>();
        if (health != null)
        {
            if (!gameSettings.roundSettings.friendlyFire)
            {
                //If Friendly fire is OFF
                CharacterInfo charInfo = other.GetComponent<CharacterInfo>();
                if (charInfo != null)
                {
                    //If what is hit is a Character
                    if (charInfo.info.teamID == characterTeamID)
                    {
                        //if friendly fire is off and what is hit is on the same team as the owner - do nothing
                    } else
                    {
                        //if friendly fire is off and what is hit is on a different team - damage them
                        health.TakeDamage(damage, characterName);
                        health.CallKnockBack(other.transform.position - this.transform.position);
                    }
                } else
                {
                    //If what is hit is an object with health (a box) - damage it
                    health.TakeDamage(damage, characterName);
                    health.CallKnockBack(other.transform.position - this.transform.position);
                }
                
            } else
            {
                //If friendly fire is ON - do damage
                health.TakeDamage(damage, characterName);
                health.CallKnockBack(other.transform.position - this.transform.position);
            }
        }
        if (collisionDestroyEffectPrefab != null)
        {
            GameObject effect = Instantiate(collisionDestroyEffectPrefab);
            effect.transform.position = this.transform.position;
            Destroy(effect, 3.0f);
        }
        Destroy(this.gameObject);
    }
}
