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

    //private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    // ✅ Detectar suelo TODO el tiempo
    //    Transform GroundCheck = this.GroundCheck;
    //    isGrounded = Physics2D.Raycast(
    //        GroundCheck.position,
    //        Vector2.down,
    //        groundDistance,
    //        groundLayer
    //    );

    //    animator.SetBool("InGround", isGrounded);
    //    Debug.DrawRay(GroundCheck.position, Vector2.down * groundDistance, Color.red);
    //}


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        animator.SetFloat("MoveInX", Mathf.Abs(moveInput.x));
    }



    //public void OnJump(InputAction.CallbackContext context)
    //{
    //    if (context.performed && isGrounded) // ✅ usa la global
    //    {
    //        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    //    }
    //}
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

        animator.SetBool("InGround", groundCheck);

        bool isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);
        Debug.Log(isGrounded);
    }


}
