using System;
using UnityEngine;
using System.Collections;
public class GuitarCollectible : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 1;
    private string pickupID;
    [SerializeField]private GameObject collectionFeedback;

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
            ScoreManager.instance.AddGuitarScore(scoreAmount);
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
