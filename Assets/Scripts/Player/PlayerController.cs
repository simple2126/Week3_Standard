using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curInput;
    private Rigidbody rb;

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
}
