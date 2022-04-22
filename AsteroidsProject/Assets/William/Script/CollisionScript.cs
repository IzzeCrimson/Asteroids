using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    Stats thisObjectStats;
    Stats collisionStats;
    Health health;
    float temp;

    private void Awake()
    {
        thisObjectStats = GetComponent<Stats>();


    }

    public void DealDamageOnCollision(Collider collider)
    {


        if (collider.GetComponent<Health>() != null)
        {

            collisionStats = collider.GetComponent<Stats>();
            health = collider.GetComponent<Health>();



            //projectileStats.currentHealth = health.ReciveDamage(this.gameObject, projectileStats.currentHealth, stats.currentHealth);
            collisionStats.currentHealth = health.ReciveDamage(collider.gameObject, collisionStats.currentHealth, thisObjectStats.currentHealth);
            


            //if (collider.GetComponent<Healtbar>() != null)
            //{
            //    healthbar = collider.GetComponent<Healtbar>();
            //    healthbar.SetHealthValue(stats.currentHealth);
            //}

        }

    }

}
