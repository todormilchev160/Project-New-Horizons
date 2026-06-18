using UnityEngine;

public class Projectile : MonoBehaviour
{
       [SerializeField] private float damage = 5f;

    private Transform circleCenter;
    private float radius;
    private float angle;
    private float direction;
    private float speed;
    private float maxDistance;
    private float travelledDistance;

    public void Initialize(
        Transform center,
        float startRadius,
        float startAngle,
        float moveDirection,
        float projectileSpeed,
        float projectileDistance
    )
    {
        circleCenter = center;
        radius = startRadius;
        angle = startAngle;
        direction = moveDirection;
        speed = projectileSpeed;
        maxDistance = projectileDistance;

        transform.position = GetPositionOnCircle();
    }

    void Update()
    {
        if (circleCenter == null)
            return;

        float distanceThisFrame = speed * Time.deltaTime;
        travelledDistance += distanceThisFrame;

        float angularVelocity = (distanceThisFrame / radius) * Mathf.Rad2Deg;
        angle += angularVelocity * direction;

        transform.position = GetPositionOnCircle();

        if (travelledDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private Vector3 GetPositionOnCircle()
    {
        float radians = angle * Mathf.Deg2Rad;

        Vector3 position = circleCenter.position + new Vector3(
            Mathf.Cos(radians) * radius,
            0f,
            Mathf.Sin(radians) * radius
        );

        position.y = transform.position.y;
        return position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}