using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField]private float speed=5f;
    [SerializeField]private float acceleration=10f;
    private float direction =0f;
    private float currentSpeed=0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator=GetComponent<Animator>();
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
    }
    public void MoveRight()
    {
        direction=1f;
        animator.SetBool("IsWalking", true);
    }
    public void MoveLeft()
    {
        direction=-1f;
        animator.SetBool("IsWalking", true);
    }
    public void StopMoving()
    {
        direction=0f;
        animator.SetBool("IsWalking", false);
    }
}
