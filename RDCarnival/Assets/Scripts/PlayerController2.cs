using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    private Rigidbody rB;

    public float jumpForce = 5.0f;

    private CharacterController controller;

    Vector3 moveDirection;

    public float fallScale = 1.0f;

    public bool jumpCharging;
    public float jumpChargeAmount;
    public float jumpChargeScale = 1f;
    public float jumpChargeMin;
    public float jumpChargeMax;
    //float flattenScale = 0.5f;

    GameManager gameManager;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;
    public bool isKnockBack;


    public float maxSpeed = 20f;
    public float timeZeroToMax = 2.5f;
    private float accelRatePerSec;
    public float forwardVelocity;
    public float horizontalVelocity;
    public float maxHorizontalSpeed = 5f;
    public float maxReverseSpeed = 5f;
    public KeyCode forwardKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode backKey;

    public bool isGrounded;
    public GameObject groundCheck;
    float distanceToGround = 0.1f;

    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        accelRatePerSec = maxSpeed / timeZeroToMax;
        forwardVelocity = 0f;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        controller = GetComponent<CharacterController>();
        rB = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void LateUpdate()
    {

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        if (knockBackCounter <= 0)
        {
            isKnockBack = false;
            if (Input.GetKey(forwardKey) || Input.GetKey(backKey))
            {
                if (Input.GetKey(forwardKey))
                {
                    forwardVelocity += accelRatePerSec * Time.deltaTime;
                    forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);
                }
                if (Input.GetKey(backKey))
                {
                    forwardVelocity -= accelRatePerSec * Time.deltaTime / 2f;
                    forwardVelocity = Mathf.Min(forwardVelocity, maxReverseSpeed);
                }
            }
            else
            {
                if (forwardVelocity > 0)
                {
                    forwardVelocity -= accelRatePerSec * Time.deltaTime * 2f;
                    forwardVelocity = Mathf.Max(forwardVelocity, 0f);
                }
                if (forwardVelocity < 0)
                {
                    forwardVelocity += accelRatePerSec * Time.deltaTime * 2f;
                    forwardVelocity = Mathf.Min(forwardVelocity, 0f);
                }
            }


            if (Input.GetKey(leftKey) || Input.GetKey(rightKey))
            {
                if (Input.GetKey(leftKey))
                {
                    horizontalVelocity -= accelRatePerSec * Time.deltaTime / 2f;
                    horizontalVelocity = Mathf.Min(horizontalVelocity, -maxHorizontalSpeed);
                }
                if (Input.GetKey(rightKey))
                {
                    horizontalVelocity += accelRatePerSec * Time.deltaTime / 2f;
                    horizontalVelocity = Mathf.Max(horizontalVelocity, maxHorizontalSpeed);
                }

            }
            else
            {
                if (horizontalVelocity > 0)
                {
                    horizontalVelocity -= accelRatePerSec * Time.deltaTime * 2f;
                    horizontalVelocity = Mathf.Max(horizontalVelocity, 0f);
                }
                if (horizontalVelocity < 0)
                {
                    horizontalVelocity += accelRatePerSec * Time.deltaTime * 2f;
                    horizontalVelocity = Mathf.Min(horizontalVelocity, 0f);
                }
            }
            rB.velocity = ((transform.forward * forwardVelocity) + (transform.right * horizontalVelocity));
            if (!isGrounded)
            {
                rB.velocity -= (Vector3.up * fallScale);
            }
            rB.angularVelocity = Vector3.zero;
        } else
        {
            knockBackCounter -= Time.deltaTime;
            isKnockBack = true;
        }

        //Debug.Log("The Player Rigidbody Velocity is: " + rB.velocity);
    }

    public void KnockBack()
    {
        Debug.Log("Player 1 Knocked Back");
        KnockBackObject knockBack = GetComponent<KnockBackObject>();

        knockBackCounter = knockBackTime;
        forwardVelocity = 0f;
        horizontalVelocity = 0f;
        rB.AddForce((-(knockBack.knockBackDirection * knockBack.knockbackAmount)) + (Vector3.up * knockBack.knockbackAmount * 0.2f), ForceMode.VelocityChange);

    }

}
