using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{

    Vector3 expandValue;
    float maximumSize;

    private void Awake()
    {

        expandValue = new Vector3(8, 0, 8);
        maximumSize = 100;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.localScale += expandValue * Time.fixedDeltaTime;

        if (gameObject.transform.localScale.x > maximumSize)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
        }

    }
}
