using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private Image[] scoreBars;
    [SerializeField] private int pointsPerBar = 10;

  
    private int drumscore=0;
    private int guitarscore=0;
    private int productionscore=0;
    private int keyboardscore;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
  
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

}