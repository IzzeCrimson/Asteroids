using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [Space]
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] GameObject asteroid;


    GameObject movingObject;
    Vector3 SpawnPositoin;

    [Space]
    [SerializeField] float asteroidSpawnerCooldown = 5;

    bool canSpawnAsteroid;
    MoveAsteroid moveAsteroid;

    [Space]
    public bool shootAsteroidsUp;
    public bool shootAsteroidsDown;
    public bool shootAsteroidsLeft;
    public bool shootAsteroidsRight;

    void Start()
    {
 
        //Debug.Log(boxCollider.size);
        canSpawnAsteroid = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnAsteroid)
        {

            if (shootAsteroidsUp)
            {

                SpawnPositoin.z = boxCollider.transform.position.z + Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);
                SpawnPositoin.x = boxCollider.transform.position.x;

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                moveAsteroid = movingObject.GetComponent<MoveAsteroid>();
                moveAsteroid.spawner = this;

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsDown)
            {

                SpawnPositoin.z = boxCollider.transform.position.z + Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);
                SpawnPositoin.x = boxCollider.transform.position.x;

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                moveAsteroid = movingObject.GetComponent<MoveAsteroid>();
                moveAsteroid.spawner = this;

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsLeft)
            {

                SpawnPositoin.x = boxCollider.transform.position.x + Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);
                SpawnPositoin.z = boxCollider.transform.position.z;

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                moveAsteroid = movingObject.GetComponent<MoveAsteroid>();
                moveAsteroid.spawner = this;

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsRight)
            {

                SpawnPositoin.x = boxCollider.transform.position.x + Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);
                SpawnPositoin.z = boxCollider.transform.position.z;

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                moveAsteroid = movingObject.GetComponent<MoveAsteroid>();
                moveAsteroid.spawner = this;

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

    private void OnTriggerEnter(Collider other)
    {
        MoveAsteroid asteroidMovement;
        if (other.tag == "Asteroid")
        {
            
            asteroidMovement = other.GetComponent<MoveAsteroid>();
            Debug.Log("ass");
            Destroy(other);
            //if (shootAsteroidsUp)
            //{

            //    if (!asteroidMovement.spawner.shootAsteroidsUp)
            //    {
            //        Destroy(other);
            //    }

            //}
            //else if (shootAsteroidsDown)
            //{

            //    if (!asteroidMovement.spawner.shootAsteroidsDown)
            //    {
            //        Destroy(other);
            //    }

            //}
            //else if (shootAsteroidsLeft)
            //{

            //    if (!asteroidMovement.spawner.shootAsteroidsLeft)
            //    {
            //        Destroy(other);
            //    }

            //}
            //else if (shootAsteroidsRight)
            //{

            //    if (!asteroidMovement.spawner.shootAsteroidsRight)
            //    {
            //        Destroy(other);
            //    }

            //}
        }
    }
}
