using System;
using UnityEngine;

public class DrumCollectible : MonoBehaviour
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
            Debug.Log("pickup");
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupManager.Collect(pickupID);
            ScoreManager.instance.AddDrumScore(scoreAmount);
            Destroy(gameObject);
        }
    }
}
