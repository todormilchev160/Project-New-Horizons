using System.Collections;
using FMODUnity;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyhealth = 30;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private EventReference damageEvent;
    [SerializeField] private EventReference dieEvent;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(dieEvent, gameObject);
        enemyhealth -= damage;
        animator.SetTrigger("EnemyDamaged");
        if (enemyhealth <= 0)
        {
            Die();
        }
    }
    public IEnumerator DamageFeedback()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1);
        GetComponent<Renderer>().material.color = Color.gray;
    }
    public void Die()
    {
        animator.SetTrigger("EnemyDying");
        RuntimeManager.PlayOneShotAttached(damageEvent, gameObject);
        Instantiate(notePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}