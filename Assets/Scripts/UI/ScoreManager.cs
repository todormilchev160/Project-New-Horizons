using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;
using FMOD;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private static float drumscore=0;
    private static float guitarscore=0;
    private static float productionscore=0;
    private static float keyboardscore=0;
    [SerializeField]private int maxDrumscore;
    [SerializeField]private int maxGuitarscore;
    [SerializeField]private int maxProductionscore;
    [SerializeField]private int maxKeyboardscore;
    [SerializeField]private Image drumBar;
    [SerializeField]private Image guitarBar;
    [SerializeField]private Image productionBar;
    [SerializeField]private Image keyboardBar;
    [SerializeField]private float pickupsToUnlockSoundtrack;
    [SerializeField]public EventReference soundtrackEvent;
    private EventInstance soundtrack;
    void Awake()
    {
        instance=this;
    }

    void Start()
    {
        soundtrack = RuntimeManager.CreateInstance(soundtrackEvent);
        soundtrack.start();
    }
    void Update()
    {

    }

    public void AddDrumScore(int amount)
    {
        drumscore += amount;
        UpdateDrumScore();
        if(drumscore==pickupsToUnlockSoundtrack)
        {
            soundtrack.setParameterByName("Timing",1);
        }
        if(drumscore==pickupsToUnlockSoundtrack*2)
        {
            soundtrack.setParameterByName("Timing",2);
        }
        if(drumscore==pickupsToUnlockSoundtrack*3)
        {
            soundtrack.setParameterByName("Timing",3);
        }
        if(drumscore==pickupsToUnlockSoundtrack*4)
        {
            soundtrack.setParameterByName("Timing",4);
        }
         
    }
    public void AddGuitarScore(int amount)
    {
        guitarscore+=amount;
        UpdateGuitarScore();
        if(guitarscore==pickupsToUnlockSoundtrack)
        {
            soundtrack.setParameterByName("Timing",5);
        }
        if(guitarscore==pickupsToUnlockSoundtrack*2)
        {
            soundtrack.setParameterByName("Timing",6);
        }
        if(guitarscore==pickupsToUnlockSoundtrack*3)
        {
            soundtrack.setParameterByName("Timing",7);
        }
        if(guitarscore==pickupsToUnlockSoundtrack*4)
        {
            soundtrack.setParameterByName("Timing",8);
        }
    }
    public void AddKeyboardScore(int amount)
    {
        keyboardscore += amount;
        UpdateKeyboardScore();
        if(keyboardscore==pickupsToUnlockSoundtrack)
        {
            soundtrack.setParameterByName("Timing",9);
        }
        if(keyboardscore==pickupsToUnlockSoundtrack*2)
        {
            soundtrack.setParameterByName("Timing",10);
        }
        if(keyboardscore==pickupsToUnlockSoundtrack*3)
        {
            soundtrack.setParameterByName("Timing",11);
        }
        if(keyboardscore==pickupsToUnlockSoundtrack*4)
        {
            soundtrack.setParameterByName("Timing",12);
        }
    }
    public void AddProductionScore(int amount)
    {
        productionscore+=amount;
        UpdateProductionScore();
        if(productionscore==pickupsToUnlockSoundtrack)
        {
            soundtrack.setParameterByName("Timing",13);
        }
        if(productionscore==pickupsToUnlockSoundtrack*2)
        {
            soundtrack.setParameterByName("Timing",14);
        }
        if(productionscore==pickupsToUnlockSoundtrack*3)
        {
            soundtrack.setParameterByName("Timing",15);
        }
        if(productionscore==pickupsToUnlockSoundtrack*4)
        {
            soundtrack.setParameterByName("Timing",16);
        }

    }
    public void UpdateDrumScore()
    {
        drumBar.fillAmount=(float)drumscore/maxDrumscore;
    }
    public void UpdateGuitarScore()
    {
        guitarBar.fillAmount=(float)guitarscore/maxGuitarscore;
    }
    public void UpdateKeyboardScore()

    {
        keyboardBar.fillAmount=(float)keyboardscore/maxKeyboardscore;
    }
    public void UpdateProductionScore()
    {
         productionBar.fillAmount=(float)productionscore/maxProductionscore;
    }

    public void LoseScore(float amount)
    {
        if(drumscore!=0)
        {
            drumscore-=amount;
        }
        if(guitarscore!=0)
        {
            guitarscore-=amount;
        }
        if(keyboardscore!=0)
        {
            keyboardscore-=amount;
        }
        if(productionscore!=0)
        {
            productionscore-=amount;
        }
    }
    void OnDestroy()
    {
        soundtrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        soundtrack.release();
    }
}