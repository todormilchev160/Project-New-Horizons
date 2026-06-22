using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    [Header("Circle Movement")]
    [SerializeField] private Transform circleCenter;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 10f;

    [Header("Rotation")]
    [SerializeField] private float rotationOffsetY = 0f;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float doubleClickTime = 0.3f;
    [SerializeField] private float dashCooldown = 0.5f;

    private float angle;
    private float direction = 0f;
    private float currentSpeed = 0f;
    private float normalMoveSpeed;

    private float lastLeftClickTime = -999f;
    private float lastRightClickTime = -999f;
    private float lastDashTime = -999f;

    private bool isDashing = false;
    private PlayerAttack playerAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerAttack=GetComponent<PlayerAttack>();
        normalMoveSpeed = moveSpeed;

        RecalculateCirclePosition();
        RotateTowardCenter();
    }

    void Update()
    {
        LockToCircle();
        if (direction == 0f)
            return;

        if (radius <= 0.01f)
            return;

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

        RotateTowardCenter();
    }
    private void LockToCircle()
{
    if (radius <= 0.01f)
        return;

    float radians = angle * Mathf.Deg2Rad;

    Vector3 lockedPosition = circleCenter.position + new Vector3(
        Mathf.Cos(radians) * radius,
        0f,
        Mathf.Sin(radians) * radius
    );

    lockedPosition.y = transform.position.y;
    transform.position = lockedPosition;

    RotateTowardCenter();
}

    public void MoveRight()
    {
        RecalculateCirclePosition();

        animator.SetBool("IsWalking", true);

        if (Time.time - lastRightClickTime < doubleClickTime)
        {
            StartCoroutine(Dash(-1f));
            lastRightClickTime = -999f;
            return;
        }

        direction = -1f;
        lastRightClickTime = Time.time;
        playerAttack.FaceRight();
    }

    public void MoveLeft()
    {
        RecalculateCirclePosition();

        animator.SetBool("IsWalking", true);

        if (Time.time - lastLeftClickTime < doubleClickTime)
        {
            StartCoroutine(Dash(1f));
            lastLeftClickTime = -999f;
            return;
        }

        direction = 1f;
        lastLeftClickTime = Time.time;
        playerAttack.FaceLeft();
    }

    public void StopMoving()
    {
        if (isDashing)
            return;

        direction = 0f;
        animator.SetBool("IsWalking", false);
    }

    private IEnumerator Dash(float dashDirection)
    {
        if (isDashing)
            yield break;

        if (Time.time - lastDashTime < dashCooldown)
            yield break;

        isDashing = true;
        lastDashTime = Time.time;

        direction = dashDirection;
        moveSpeed = dashSpeed;
        currentSpeed = dashDirection * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        moveSpeed = normalMoveSpeed;
        currentSpeed = 0f;
        direction = 0f;
        isDashing = false;

        animator.SetBool("IsWalking", false);
    }

    private void RecalculateCirclePosition()
    {
        Vector3 offset = transform.position - circleCenter.position;
        offset.y = 0f;

        radius = offset.magnitude;
        angle = Mathf.Atan2(offset.z, offset.x) * Mathf.Rad2Deg;
    }

    private void RotateTowardCenter()
    {
        Vector3 directionToCenter = circleCenter.position - transform.position;
        directionToCenter.y = 0f;

        if (directionToCenter == Vector3.zero)
            return;

        transform.rotation =
            Quaternion.LookRotation(directionToCenter) *
            Quaternion.Euler(0f, rotationOffsetY, 0f);
    }
}