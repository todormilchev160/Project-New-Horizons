using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform circleCenter;

    [SerializeField] private float distanceFromPlayer = 8f;
    [SerializeField] private float heightOffset = 1.5f;
    [SerializeField] private float followSpeed = 8f;
    [SerializeField] private float rotationSpeed = 8f;

    void LateUpdate()
    {
        Vector3 outward = player.position - circleCenter.position;
        outward.y = 0f;
        outward.Normalize();

        Vector3 targetPosition =
            player.position
            - outward * distanceFromPlayer
            + Vector3.up * heightOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );

        Quaternion targetRotation = Quaternion.LookRotation(
            outward,
            Vector3.up
        );

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}