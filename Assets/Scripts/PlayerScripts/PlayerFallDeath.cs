using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerFallDeath : MonoBehaviour
{
    private float falltime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().linearVelocity.y < 0)
        {
            falltime++;
        }
        if(GetComponent<Rigidbody>().linearVelocity.y>=0)
        {
            falltime=0;
        }

        if (falltime>= 80)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
