using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private float enemyhealth=30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemyhealth);
    }
    public void TakeDamage(float damage)
    {
        enemyhealth-=damage;
        StartCoroutine(DamageFeedback());
        if(enemyhealth<=0)
        {
            Die();
        }
    }
    public IEnumerator DamageFeedback()
    {
        GetComponent<Renderer>().material.color=Color.red;
        yield return new WaitForSeconds(1);
        GetComponent<Renderer>().material.color=Color.gray;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
