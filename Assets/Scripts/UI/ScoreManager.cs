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
    }

    public void AddDrumScore(int amount)
    {
        drumscore += amount;
         UpdateDrumBar();
    }
    public void AddGuitarScore(int amount)
    {
        guitarscore+=amount;
        UpdateGuitarBar();
    }
    public void AddKeyboardScore(int amount)
    {
        keyboardscore += amount;
        UpdateKeyboardBar();
    }
    public void AddProductionScore(int amount)
    {
        productionscore+=amount;
        UpdateProductionBar();
    }
    public void UpdateDrumBar()
    {
        Debug.Log("update");
        drumBar.fillAmount=(float)drumscore/maxDrumscore;
    }
    public void UpdateGuitarBar()
    {
        guitarBar.fillAmount=(float)guitarscore/maxGuitarscore;
    }
     public void UpdateKeyboardBar()
    {
        keyboardBar.fillAmount=(float)keyboardscore/maxKeyboardscore;
    }
    public void UpdateProductionBar()
    {
        productionBar.fillAmount=(float)productionscore/maxProductionscore;
    }
}