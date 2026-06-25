using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    private bool isGrounded;

    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int maxJumps = 2;

    private int jumpsRemaining;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.02f;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponent<Animator>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        animator.SetBool("IsGrounded", isGrounded);

        if (isGrounded && rb.linearVelocity.y <= 0.1f)
        {
            jumpsRemaining = maxJumps;
        }
    }

    public void StartJump()
    {
        if (jumpsRemaining <= 0)
            return;

        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpForce,
            rb.linearVelocity.z
        );

        jumpsRemaining--;
        isGrounded = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}