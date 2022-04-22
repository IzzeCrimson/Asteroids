using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Stats projectileStats;
    Stats stats;
    Health health;
    CollisionScript collisionScript;
    float temp;

    

    private void Awake()
    {
        projectileStats = GetComponent<Stats>();

        collisionScript = GetComponent<CollisionScript>();
    }

    void Update()
    {

        transform.Translate(Vector3.forward * projectileStats.movementSpeed * Time.fixedDeltaTime);
        //Debug.Log(projectileStats.currentHealth);
    }

    #region Old Code

    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.CompareTag("Asteroid"))
    //    {
    //        collisionScript.DealDamageOnCollision(other);
    //    }

    //}



    //protected void DealDamageOnCollision(Collider collider)
    //{

    //    if (collider.GetComponent<Health>() != null)
    //    {

    //        stats = collider.GetComponent<Stats>();
    //        health = collider.GetComponent<Health>();

    //        temp = health.ReciveDamage(this.gameObject, projectileStats.currentHealth, stats.currentHealth);
    //        stats.currentHealth = health.ReciveDamage(collider.gameObject, stats.currentHealth, projectileStats.currentHealth);

    //        projectileStats.currentHealth = temp;


    //        if (collider.GetComponent<Healtbar>() != null)
    //        {
    //            healthbar = collider.GetComponent<Healtbar>();
    //            healthbar.SetHealthValue(stats.currentHealth);
    //        }

    //    }

    //}

    #endregion

}
