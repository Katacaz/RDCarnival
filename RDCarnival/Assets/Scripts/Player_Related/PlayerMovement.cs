using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    [Header("Physics")]
    public Rigidbody playerRigidbody;

    [Header("Animation")]
    public Animator playerAnimator;

    [Header("Input")]
    public bool useOldInputManager = false;
    public PlayerInput playerInput;

    private Vector3 inputDirection;
    private Vector2 movementInput;
    public bool currentInput = false;

    [Header("Movement Settings")]
    public float movementSpeed = 3.0f;
    private float baseSpeed;
    public float smootingSpeed = 2.0f;
    private Vector3 currentDirection;
    private Vector3 rawDirection;
    private Vector3 smoothDirection;
    private Vector3 movement;

    private bool isBoosting;
    public float boostSpeedMultiplier = 2;

    bool movingForward;

    public float defaultKnockbackAmount = 5.0f;
    [Header("Cannon Settings")]
    public Transform cannonballSpawnPoint;
    public GameObject cannonBallPrefab;
    private bool shooting;
    public float cannonKnockbackAmoung = 1.0f;

    public float currentSpeed;
    private float maxSpeed;
    //private float minSpeed = 5.0f;
    public float accelerationMultiplier = 2.0f;
    public float decellerationMultiplier = 4.0f;


    void Start()
    {
        maxSpeed = movementSpeed;
        currentSpeed = movementSpeed;
        baseSpeed = movementSpeed;
        FindCamera();
        //SetUpAnimationIDs();
    }

    void FindCamera()
    {
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void SetupAnimationIDs()
    {

    }
    void Update()
    {
        
        CheckShoot();
        if (isBoosting)
        {
            movementSpeed = baseSpeed * boostSpeedMultiplier;
        } else
        {
            movementSpeed = baseSpeed;
        }
        maxSpeed = movementSpeed;
        
        CalculateMovementInput();
        CalculateAttackInput();
        /*if (inputDirection.magnitude > 0.1)
        {
            Debug.Log("Accellerating");
            if (currentSpeed < minSpeed)
            {
                currentSpeed = minSpeed;
            }
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += Time.deltaTime * accelerationMultiplier;
            } 
        } else
        {
            Debug.Log("Decellerating");
            if (currentSpeed > 0)
            {
                currentSpeed -= Time.deltaTime * decellerationMultiplier;
            } else if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }*/
        
    }

    private void FixedUpdate()
    {
        CalculateDesiredDirection();
        ConvertDirectionFromRawToSmooth();
        MoveThePlayer();
        AnimatePlayerMovement();
        TurnThePlayer();
        
        currentSpeed = playerRigidbody.velocity.magnitude;
    }

    void CalculateMovementInput()
    {
        if (useOldInputManager)
        {
            var v = Input.GetAxisRaw("Vertical");
            var h = Input.GetAxisRaw("Horizontal");
            inputDirection = new Vector3(h, 0, v);
        }

        if (inputDirection == Vector3.zero)
        {
            currentInput = false;
        }
        else if(inputDirection != Vector3.zero)
        {
            currentInput = true;
        }
    }

    void CalculateAttackInput()
    {
        if (useOldInputManager)
        {
            if (Input.GetButtonDown("Fire"))
            {

            }
        }
    }
    void CalculateDesiredDirection()
    {

        var cameraForward = playerCamera.transform.forward;
        var cameraRight = playerCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        rawDirection = cameraForward * inputDirection.z + cameraRight * inputDirection.x;
    }

    void ConvertDirectionFromRawToSmooth()
    {
        if (currentInput == true || isBoosting)
        {
            smoothDirection = Vector3.Lerp(smoothDirection, rawDirection, Time.deltaTime * smootingSpeed);
        } else if (currentInput == false)
        {
            smoothDirection = Vector3.zero;
        }
    }
    void MoveThePlayer()
    {
        if (currentInput == true || isBoosting)
        {
            movement.Set(smoothDirection.x, 0f, smoothDirection.z);
            movement = movement.normalized * movementSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + movement);
        }
    }
    void TurnThePlayer()
    {
        if (currentInput == true)
        {
            Quaternion newRotation = Quaternion.LookRotation(smoothDirection);
            playerRigidbody.MoveRotation(newRotation);
        }
    }
    void AnimatePlayerMovement()
    {

    }

    void OnMovement(InputValue value)
    {
        Vector2 inputMovement = value.Get<Vector2>();
        inputDirection = new Vector3(inputMovement.x, 0, inputMovement.y);
    }
    void OnFire()
    {
        Debug.Log("Shot Cannon");
        shooting = true;
    }
    void OnJump()
    {
        Debug.Log("Jumped");
    }

    void OnBoost()
    {
        isBoosting = !isBoosting;
    }
    public void CheckShoot()
    {
        if (shooting)
        {
            shooting = false;
            ShootCannon();
        }
    }
    void ShootCannon()
    {
        
        GameObject cannonBall = Instantiate(cannonBallPrefab);
        Physics.IgnoreCollision(cannonBall.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
        cannonBallPrefab.transform.position = cannonballSpawnPoint.transform.position;
        cannonBall.transform.rotation = this.transform.rotation;
        cannonBall.GetComponent<CannonBall>().moveSpeed += (movementSpeed);
        
        CannonKnockback();
        
    }
    void CannonKnockback()
    {
        KnockBack((cannonballSpawnPoint.position - transform.position).normalized , cannonKnockbackAmoung);
    }
    public void KnockBack(Vector3 direction, float amount)
    {
        playerRigidbody.AddForce((-direction * amount) + (Vector3.up * amount * 0.1f), ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if (other.GetComponent<KnockBackTrigger>() != null)
        {
            Vector3 collisionDirection = (other.transform.position - transform.position).normalized;
            float knockbackAmount = defaultKnockbackAmount;
            if (other.GetComponent<Rigidbody>() != null)
            {
                knockbackAmount = other.GetComponent<Rigidbody>().velocity.magnitude;
            }
            if (other.GetComponent<KnockBackTrigger>().willDestroyOnKnockback)
            {
                other.GetComponent<KnockBackTrigger>().DestroyThisObject();
            }
            KnockBack(collisionDirection, knockbackAmount);
                
        }
    }
}
