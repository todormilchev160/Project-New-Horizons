using UnityEngine;

public class PlayerJump : MonoBehaviour
{
       private Rigidbody rb;
       [SerializeField]private float jumpHeight=0f;
       private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb=GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
 

   public void Jump()
   {
    if(isGrounded)
    {
        rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
    }
    else
    {
        return;
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

