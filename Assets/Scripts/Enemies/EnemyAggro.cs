using UnityEngine;
using UnityEngine.AI;

public class EnemyAggro : MonoBehaviour
{
   [SerializeField] private float detectionRange = 10f;

    private Enemy patrolScript;
    private EnemyAttack chaseScript;
    private NavMeshAgent navMeshAgent;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        patrolScript = GetComponent<Enemy>();
        chaseScript = GetComponent<EnemyAttack>();
        navMeshAgent=GetComponent<NavMeshAgent>();

        chaseScript.enabled = false;
    }

private bool isAggro;

private void Update()
{
    if (player == null) return;

    float distance = Vector3.Distance(transform.position, player.position);
    bool shouldAggro = distance <= detectionRange;

    if (shouldAggro == isAggro) return;

    isAggro = shouldAggro;

    patrolScript.enabled = !isAggro;
    chaseScript.enabled = isAggro;
    navMeshAgent.enabled = !isAggro;
}
}
