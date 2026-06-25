using System;
using UnityEngine;

public class GuitarCollectible : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 1;
    private string pickupID;

    private void Awake()
    {
        pickupID = $"{gameObject.scene.name}_{transform.position}";
    }

    private void Start()
    {
        
        if (PickupManager.IsCollected(pickupID))
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupManager.Collect(pickupID);
            ScoreManager.instance.AddGuitarScore(scoreAmount);
            Destroy(gameObject);
        }
    }
}
