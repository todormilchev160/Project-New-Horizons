using UnityEngine;
using UnityEngine.UI;

public class PauseMenuPanelsManager : MonoBehaviour
{
    public GameObject positionCheck;
    public GameObject volumePanel;
    private Quaternion volumePanelRotation = Quaternion.Euler(0, 0, -40f);
    private Quaternion resumePanelRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion restartPanelRotation = Quaternion.Euler(0, 0, -80f);
    private Quaternion exitPanelRotation = Quaternion.Euler(0, 0, -120f);
    public UnityEngine.UI.Image resumeImage;
    public UnityEngine.UI.Image volumeImage;
    public UnityEngine.UI.Image restartImage;
    public UnityEngine.UI.Image exitImage;
    // Update is called once per frame
    void Update()
    {
        if (positionCheck.transform.rotation == volumePanelRotation)
        {
            volumePanel.SetActive(true);
            volumeImage.GetComponent<Image>().color = new Color32(233, 45, 142, 255);
        }
        else
        {
            volumePanel.SetActive(false);
            volumeImage.GetComponent<Image>().color = new Color32(232, 213, 46, 255);
        }

        if (positionCheck.transform.rotation == resumePanelRotation)
        {
            resumeImage.GetComponent<Image>().color = new Color32(233, 45, 142, 255);
        }
        else
        {
            resumeImage.GetComponent<Image>().color = new Color32(232, 213, 46, 255);
        }

        if (positionCheck.transform.rotation == restartPanelRotation)
        {
            restartImage.GetComponent<Image>().color = new Color32(233, 45, 142, 255);
        }
        else
        {
            restartImage.GetComponent<Image>().color = new Color32(232, 213, 46, 255);
        }
        
        if (positionCheck.transform.rotation == exitPanelRotation)
        {
            exitImage.GetComponent<Image>().color = new Color32(233, 45, 142, 255);
        }
        else
        {
            exitImage.GetComponent<Image>().color = new Color32(232, 213, 46, 255);
        }
    }
}
