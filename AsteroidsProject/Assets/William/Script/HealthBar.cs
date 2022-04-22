using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text maxHp;
    public Text currentHp;
    public void HealthBarAwake(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        maxHp.text = health.ToString();
        currentHp.text = health.ToString();
    }

    public void SetMaxHealthValue(float maxHealth, float currentHealth)
    {
        slider.maxValue = maxHealth;
        maxHp.text = maxHealth.ToString();
        SetHealthValue(currentHealth);
    }

    public void SetHealthValue(float health)
    {
        slider.value = health;
        currentHp.text = health.ToString();
    }
}
