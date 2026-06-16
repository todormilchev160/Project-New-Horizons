
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField] private float  followSpeed=0.3f;
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y+3,transform.position.z);
        transform.position=Vector3.Lerp(transform.position,targetPosition,followSpeed*Time.deltaTime);   
    }
}
