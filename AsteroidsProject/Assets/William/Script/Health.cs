using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    
    public float ReciveDamage(GameObject target, float health, float damageRecived)
    {

        health = health - damageRecived;

        //DeathCheck(target, health);

        return health;


    }

    public bool DeathCheck(GameObject objectToDestroy, float health)
    {

        if (health <= 0)
        {
            if (objectToDestroy.CompareTag("Player"))
            {
                SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
            }
            else
            {
                Destroy(objectToDestroy);
                return true;

            }
        }

        return false;

    }


}
