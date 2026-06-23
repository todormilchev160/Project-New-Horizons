using UnityEngine;

public class ProgressbarSwitchtrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ScoreManager.barToFill);
    }
    void OnTriggerEnter()
    {
        ScoreManager.barToFill+=1;
        Destroy(gameObject);
    }
}
