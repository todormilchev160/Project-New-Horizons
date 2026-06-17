using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    [Header("Circle Movement")]
    [SerializeField] private Transform circleCenter;
    [SerializeField] private float radius = 3f;
    [SerializeField] private float currentSpeed = 120f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float moveSpeed = 5f;
    [Header("Dash")]
    [SerializeField]private float dashSpeed=20;
    [SerializeField] private float dashDistance = 5;
    [SerializeField]private float doubleclicktime;
    private float timesincelassleftclick;
    private float timesincelastrightclick;
    private float rightdirection=1;
    private float leftdirection=-1;

    private float direction = 0f;
    private float currentAngularSpeed = 0f;
    private float angle;

    void Start()
    {
        animator = GetComponent<Animator>();


    animator = GetComponent<Animator>();

    Vector3 offset = transform.position - circleCenter.position;

    offset.y = 0f; // ignore height

    radius = offset.magnitude;

    angle = Mathf.Atan2(offset.z, offset.x) * Mathf.Rad2Deg;
    }

    void Update()
{
    timesincelassleftclick++;
    timesincelastrightclick++;
   float targetSpeed = direction * moveSpeed;

currentSpeed = Mathf.Lerp(
    currentSpeed,
    targetSpeed,
    acceleration * Time.deltaTime
);

       float angularVelocity = (currentSpeed / radius) * Mathf.Rad2Deg;
       angle += angularVelocity * Time.deltaTime;

        float radians = angle * Mathf.Deg2Rad;

Vector3 newPosition = circleCenter.position + new Vector3(
    Mathf.Cos(radians) * radius,
    0f,
    Mathf.Sin(radians) * radius
);

newPosition.y = transform.position.y;

transform.position = newPosition;

    newPosition.y = transform.position.y;

     transform.position = newPosition;

      transform.position = newPosition;
    }

    public void MoveRight()
    {
        animator.SetBool("IsWalking", true);
        if(timesincelastrightclick<doubleclicktime)
        {
            StartCoroutine(Dash(-1));
        }
        else
        {
            direction = -1f;
        }
        timesincelastrightclick=0;
    }

    public void MoveLeft()
    {
        animator.SetBool("IsWalking", true);
        if(timesincelassleftclick<doubleclicktime)
        {
            StartCoroutine(Dash(1));
        }
        else
        {
           direction = 1f; 
        }
        timesincelassleftclick=0;
    }

    public void StopMoving()
    {
        direction = 0f;
        animator.SetBool("IsWalking", false);
    }
    public IEnumerator Dash(float directiondash)
    {
        direction=directiondash;
        moveSpeed=dashSpeed;
        yield return new WaitForSeconds(dashDistance);
        moveSpeed=5f;
    }
}