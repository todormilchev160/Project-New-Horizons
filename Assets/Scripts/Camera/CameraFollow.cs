using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform circleCenter;

    [SerializeField] private float distanceFromPlayer = 8f;
    [SerializeField] private float heightOffset = 1.5f;
    [SerializeField] private float followSpeed = 8f;
    [SerializeField] private float rotationSpeed = 8f;

    [Header("Look Ahead")]
    [SerializeField] private float lookAheadDistance = 2f;
    [SerializeField] private float lookAheadSmoothSpeed = 5f;
    [SerializeField] private float movementThreshold = 0.02f;

    private Vector3 lastPlayerPosition;
    private Vector3 currentLookAheadOffset;

    private void Start()
    {
        lastPlayerPosition = player.position;
    }

    private void LateUpdate()
    {
        Vector3 outward = player.position - circleCenter.position;
        outward.y = 0f;

        if (outward.sqrMagnitude < 0.001f)
            return;

        outward.Normalize();

        Vector3 movement = player.position - lastPlayerPosition;
        movement.y = 0f;

        Vector3 targetLookAheadOffset = Vector3.zero;

        if (movement.sqrMagnitude > movementThreshold * movementThreshold)
        {
            targetLookAheadOffset = movement.normalized * lookAheadDistance;
        }

        currentLookAheadOffset = Vector3.Lerp(
            currentLookAheadOffset,
            targetLookAheadOffset,
            lookAheadSmoothSpeed * Time.deltaTime
        );

        Vector3 targetPosition =
            player.position
            + currentLookAheadOffset
            - outward * distanceFromPlayer
            + Vector3.up * heightOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );

        Quaternion targetRotation = Quaternion.LookRotation(outward, Vector3.up);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        lastPlayerPosition = player.position;
    }
}