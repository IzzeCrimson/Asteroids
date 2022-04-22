using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSplit : MonoBehaviour
{
   
    [SerializeField] GameObject astroidPrefab;
    RandomSize asteroidSize;

    public float minSizeToSplit = 3;

    public float minAsteroidsSpawned;
    public float maxAsteroidsSpawned;

    private void Start()
    {

        

    }

    //när astreoiden dör ska metoden köras
    //bör man lägga till min och max asteroider som man får välja här
    public void AsteroidSplit(GameObject asteroidToSplit)
    {

        //får hur stor asteroiden är
        asteroidSize = asteroidToSplit.GetComponent<RandomSize>();

        //tittar ifall asteroiden är nog stor för att splitas till fler mindre asteroider
        float asteroidsSpawned;
        if (asteroidSize.sizeHolder > minSizeToSplit)
        {

            //hur många man ska spawna
            asteroidsSpawned = Random.Range(minAsteroidsSpawned, maxAsteroidsSpawned);

            //Ser till att astreoiderna är hälften så stora
            astroidPrefab.transform.localScale = asteroidToSplit.transform.localScale / 2;

            //skapar asteroider
            for (int i = 0; i < asteroidsSpawned; i++)
            {
                MoveAsteroid moveAsteroid;
                GameObject asteroidSpawned;
                asteroidSpawned = Instantiate(astroidPrefab, asteroidToSplit.transform.position, Quaternion.identity, asteroidToSplit.transform);
                moveAsteroid = asteroidSpawned.GetComponent<MoveAsteroid>();

                //ifall man vill få powerups från astreoider lägg till här

                //checkar åt vilket håll asteroiden man skapar ska åka
                int randomNumber;
                randomNumber = Random.Range(1,4);
                if (randomNumber == 1)
                {
                    moveAsteroid.up = true;
                }
                else if (randomNumber == 2)
                {
                    moveAsteroid.down = true;
                }
                else if (randomNumber == 3)
                {
                    moveAsteroid.right = true;
                }
                else
                {
                    moveAsteroid.left = true;
                }


            }

        }

    }
}
