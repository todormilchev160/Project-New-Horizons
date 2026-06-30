using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public static bool hasCheckpoint = false;
    public static Vector3 savedCheckpointPosition;

    private void Start()
    {
        if (hasCheckpoint)
        {
            transform.position = savedCheckpointPosition;
        }
        else
        {
            savedCheckpointPosition = transform.position;
        }
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        hasCheckpoint = true;
        savedCheckpointPosition = checkpointPosition;
    }
}
