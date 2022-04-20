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

    //n�r astreoiden d�r ska metoden k�ras
    //b�r man l�gga till min och max asteroider som man f�r v�lja h�r
    public void AsteroidSplit(GameObject asteroidToSplit)
    {

        //f�r hur stor asteroiden �r
        asteroidSize = asteroidToSplit.GetComponent<RandomSize>();

        //tittar ifall asteroiden �r nog stor f�r att splitas till fler mindre asteroider
        float asteroidsSpawned;
        if (asteroidSize.sizeHolder > minSizeToSplit)
        {

            //hur m�nga man ska spawna
            asteroidsSpawned = Random.Range(minAsteroidsSpawned, maxAsteroidsSpawned);

            //Ser till att astreoiderna �r h�lften s� stora
            astroidPrefab.transform.localScale = asteroidToSplit.transform.localScale / 2;

            //skapar asteroider
            for (int i = 0; i < asteroidsSpawned; i++)
            {
                MoveAsteroid moveAsteroid;
                GameObject asteroidSpawned;
                asteroidSpawned = Instantiate(astroidPrefab, asteroidToSplit.transform.position, Quaternion.identity, asteroidToSplit.transform);
                moveAsteroid = asteroidSpawned.GetComponent<MoveAsteroid>();

                //ifall man vill f� powerups fr�n astreoider l�gg till h�r

                //checkar �t vilket h�ll asteroiden man skapar ska �ka
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
