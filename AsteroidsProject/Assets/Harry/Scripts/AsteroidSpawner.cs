using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] GameObject asteroid;


    GameObject movingObject;
    public Vector3 SpawnPositoin;
    float asteroidSpawnerCooldown = 5;

    bool canSpawnAsteroid;
    MoveAsteroid moveAsteroid;

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

                SpawnPositoin.x = Random.Range(-boxCollider.size.x / 2, boxCollider.size.x / 2);
                SpawnPositoin.z = boxCollider.transform.position.z;

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                moveAsteroid = movingObject.GetComponent<MoveAsteroid>();
                moveAsteroid.spawner = this;

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsDown)
            {

                SpawnPositoin.x = Random.Range(-boxCollider.size.x / 2, boxCollider.size.x / 2);
                SpawnPositoin.z = boxCollider.transform.position.z;

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                moveAsteroid = movingObject.GetComponent<MoveAsteroid>();
                moveAsteroid.spawner = this;

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsLeft)
            {

                SpawnPositoin.x = Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);
                SpawnPositoin.z = boxCollider.transform.position.z;

                movingObject = Instantiate(asteroid, SpawnPositoin, Quaternion.identity, boxCollider.transform);
                moveAsteroid = movingObject.GetComponent<MoveAsteroid>();
                moveAsteroid.spawner = this;

                canSpawnAsteroid = false;

            }
            else if (shootAsteroidsRight)
            {

                SpawnPositoin.x = Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);
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
           
            
            if (shootAsteroidsUp)
            {

                if (!asteroidMovement.spawner.shootAsteroidsUp)
                {
                    Destroy(other);
                }

            }
            else if (shootAsteroidsDown)
            {

                if (!asteroidMovement.spawner.shootAsteroidsDown)
                {
                    Destroy(other);
                }

            }
            else if (shootAsteroidsLeft)
            {

                if (!asteroidMovement.spawner.shootAsteroidsLeft)
                {
                    Destroy(other);
                }

            }
            else if (shootAsteroidsRight)
            {

                if (!asteroidMovement.spawner.shootAsteroidsRight)
                {
                    Destroy(other);
                }

            }
        }
    }
}
