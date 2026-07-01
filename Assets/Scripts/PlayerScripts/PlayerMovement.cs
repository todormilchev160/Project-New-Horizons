using System.Collections;
using UnityEngine;
using FMODUnity;

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

    [Header("Rotation")]
    [SerializeField] private float rotationOffsetY = 0f;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashMomentumTime = 0.12f;
    [SerializeField] private float doubleClickTime = 0.3f;
    [SerializeField] private float dashCooldown = 0.5f;

    [Header("FMOD Footsteps")]
    [SerializeField] private EventReference FootstepEvent;
    [SerializeField] private float WalkStepRate = 0.5f;
    [SerializeField] private float DashStepRate = 0.32f;

    private float footstepTimer = 0f;

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

        Vector3 offset = rb.position - circleCenter.position;
offset.y = 0f;
radius = offset.magnitude;

RecalculateCirclePosition();
        RotateTowardCenter();
    }

    void FixedUpdate()
    {
        if (direction == 0f || radius <= 0.01f)
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            footstepTimer = 0f;
            return;
        }

        float targetSpeed = direction * moveSpeed;

        currentSpeed = Mathf.Lerp(
            currentSpeed,
            targetSpeed,
            acceleration * Time.fixedDeltaTime
        );

        float radians = angle * Mathf.Deg2Rad;

        Vector3 radialDirection = new Vector3(
            Mathf.Cos(radians),
            0f,
            Mathf.Sin(radians)
        );

        Vector3 tangentDirection = new Vector3(
            -radialDirection.z,
            0f,
            radialDirection.x
        );

        Vector3 velocity = tangentDirection * currentSpeed;

        rb.linearVelocity = new Vector3(
            velocity.x,
            rb.linearVelocity.y,
            velocity.z
        );

        HandleFootsteps();
        RecalculateCirclePosition();
        RotateTowardCenter();
        LockToCircle();
    }

    private void HandleFootsteps()
    {
        Vector3 horizontalVelocity = new Vector3(
            rb.linearVelocity.x,
            0f,
            rb.linearVelocity.z
        );

        if (horizontalVelocity.magnitude < 0.1f)
        {
            footstepTimer = 0f;
            return;
        }

        float stepRate = isDashing ? DashStepRate : WalkStepRate;

        footstepTimer -= Time.fixedDeltaTime;

        if (footstepTimer <= 0f)
        {
            RuntimeManager.PlayOneShot(FootstepEvent, transform.position);
            footstepTimer = stepRate;
        }
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
        footstepTimer = 0f;

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

    angle = Mathf.Atan2(offset.z, offset.x) * Mathf.Rad2Deg;
}

private void LockToCircle()
{
    float radians = angle * Mathf.Deg2Rad;

    Vector3 lockedPosition = circleCenter.position + new Vector3(
        Mathf.Cos(radians) * radius,
        rb.position.y - circleCenter.position.y,
        Mathf.Sin(radians) * radius
    );

    rb.position = lockedPosition;
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