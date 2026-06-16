using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [Header ("Movement")]
    [SerializeField]private float speed=5f;
    [SerializeField]private float acceleration=10f;
    [Header ("Dash")]
    public float dashSpeed = 15f;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField]private float doubleTapTime = 0.3f;

    private float lastLeftTap;
    private float lastRightTap;

    private bool isDashing=false;
    private float dashTimer;
    private float direction =0f;
    private float currentSpeed=0f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetSpeed = direction * speed;

        currentSpeed = Mathf.Lerp(
            currentSpeed,
            targetSpeed,
            acceleration * Time.deltaTime
        );
       transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);    
    if (isDashing)
    {
        dashTimer -= Time.deltaTime;

        if (dashTimer <= 0)
        {
            isDashing = false;
            StopMoving();
        }
    }
    }
    public void MoveRight()
    {
      if (Time.time - lastRightTap < doubleTapTime)
    {
        Dash(1);
    }
    else
    {
        direction = 1f;
        animator.SetBool("IsWalking", true);
    }
        animator.SetBool("IsWalking", true);
    }
    public void MoveLeft()
    {
    if (Time.time-lastLeftTap < doubleTapTime)
    {
        Dash(-1);
    }
    else
    { 
        direction = -1f;
       
    }
        animator.SetBool("IsWalking", true);
    }
    public void StopMoving()
    {
        if (isDashing)
        {
            return; 
        }
        direction=0f;
        animator.SetBool("IsWalking", false);
    }
    private void Dash(float dashDirection)
{
    Debug.Log("Dash");
    isDashing = true;
    dashTimer = dashDuration;

    direction = dashDirection;

    rb.linearVelocity = new Vector2(
        dashDirection * dashSpeed,
        rb.linearVelocity.y
    );
}
}
