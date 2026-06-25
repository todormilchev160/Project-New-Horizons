using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health=100;
    [SerializeField]private string deathScene;
    [SerializeField]private float scoreLostOnDeath;
     private float falltime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     Debug.Log(health);
     if(health<=0)
        {
            Die();
        }
    }
    
    public void TakeDamage(float damage)
    {
        StartCoroutine(DamageFeedback());
        health-=damage;
    }
    void Die()
    {
       ScoreManager.instance.LoseScore(scoreLostOnDeath);
        SceneManager.LoadScene(deathScene);
    }
    IEnumerator DamageFeedback()
    {
        GetComponent<Renderer>().material.color=Color.white;
        yield return new WaitForSeconds(0.2f);
        GetComponent<Renderer>().material.color=Color.gray;
    }
}
