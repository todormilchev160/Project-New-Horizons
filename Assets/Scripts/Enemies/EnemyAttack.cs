using System.Collections;
using FMODUnity;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform player;
    [SerializeField] private Transform circleCenter;

    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileDistance = 15f;
    [SerializeField]private float fireRate=2;
    [SerializeField] private EventReference fireEvent;
    private Rigidbody rb;

     
    void Start()
    {
        InvokeRepeating(nameof(Shoot), 1f, fireRate);
        rb=GetComponent<Rigidbody>();
        rb.constraints=RigidbodyConstraints.FreezePositionX;
        rb.constraints=RigidbodyConstraints.FreezePositionZ;
    } 
 
    public void Shoot()
    {
        TurnTowardsPlayer();
        RuntimeManager.PlayOneShotAttached(fireEvent,gameObject);
        Vector3 enemyOffset = firePoint.position - circleCenter.position;
        enemyOffset.y = 0f;

        Vector3 playerOffset = player.position - circleCenter.position;
        playerOffset.y = 0f;

        float projectileRadius = enemyOffset.magnitude;
        float projectileAngle = Mathf.Atan2(enemyOffset.z, enemyOffset.x) * Mathf.Rad2Deg;

        float enemyAngle = Mathf.Atan2(enemyOffset.z, enemyOffset.x) * Mathf.Rad2Deg;
        float playerAngle = Mathf.Atan2(playerOffset.z, playerOffset.x) * Mathf.Rad2Deg;

        float clockwiseDistance = Mathf.Repeat(playerAngle - enemyAngle, 360f);
        float counterClockwiseDistance = Mathf.Repeat(enemyAngle - playerAngle, 360f);

        float direction;

        if (clockwiseDistance < counterClockwiseDistance)
            direction = 1f;
        else
            direction = -1f;

        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

            Projectile projectileScript =
            projectile.GetComponent<Projectile>();

projectileScript.Initialize(
    circleCenter,
    projectileRadius,
    projectileAngle,
    direction,
    projectileSpeed,
    projectileDistance,
    player.position.y
);
    }
    private void TurnTowardsPlayer()
    {
        Vector3 direction=player.position-transform.position;
        direction.y=0f;
        transform.rotation=Quaternion.LookRotation(direction);
    }
}