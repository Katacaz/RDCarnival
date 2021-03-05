using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraController : MonoBehaviour
{

    public PlayerInput cameraInput;
    public GameObject target;
    public Transform pivot;

    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public float maxViewAngle = 45f;
    public float minViewAngle = 315f;

    public bool invertYAxis;
    public bool invertXAxis;

    InputActions_Camera inputActions;

    Vector2 movementInput;

    private void Awake()
    {
        inputActions = new InputActions_Camera();
        inputActions.CameraMovement.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.transform.position - transform.position;
        }
        pivot.position = target.transform.position;
        pivot.parent = target.transform;

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Get the X position of the mouse & rotate target
        //float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float horizontal = movementInput.x * rotateSpeed;
        if (invertXAxis)
        {
            target.transform.Rotate(0f, -horizontal, 0f);
        } else
        {
            target.transform.Rotate(0f, horizontal, 0f);
        }

        //Get the Y position of the mouse & rotate the pivot
        float vertical = movementInput.y * rotateSpeed;
        //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (invertYAxis)
        {
            pivot.Rotate(vertical, 0f, 0f);
        } else
        {
            pivot.Rotate(-vertical, 0f, 0f);
        }
        

        //Limit Up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        //Move camera based on the current rotation of the target
        float desiredYAngle = target.transform.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;


        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0f);
        transform.position = target.transform.position - (rotation * offset);

        if (transform.position.y < (target.transform.position.y - 0.5f))
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
        }
        //transform.position = target.transform.position - offset;
        transform.LookAt(target.transform.position);
    }

    public void ChangeTarget(GameObject t)
    {
        pivot.position = t.transform.position;
        pivot.parent = t.transform;

        target = t;
    }

    void OnMovement(InputAction value)
    {
        //Vector2 inputMovement = value.Get<Vector2>();
        //= new Vector3(inputMovement.x, 0, inputMovement.y);
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
