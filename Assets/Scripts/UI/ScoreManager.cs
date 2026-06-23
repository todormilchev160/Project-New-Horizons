using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private Image[] scoreBars;
    [SerializeField] private int pointsPerBar = 10;

    private int score = 0;
    public static int barToFill;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateBars();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateBars();
    }

    private void UpdateBars()
    {
            int scoreForThisBar = score - (barToFill * pointsPerBar);

            float fill = Mathf.Clamp01((float)scoreForThisBar / pointsPerBar);

            scoreBars[barToFill].fillAmount = fill;
    }
}