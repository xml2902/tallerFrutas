using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        animator.SetFloat("MoveInX", Mathf.Abs(moveInput.x));
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        bool isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);

        if (context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

   

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

        animator.SetBool("InGround",groundCheck);

        bool isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);
        Debug.Log(isGrounded);
    }
}
