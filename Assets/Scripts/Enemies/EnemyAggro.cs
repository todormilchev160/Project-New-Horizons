using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
   [SerializeField] private float detectionRange = 10f;

    private Enemy patrolScript;
    private EnemyAttack chaseScript;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        patrolScript = GetComponent<Enemy>();
        chaseScript = GetComponent<EnemyAttack>();

        chaseScript.enabled = false;
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        patrolScript.enabled = distance > detectionRange;
        chaseScript.enabled = distance <= detectionRange;
    }
}
