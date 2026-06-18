using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform player;

    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileDistance = 15f;
    void Start()
    {
        InvokeRepeating(nameof(Shoot), 1f, 2f);
    }
    public void Shoot()
    {
        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        Vector3 direction =
            (player.position - firePoint.position).normalized;

        Projectile projectileScript =
            projectile.GetComponent<Projectile>();

        projectileScript.Initialize(
            direction,
            projectileSpeed,
            projectileDistance
        );
    }
}
