using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.GetComponent<Stats>() != null)
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
        }
    }
}
