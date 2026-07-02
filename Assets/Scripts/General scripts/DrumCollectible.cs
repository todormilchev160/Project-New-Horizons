using System;
using System.Collections;
using UnityEngine;

public class DrumCollectible : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 1;
    [SerializeField]private GameObject collectionFeedback;
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
            StartCoroutine(PickUp());
            PickupManager.Collect(pickupID);
            ScoreManager.instance.AddDrumScore(scoreAmount);
            Destroy(gameObject);
        }
    }
    public IEnumerator PickUp()
    {
        Instantiate(collectionFeedback,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(collectionFeedback);
    }
}
