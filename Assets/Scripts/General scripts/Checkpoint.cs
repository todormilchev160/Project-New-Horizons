using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();

        if (playerRespawn != null)
        {
            Vector3 pointToSave = respawnPoint != null
                ? respawnPoint.position
                : transform.position;

            playerRespawn.SetCheckpoint(pointToSave);

            Debug.Log("Checkpoint saved");
        }
    }
}