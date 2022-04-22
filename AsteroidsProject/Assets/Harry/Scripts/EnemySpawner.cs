using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    static public int howManyEnemysCanSpawn = 4;
    static public int howManyEnemysHaveSpawned;

    public int howManyEnemysCanbeSpawned;
    public int howManyEnemyshaveBeenSpawned;

    public int enemyIncrease;
    public DifficultyIncrease difficulty;
    int difficultyChangeCheck;

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject spawner;

    static float[] enemySpawnArray;
    float lastTimeGoal;
    bool canSpawnEnemy = false;

    int spawnOnceCheck;

    void Start()
    {

        difficultyChangeCheck = difficulty.difficultyScaling;
        enemySpawnArray = new float[howManyEnemysCanSpawn];
        howManyEnemysCanbeSpawned = howManyEnemysCanSpawn;

        lastTimeGoal = 0;
        spawnOnceCheck = 0;

    }


    void Update()
    {
        if (howManyEnemysCanSpawn > howManyEnemysHaveSpawned)
        {

            if (!canSpawnEnemy)
            {

                for (int i = 0; i < enemySpawnArray.Length; i++)
                {
                    enemySpawnArray[i] = Random.Range(lastTimeGoal, difficulty.howManyMinutesToIncreaseScaling * 60);
                    
                }
                
                lastTimeGoal = difficulty.howManyMinutesToIncreaseScaling * 60;
                canSpawnEnemy = true;
            }
            else if (canSpawnEnemy)
            {

                for (int i = spawnOnceCheck; i < enemySpawnArray.Length; i++)
                {

                    if (enemySpawnArray[i] <= difficulty.timePassed)
                    {

                        Instantiate(enemy, spawner.transform.position, Quaternion.identity);
                        howManyEnemysHaveSpawned++;
                        howManyEnemyshaveBeenSpawned = howManyEnemysHaveSpawned;

                        spawnOnceCheck++;

                    }

                }

            }

        }

        if (difficulty.difficultyScaling > difficultyChangeCheck)
        {

            howManyEnemysCanSpawn = howManyEnemysCanSpawn + enemyIncrease;
            howManyEnemysCanbeSpawned = howManyEnemysCanSpawn;
            enemySpawnArray = new float[howManyEnemysCanSpawn];

            howManyEnemysHaveSpawned = 0;
            spawnOnceCheck = 0;

            howManyEnemyshaveBeenSpawned = howManyEnemysHaveSpawned;

            canSpawnEnemy = false;

            difficultyChangeCheck = difficulty.difficultyScaling;

        }
    }
}
