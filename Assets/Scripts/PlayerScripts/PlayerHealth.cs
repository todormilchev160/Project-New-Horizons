using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health=100;
   
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
        Debug.Log("Damaged");
        health-=damage;
    }
    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
