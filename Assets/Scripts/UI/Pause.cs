using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenuUI;
    [SerializeField]private PlayerAttack player;
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
       player.GetComponent<PlayerAttack>().enabled=false;
    }
    public void UnPause()
    {
        player.GetComponent<PlayerAttack>().enabled=false;
        Time.timeScale=1f;
        pauseMenuUI.SetActive(false);
    }
}
