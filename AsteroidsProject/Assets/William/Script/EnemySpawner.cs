using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    static public int howManyEnemysCanSpawn;
    static public int howManyEnemysHaveSpawned;
    public int enemyIncrease;
    public DifficultyIncrease difficulty;
    int difficultyChangeCheck;

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject spawner;

    float[] enemySpawnArray;
    float lastTimeGoal;
    bool canSpawnEnemy = false;

    void Start()
    {
        difficultyChangeCheck = difficulty.difficultyScaling;
        enemySpawnArray = new float[howManyEnemysCanSpawn];
        lastTimeGoal = 0;

    }


    void Update()
    {
        if (howManyEnemysHaveSpawned >= howManyEnemysCanSpawn)
        {

            if (canSpawnEnemy)
            {

                for (int i = 0; i < enemySpawnArray.Length; i++)
                {
                    enemySpawnArray[i] = Random.Range(lastTimeGoal, difficulty.howManyMinutesToIncreaseScaling);
                }

                lastTimeGoal = difficulty.howManyMinutesToIncreaseScaling;
                canSpawnEnemy = true;
            }
            else if (canSpawnEnemy)
            {

                for (int i = 0; i < enemySpawnArray.Length; i++)
                {

                    if (enemySpawnArray[i] >= difficulty.timePassed)
                    {
                        Instantiate(enemy, spawner.transform.position, Quaternion.identity);
                        howManyEnemysHaveSpawned++;
                    }

                }

            }

        }

        if (difficulty.difficultyScaling > difficultyChangeCheck)
        {

            howManyEnemysCanSpawn = howManyEnemysCanSpawn + enemyIncrease;
            enemySpawnArray = new float[howManyEnemysCanSpawn];

            difficultyChangeCheck = difficulty.difficultyScaling;

        }
    }
}
