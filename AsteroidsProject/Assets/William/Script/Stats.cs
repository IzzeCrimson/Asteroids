using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public float movementSpeed;
    public float attackSpeed;
    public float size;
    public float rotationSpeed;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

}
