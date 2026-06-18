using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image fillImage;
    private float maxHealth;

    void Start()
    {
        maxHealth = 100f;
    }
    void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
      fillImage.fillAmount = playerHealth.health / maxHealth;
    }
}