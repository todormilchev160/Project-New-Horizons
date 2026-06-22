using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerFallDeath : MonoBehaviour
{
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y<=0)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("MaxScene");
    }
}
