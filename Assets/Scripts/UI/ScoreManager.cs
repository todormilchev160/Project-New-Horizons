using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TMP_Text scoreText;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text="Score: "+score;
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}