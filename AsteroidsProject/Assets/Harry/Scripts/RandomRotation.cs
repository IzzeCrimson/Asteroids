 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{

    [SerializeField] Transform objektToRotate;
    Vector3 randomRotation;

    //ändra rotation speed med storhet?
    [SerializeField] float rotationSpeed;

    [SerializeField] float rotationOffset = 100;

    void Start()
    {
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        objektToRotate.Rotate(randomRotation * Time.deltaTime * rotationSpeed);
    }
}
