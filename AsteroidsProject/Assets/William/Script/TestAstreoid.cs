using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAstreoid : MonoBehaviour
{

    CollisionScript collisionScript;

    Health healthScript;

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


            }

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
