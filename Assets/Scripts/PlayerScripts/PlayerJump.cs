using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    private bool isGrounded=true;

    [SerializeField] private float jumpForce = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void StartJump()
    {
        if (!isGrounded)
        {
            Debug.Log("Notgrounded");
            return;
        }
           

        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpForce,
            rb.linearVelocity.z
        );

        isGrounded = false;
    }

    private void OnCollisionEnter(Collision col)
    {
 
            isGrounded = true;
    }
}