using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerFallDeath : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    [SerializeField]private string deathScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y<=0.3)
        {
            Die();
        }
    }
    void Die()
    { 
        animator.SetTrigger("Endscene");
        SceneManager.LoadScene(deathScene);
    }
}
