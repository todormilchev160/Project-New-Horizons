using UnityEditor.Callbacks;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField]private int launchforce=3;
    void OnCollisionEnter(Collision collision)
    {
      Rigidbody rb =collision.gameObject.GetComponent<Rigidbody>();
            rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            launchforce,
            rb.linearVelocity.z
        );

    }
}
