using UnityEngine;
using System.Collections;
public class PlayerAttack : MonoBehaviour
{
   [Header("Attack Settings")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 4f;
    [SerializeField] private float coneAngle = 60f;
    [SerializeField] private float attackDuration = 1f;
    [SerializeField] private LayerMask enemyLayer;

    private bool attacking;

    private void Start()
    {

    }

    private void Update()
    {
 
    }
    public void Attacking()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        attacking = true;
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            range,
            enemyLayer
        );

        foreach (Collider hit in hits)
        {
            Vector3 directionToTarget = hit.transform.position - transform.position;
            directionToTarget.y = 0f;

            float angle = Vector3.Angle(transform.forward, directionToTarget);

            if (angle <= coneAngle / 2f)
            {
                EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }

        yield return new WaitForSeconds(attackDuration);

        attacking = false;
    }
}
