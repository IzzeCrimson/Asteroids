using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DifficultyIncrease : MonoBehaviour
{
    public Text timer;
    public bool timerActive;
    [SerializeField] GameObject asteroid;
    float timePassed;

    public int difficultyScaling = 1;
    public int howManyMinutesToIncreaseScaling = 2;

    public int asteroidHealthIncreasePerLevel = 10;
    int scalingTimeHolder;

    public int asteroidStartHealth = 50;

    Stats asteroidStats;

    void Start()
    {

        scalingTimeHolder = howManyMinutesToIncreaseScaling;
        asteroidStats = asteroid.GetComponent<Stats>();

        asteroidStats.maxHealth = asteroidStartHealth;

    }

    // Update is called once per frame
    void Update()
    {

        if (timerActive)
        {

            timePassed += Time.deltaTime;

            string minutes = ((int)timePassed / 60).ToString();
            string seconds = (timePassed - 60 * ((int)timePassed / 60)).ToString();

            timer.text = minutes + ":" + seconds;

            if (((int)timePassed / 60) >= howManyMinutesToIncreaseScaling)
            {

                difficultyScaling = difficultyScaling + 1;
                howManyMinutesToIncreaseScaling = howManyMinutesToIncreaseScaling + scalingTimeHolder;
                asteroidStats.maxHealth = asteroidStats.maxHealth + asteroidHealthIncreasePerLevel;
                
            }
        }


    }
}
