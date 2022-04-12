using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public float ReciveDamage(GameObject target, float health, float damageRecived)
    {

        health = health - damageRecived;

        DeathCheck(target, health);

        return health;


    }

    public void DeathCheck(GameObject objectToDestroy, float health)
    {

        if (health <= 0)
        {

            Destroy(objectToDestroy);

        }


    }


}
