using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]private GameObject secondCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwicthCamera()
    {
        if(secondCamera.activeInHierarchy)
        {
            secondCamera.SetActive(false);
        }
        else
        {
            secondCamera.SetActive(true);
        }
    }
}
