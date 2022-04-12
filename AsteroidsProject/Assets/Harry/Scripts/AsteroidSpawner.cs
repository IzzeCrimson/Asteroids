using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] GameObject asteroid;

    GameObject movingObject;
    Vector3 SpawnPositoin;
    float asteroidSpawnerCooldown = 5;

    bool canSpawnAsteroid;

    [SerializeField] bool shootAsteroidsUp;
    [SerializeField] bool shootAsteroidsDown;
    [SerializeField] bool shootAsteroidsLeft;
    [SerializeField] bool shootAsteroidsRight;

    void Start()
    {
 
        Debug.Log(boxCollider.size);
        canSpawnAsteroid = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnAsteroid)
        {

            if (shootAsteroidsUp)
            {

                SpawnPositoin.x = Random.Range(-boxCollider.size.x / 2, boxCollider.size.x / 2);

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);

                movingObject.transform.Translate(new Vector3(2,0,0), Space.Self);

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsDown)
            {

                SpawnPositoin.x = Random.Range(-boxCollider.size.x / 2, boxCollider.size.x / 2);

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                movingObject.transform.position = movingObject.transform.position * Time.deltaTime;

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsLeft)
            {

                SpawnPositoin.x = Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                movingObject.transform.position = movingObject.transform.position * Time.deltaTime;

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsRight)
            {

                SpawnPositoin.x = Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position,new Vector3(100,2,100),10); 

                canSpawnAsteroid = false;

            }

            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(asteroidSpawnerCooldown);

        canSpawnAsteroid = true;
    }     
}
