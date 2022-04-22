using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    Stats stats;
    HealthBar healthBar;
    PlayerMovement playerMovement;

    public int itemCost;
    public bool attackSpeed;
    public bool movementSpeed;
    public bool increaseMaxHealth;
    public bool heal;
    public bool secondaryAttackCharge;

    public float attackSpeedIncrease;
    public float movementSpeedIncrease;
    public float maxHealthIncrease;
    public float healAmount;
    public int rechargeAmount;


    private void Awake()
    {
        
    }

    private void Update()
    {
        if (!DoorScript.isPlayerInShop)
        {

            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            stats = other.GetComponent<Stats>();
            healthBar = other.GetComponent<HealthBar>();
            playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement.currency >= itemCost)
            {

                if (attackSpeed)
                {
                    stats.attackSpeed += attackSpeedIncrease;
                }

                if (movementSpeed)
                {
                    stats.movementSpeed += movementSpeedIncrease;
                }

                if (increaseMaxHealth)
                {
                    stats.maxHealth += maxHealthIncrease;
                    stats.currentHealth += maxHealthIncrease;
                    healthBar.SetMaxHealthValue(stats.maxHealth, stats.currentHealth);
                }

                if (heal)
                {

                    stats.currentHealth += healAmount;

                    if (stats.currentHealth > stats.maxHealth)
                    {
                        stats.currentHealth = stats.maxHealth;
                    }

                    healthBar.SetHealthValue(stats.currentHealth);

                }

                if (secondaryAttackCharge)
                {

                    playerMovement.specialCharges += rechargeAmount;
                    playerMovement.specialAttackText.text = playerMovement.specialCharges.ToString();

                }

                playerMovement.currency -= itemCost;

                Destroy(gameObject);

            }


        }


    }

}
