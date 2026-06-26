using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private PlayerAttack playerAttack;
    private Rigidbody rb;

    [Header("Circle Movement")]
    [SerializeField] private Transform circleCenter;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 6f;

    [Header("Collision")]
    [SerializeField] private float collisionExtraDistance = 0.05f;

    [Header("Rotation")]
    [SerializeField] private float rotationOffsetY = 0f;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashMomentumTime = 0.12f;
    [SerializeField] private float doubleClickTime = 0.3f;
    [SerializeField] private float dashCooldown = 0.5f;

    private float angle;
    private float direction = 0f;
    private float currentSpeed = 0f;
    private float normalMoveSpeed;
    private float visualDirectionOffset = 0f;

    private float lastLeftClickTime = -999f;
    private float lastRightClickTime = -999f;
    private float lastDashTime = -999f;

    private bool isDashing = false;
    private bool isHoldingMove = false;

    private Coroutine dashCoroutine;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        rb = GetComponent<Rigidbody>();

        normalMoveSpeed = moveSpeed;

        RecalculateCirclePosition();
        RotateTowardCenter();
    }

    void FixedUpdate()
    {
        if (direction == 0f || radius <= 0.01f)
            return;

        float targetSpeed = direction * moveSpeed;

        currentSpeed = Mathf.Lerp(
            currentSpeed,
            targetSpeed,
            acceleration * Time.fixedDeltaTime
        );

        float angularVelocity = (currentSpeed / radius) * Mathf.Rad2Deg;
        float nextAngle = angle + angularVelocity * Time.fixedDeltaTime;

        float radians = nextAngle * Mathf.Deg2Rad;

        Vector3 targetPosition = circleCenter.position + new Vector3(
            Mathf.Cos(radians) * radius,
            0f,
            Mathf.Sin(radians) * radius
        );

        targetPosition.y = rb.position.y;

        Vector3 move = targetPosition - rb.position;

        if (move.magnitude < 0.001f)
            return;

bool blocked = rb.SweepTest(
    move.normalized,
    out RaycastHit hit,
    move.magnitude + collisionExtraDistance,
    QueryTriggerInteraction.Ignore
);

if (blocked)
{
    currentSpeed = 0f;
    return;
}
        angle = nextAngle;
        rb.MovePosition(targetPosition);
        RotateTowardCenter();
    }

    public void MoveRight()
    {
        RecalculateCirclePosition();

        isHoldingMove = true;
        animator.SetBool("IsWalking", true);

        visualDirectionOffset = 0f;

        if (Time.time - lastRightClickTime < doubleClickTime)
        {
            StartDash(-1f);
            lastRightClickTime = -999f;
            return;
        }

        direction = -1f;
        lastRightClickTime = Time.time;
    }

    public void MoveLeft()
    {
        RecalculateCirclePosition();

        isHoldingMove = true;
        animator.SetBool("IsWalking", true);

        visualDirectionOffset = 180f;

        if (Time.time - lastLeftClickTime < doubleClickTime)
        {
            StartDash(1f);
            lastLeftClickTime = -999f;
            return;
        }

        direction = 1f;
        lastLeftClickTime = Time.time;
    }

    public void StopMoving()
    {
        isHoldingMove = false;

        if (isDashing)
            return;

        direction = 0f;
        currentSpeed = 0f;
        moveSpeed = normalMoveSpeed;

        animator.SetBool("IsWalking", false);
    }

    private void StartDash(float dashDirection)
    {
        if (Time.time - lastDashTime < dashCooldown)
            return;

        if (dashCoroutine != null)
            StopCoroutine(dashCoroutine);

        dashCoroutine = StartCoroutine(Dash(dashDirection));
    }

    private IEnumerator Dash(float dashDirection)
    {
        isDashing = true;
        lastDashTime = Time.time;

        direction = dashDirection;
        moveSpeed = dashSpeed;
        currentSpeed = dashDirection * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        float timer = 0f;

        while (timer < dashMomentumTime)
        {
            timer += Time.deltaTime;

            moveSpeed = Mathf.Lerp(
                dashSpeed,
                normalMoveSpeed,
                timer / dashMomentumTime
            );

            currentSpeed = dashDirection * moveSpeed;
            direction = dashDirection;

            yield return null;
        }

        moveSpeed = normalMoveSpeed;
        currentSpeed = 0f;
        isDashing = false;

        if (isHoldingMove)
        {
            direction = dashDirection;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            direction = 0f;
            animator.SetBool("IsWalking", false);
        }

        dashCoroutine = null;
    }

    private void RecalculateCirclePosition()
    {
        Vector3 offset = rb.position - circleCenter.position;
        offset.y = 0f;

        radius = offset.magnitude;
        angle = Mathf.Atan2(offset.z, offset.x) * Mathf.Rad2Deg;
    }

    private void RotateTowardCenter()
    {
        Vector3 directionToCenter = circleCenter.position - rb.position;
        directionToCenter.y = 0f;

        if (directionToCenter == Vector3.zero)
            return;

        rb.MoveRotation(
            Quaternion.LookRotation(directionToCenter) *
            Quaternion.Euler(0f, rotationOffsetY + visualDirectionOffset, 0f)
        );
    }
}