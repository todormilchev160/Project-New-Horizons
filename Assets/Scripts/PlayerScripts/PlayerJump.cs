using UnityEngine;

public class PlayerJump : MonoBehaviour
{
       private Rigidbody rb;
       private Animator animator;
       private bool isGrounded;
       [SerializeField]private float jumpForce = 8f;
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
} 

public void StartJump()
{
    if (isGrounded)
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce
        );
    }
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

