using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
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
    private float distanceToGround = 0.1f;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        accelRatePerSec = maxSpeed / timeZeroToMax;
        forwardVelocity = 0f;
        rB = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        /*if (knockBackCounter <= 0)
        {
            float yStore = moveDirection.y;
            if (controller.isGrounded)
            {
                moveDirection = (transform.forward * Input.GetAxisRaw("P2 Vertical")) + (transform.right * Input.GetAxisRaw("P2 Horizontal"));
                moveDirection = moveDirection.normalized * moveSpeed;
            }
            else
            {
                moveDirection = (transform.forward * Input.GetAxis("P2 Vertical")) + (transform.right * Input.GetAxis("P2 Horizontal"));
                moveDirection = moveDirection.normalized * moveSpeed;
            }
            moveDirection.y = yStore;
            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
                if (Input.GetButton("P2 Jump"))
                {
                    if (!jumpCharging)
                    {
                        jumpChargeAmount = jumpChargeMin;
                    }
                    jumpCharging = true;

                }
                if (!Input.GetButton("P2 Jump"))
                {
                    jumpCharging = false;
                }

                if (!jumpCharging)
                {
                    moveDirection.y = jumpChargeAmount;
                    jumpChargeAmount = 0f;
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else
                {
                    if (jumpChargeAmount < jumpChargeMax)
                    {
                        jumpChargeAmount += jumpChargeScale * Time.deltaTime;
                        if (transform.localScale.y > 0.3f)
                        {
                            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - (flattenScale * Time.deltaTime), transform.localScale.z);
                        }
                    }
                }
            }
        } 
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * fallScale * Time.deltaTime);
        //controller.Move(moveDirection * Time.deltaTime);
        */
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
            rB.velocity = (transform.forward * forwardVelocity) + (transform.right * horizontalVelocity);
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
        

    }

    public void KnockBack()
    {
        Debug.Log("Player 2 Knocked Back");
        KnockBackObject knockBack = GetComponent<KnockBackObject>();

        knockBackCounter = knockBackTime;
        forwardVelocity = 0f;
        horizontalVelocity = 0f;
        rB.AddForce((-(knockBack.knockBackDirection * knockBack.knockbackAmount)) + (Vector3.up * knockBack.knockbackAmount * 0.2f), ForceMode.VelocityChange);


    }

}
