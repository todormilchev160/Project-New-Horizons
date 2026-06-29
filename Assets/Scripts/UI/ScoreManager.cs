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
         
    }

    public void AddDrumScore(int amount)
    {
        drumscore += amount;
        UpdateDrumScore();
         
    }
    public void AddGuitarScore(int amount)
    {
        guitarscore+=amount;
        UpdateGuitarScore();
        
    }
    public void AddKeyboardScore(int amount)
    {
        keyboardscore += amount;
        UpdateKeyboardScore();
    }
    public void AddProductionScore(int amount)
    {
        productionscore+=amount;
        UpdateProductionScore();
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
}