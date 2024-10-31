using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curInput;
    private Rigidbody rb;
    public float jumpForce;
    public LayerMask groundMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float lookSensitivity;
    public float maxLookAngle;
    public float minLookAngle;
    private bool canLook = true;
    private Vector2 mouseDelta;
    private float cameraXRot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        CharacterManager.Instance.Player.controller = this;
    }

    void FixedUpdate()
    {
        Move();
    }

    void LateUpdate()
    {
        if (canLook)
        {
            Look();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curInput = Vector2.zero;
        }
    }
    private void Move()
    {
        Vector3 newPos = curInput.x * transform.right + curInput.y * transform.forward;
        newPos *= moveSpeed;
        newPos.y = rb.velocity.y;
        rb.velocity = newPos;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    private void Look()
    {
        cameraXRot += mouseDelta.y * lookSensitivity;
        cameraXRot = Mathf.Clamp(cameraXRot, minLookAngle, maxLookAngle);
        cameraContainer.localEulerAngles = new Vector3(-cameraXRot, 0, 0);
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGround())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGround()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundMask))
            {
                return true;
            }
        }
        return false;
    }
}
