using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] GameObject asteroid;
    Transform asteroidSpawnPosition;

    [SerializeField] bool shootAsteroidsUp;
    [SerializeField] bool shootAsteroidsDown;
    [SerializeField] bool shootAsteroidsLeft;
    [SerializeField] bool shootAsteroidsRight;

    void Start()
    {
        asteroidSpawnPosition = boxCollider.transform;
        Debug.Log(boxCollider.size);
        Instantiate(asteroid,new Vector3(2,2,2), Quaternion.identity, boxCollider.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
