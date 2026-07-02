using FMODUnity;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    private bool isGrounded;

    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private string jumpsoundPath;
    private int jumpsRemaining;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.02f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private EventReference jumpEvent;

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


        if (isGrounded && rb.linearVelocity.y <= 0.1f)
        {
            animator.SetBool("IsGrounded", true);
            jumpsRemaining = maxJumps;
        }
    }

    public void StartJump()
    {
        if (jumpsRemaining == 2)
        {

            animator.SetTrigger("IsJumping");
        }
        if (jumpsRemaining == 1)
        {
            animator.SetTrigger("IsDoubleJumping");
        }
        RuntimeManager.PlayOneShot(jumpEvent);
        if (jumpsRemaining <= 0)
            return;

        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpForce,
            rb.linearVelocity.z
        );

        jumpsRemaining--;
        animator.SetBool("IsGrounded", false);
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