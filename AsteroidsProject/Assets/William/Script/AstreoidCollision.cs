using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidCollision : MonoBehaviour
{
    CollisionScript collisionScript;

    Health healthScript;
    HealthBar healthBar;

    Stats astreoidStats;
    Stats colliderStats;
    float astreoidHealth;
    float colliderHealth;
    bool isAstreoidDestroyed;
    bool isColliderDestroyed;

    private void Awake()
    {
        collisionScript = GetComponent<CollisionScript>();
        astreoidStats = GetComponent<Stats>();
        healthScript = GetComponent<Health>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Projectile") || other.CompareTag("Player"))
        {

            //Debug.Log("Yo");

            if (other.GetComponent<Stats>() != null)
            {

                colliderStats = other.GetComponent<Stats>();

                astreoidHealth = astreoidStats.currentHealth - colliderStats.currentHealth;
                colliderHealth = colliderStats.currentHealth - astreoidStats.currentHealth;

                isAstreoidDestroyed = healthScript.DeathCheck(this.gameObject, astreoidHealth);
                isColliderDestroyed = healthScript.DeathCheck(other.gameObject, colliderHealth);

                if (!isAstreoidDestroyed)
                {
                    astreoidStats.currentHealth = astreoidHealth;
                }

                if (!isColliderDestroyed)
                {
                    colliderStats.currentHealth = colliderHealth;
                }

                if (other.GetComponent<HealthBar>() != null)
                {

                    healthBar = other.GetComponent<HealthBar>();
                    healthBar.SetHealthValue(colliderStats.currentHealth);
                }


            }

            //else if (other.CompareTag("SpecialAttack"))
            //{
            //    Debug.Log("Yo");
            //    Destroy(gameObject);
            //}

        }

    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.CompareTag("Projectile") || other.CompareTag("Player"))
    //    {
    //        collisionScript.DealDamageOnCollision(other);
    //    }

    //}
}
