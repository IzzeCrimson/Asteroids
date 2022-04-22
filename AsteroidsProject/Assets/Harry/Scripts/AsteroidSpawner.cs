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
    public float asteroidSpawnerCooldown = 5;
    float trueAstroidCooldown;

    bool canSpawnAsteroid;
    MoveAsteroid moveAsteroid;

    [Space]
    public bool shootAsteroidsUp;
    public bool shootAsteroidsDown;
    public bool shootAsteroidsLeft;
    public bool shootAsteroidsRight;

    [Space]
    public DifficultyIncrease difficulty;
    public int difficultyChangeCheck;
    

    void Start()
    {

        difficultyChangeCheck = difficulty.difficultyScaling;
        trueAstroidCooldown = asteroidSpawnerCooldown;
        

        //Debug.Log(boxCollider.size);
        canSpawnAsteroid = true;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (difficulty.difficultyScaling > difficultyChangeCheck)
        {

            asteroidSpawnerCooldown = trueAstroidCooldown - difficulty.difficultyScaling/2;
            difficultyChangeCheck = difficulty.difficultyScaling;

        }

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

   
}
