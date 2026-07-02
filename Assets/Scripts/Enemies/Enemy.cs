using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class Enemy : MonoBehaviour
{
    [SerializeField]private float damage=5;
    [Header("Patrol")]
    public Transform patrolPointA;
    public Transform patrolPointB;
    public float waitTime = 1f;
    public float idleBeforeTurnTime = 0.5f;
    private bool waiting;
    private NavMeshAgent agent;
    private Transform currentTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    agent = GetComponent<NavMeshAgent>();
    currentTarget = patrolPointB;
    agent.SetDestination(currentTarget.position);
}
    void Update()
    {
        Patrol();
    }
    void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
    private void Patrol()
    {
        if (waiting)
            return;
        agent.updateRotation=false;
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(SwitchPoint());
        }
    }

    private IEnumerator SwitchPoint()
    {
        waiting = true;

        agent.isStopped = true;
        yield return new WaitForSeconds(waitTime + idleBeforeTurnTime);
        currentTarget = currentTarget == patrolPointA ? patrolPointB : patrolPointA;

        agent.isStopped = false;
        agent.SetDestination(currentTarget.position);

        waiting = false;
    }
    private void OnDisable()
{
    StopAllCoroutines();
    waiting = false;

    if (agent != null)
        agent.isStopped = false;
          agent.ResetPath();
}
}
