using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private Image[] scoreBars;
    [SerializeField] private int pointsPerBar = 10;

    private int score = 0;

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
        for (int i = 0; i < scoreBars.Length; i++)
        {
            int scoreForThisBar = score - (i * pointsPerBar);

            float fill = Mathf.Clamp01((float)scoreForThisBar / pointsPerBar);

            scoreBars[i].fillAmount = fill;
        }
    }
}