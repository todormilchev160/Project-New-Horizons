using UnityEngine;

public class GuitarCollectible : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddGuitarScore(scoreAmount);
            Destroy(gameObject);
        }
    }
}