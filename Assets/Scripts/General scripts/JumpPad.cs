using UnityEditor.Callbacks;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField]private int launchforce=3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
