using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Health targetHealth; 

    void OnEnable()
    {
        if (targetHealth != null)
        {
            targetHealth.OnHealthChanged += UpdateHealthBar;
        }
    }

    void OnDisable()
    {
        if (targetHealth != null)
        {
            targetHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }

    void Start()
    {
        if (targetHealth != null)
        {
            UpdateHealthBar(targetHealth.GetCurrentHealth(), targetHealth.GetMaxHealth());
        }
    }

    private void UpdateHealthBar(int current, int max)
    {
        slider.maxValue = max;
        slider.value = current;
    }
}