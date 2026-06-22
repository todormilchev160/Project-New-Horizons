using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreAmount);
            Destroy(gameObject);
        }
    }
}