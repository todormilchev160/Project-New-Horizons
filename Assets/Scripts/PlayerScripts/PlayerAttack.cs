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
    [SerializeField]private GameObject attackvisual;
    [SerializeField]private GameObject attackvisualleft;
    private bool facingRight=true;
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
    if (attacking)
        yield break;

    attacking = true;

    bool attackWasRight = facingRight;

    attackvisual.SetActive(false);
    attackvisualleft.SetActive(false);

    GameObject activeVisual = attackWasRight ? attackvisual : attackvisualleft;
    activeVisual.SetActive(true);

    Vector3 attackDirection =
        attackWasRight ? transform.forward : -transform.forward;

    DrawDebugCone(attackDirection);

    Collider[] hits = Physics.OverlapSphere(
        transform.position,
        range,
        enemyLayer
    );

    foreach (Collider hit in hits)
    {
        Vector3 directionToTarget = hit.transform.position - transform.position;
        directionToTarget.y = 0f;

        float angle = Vector3.Angle(attackDirection, directionToTarget);

        if (angle <= coneAngle / 2f)
        {
            EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
                enemyHealth.TakeDamage(damage);
        }
    }

    yield return new WaitForSeconds(attackDuration);

    activeVisual.SetActive(false);
    attacking = false;
}
private void DrawDebugCone(Vector3 attackDirection)
{
    Vector3 origin = transform.position;

    int segments = 20;
    float halfAngle = coneAngle * 0.5f;

    Vector3 previousPoint = Vector3.zero;

    for (int i = 0; i <= segments; i++)
    {
        float angle = Mathf.Lerp(-halfAngle, halfAngle, (float)i / segments);

        Vector3 direction =
            Quaternion.Euler(0, angle, 0) * attackDirection;

        Vector3 point = origin + direction * range;

        if (i > 0)
            Debug.DrawLine(previousPoint, point, Color.red, attackDuration);

        previousPoint = point;
    }

    Vector3 leftEdge =
        Quaternion.Euler(0, -halfAngle, 0) * attackDirection;

    Vector3 rightEdge =
        Quaternion.Euler(0, halfAngle, 0) * attackDirection;

    Debug.DrawLine(origin, origin + leftEdge * range, Color.red, attackDuration);
    Debug.DrawLine(origin, origin + rightEdge * range, Color.red, attackDuration);
}

}
