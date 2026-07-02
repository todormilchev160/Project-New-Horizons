using UnityEngine;

public class RotateDrum : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject model;
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        model.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}