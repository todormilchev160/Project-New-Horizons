using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

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
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
  
    }
    void Update()
    {
        Debug.Log(drumscore);
         guitarBar.fillAmount=(float)guitarscore/maxGuitarscore;
         drumBar.fillAmount=(float)drumscore/maxDrumscore;
         keyboardBar.fillAmount=(float)keyboardscore/maxKeyboardscore;
         productionBar.fillAmount=(float)productionscore/maxProductionscore;
         
    }

    public void AddDrumScore(int amount)
    {
        drumscore += amount;
         
    }
    public void AddGuitarScore(int amount)
    {
        guitarscore+=amount;
        
    }
    public void AddKeyboardScore(int amount)
    {
        keyboardscore += amount;
     
    }
    public void AddProductionScore(int amount)
    {
        productionscore+=amount;

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
}