using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    HealthBar healthBar;

    public float maxHealth;
    public float currentHealth;
    public float movementSpeed;
    public float attackSpeed;
    public float size;
    public float rotationSpeed;

    private void Awake()
    {
        currentHealth = maxHealth;

        if (gameObject.GetComponent<HealthBar>() != null)
        {

            healthBar = gameObject.GetComponent<HealthBar>();
            healthBar.HealthBarAwake(maxHealth);

        }


    }

}
