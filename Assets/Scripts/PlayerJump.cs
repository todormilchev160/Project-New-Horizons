using UnityEngine;

public class PlayerJump : MonoBehaviour
{
       private Rigidbody rb;
       private Animator animator;
       private bool isGrounded;
       [SerializeField]private float jumpForce = 8f;
       [SerializeField]private float maxJumpTime = 0.3f;

       private float jumpTimeCounter;
       private bool isJumping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb=GetComponent<Rigidbody>();  
      animator=GetComponent<Animator>();
    }
    void Update()
{
     animator.SetBool("IsGrounded", isGrounded);
    if (isJumping)
    {
        if (jumpTimeCounter > 0)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );

            jumpTimeCounter -= Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }
} 

public void StartJump()
{
    if (isGrounded)
    {
        animator.SetTrigger("Jump");
        isJumping = true;
        jumpTimeCounter = maxJumpTime;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce
        );
    }
}
public void StopJumping()
    {
        isJumping = false;
    }
   void OnCollisionEnter(Collision col)
   {
        if(col.gameObject.tag == "Ground")
		{
			isGrounded=true;
        }
   }
    void OnCollisionExit(Collision col)
   {
        if(col.gameObject.tag == "Ground")
		{
			isGrounded=false;
        }
   }
}

