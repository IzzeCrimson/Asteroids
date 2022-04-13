using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Stats projectileStats;
    Stats stats;
    Health health;
    

    private void Awake()
    {
        projectileStats = GetComponent<Stats>();

       
    }

    void Update()
    {

        transform.Translate(Vector3.forward * projectileStats.movementSpeed * Time.fixedDeltaTime);
        Debug.Log(projectileStats.currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Asteroid"))
        {
            DealDamageOnCollision(other);
        }

    }


    protected void DealDamageOnCollision(Collider collider)
    {

        float temp;

        if (collider.GetComponent<Health>() != null)
        {

            stats = collider.GetComponent<Stats>();
            health = collider.GetComponent<Health>();

            
            projectileStats.currentHealth = health.ReciveDamage(this.gameObject, projectileStats.currentHealth, stats.currentHealth);
            stats.currentHealth = health.ReciveDamage(collider.gameObject, stats.currentHealth, projectileStats.currentHealth);

            //if (collider.GetComponent<Healtbar>() != null)
            //{
            //    healthbar = collider.GetComponent<Healtbar>();
            //    healthbar.SetHealthValue(stats.currentHealth);
            //}

        }

    }


}
