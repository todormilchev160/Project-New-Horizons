using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 startPosition;
    private float maxDistance;
    [SerializeField]private float damage=5;
    private Rigidbody rb;

    public void Initialize(Vector3 direction, float speed, float distance)
    {
        rb = GetComponent<Rigidbody>();

        startPosition = transform.position;
        maxDistance = distance;

        rb.linearVelocity = direction.normalized * speed;
    }

    private void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

     void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}