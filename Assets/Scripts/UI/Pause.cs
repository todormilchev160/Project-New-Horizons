using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenuUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
       Time.timeScale=0f;
       pauseMenuUI.SetActive(true); 
    }
    public void UnPause()
    {
        Time.timeScale=1f;
        pauseMenuUI.SetActive(false);
    }
}
