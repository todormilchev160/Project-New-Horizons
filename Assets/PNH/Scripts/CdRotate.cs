using UnityEngine;

public class CdRotate : MonoBehaviour
{
    public GameObject cd;
    public float zRotation = 0f;
    public void DownRotate()
    {
        cd.transform.Rotate(0, 0, -zRotation);
    }
    public void UpRotate()
    {
        cd.transform.Rotate(0, 0, zRotation);
    }
}
