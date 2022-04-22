using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DifficultyIncrease : MonoBehaviour
{
    public Text timer;
    public bool timerActive;
    [SerializeField] GameObject asteroid;
    public float timePassed;

    [SerializeField] public static bool isGamePaused;
    float roundedValue;

    public int difficultyScaling = 1;
    public float howManyMinutesToIncreaseScaling = 1;

    public int asteroidHealthIncreasePerLevel = 10;
    int scalingTimeHolder;

    public int asteroidStartHealth = 50;

    Stats asteroidStats;

    private void Awake()
    {
        isGamePaused = false;
    }

    void Start()
    {

        scalingTimeHolder = (int)howManyMinutesToIncreaseScaling;
        asteroidStats = asteroid.GetComponent<Stats>();

        asteroidStats.maxHealth = asteroidStartHealth;

    }

    // Update is called once per frame
    void Update()
    {

        if (!isGamePaused)
        {

            timePassed += Time.deltaTime;

            string minutes = ((int)timePassed / 60).ToString();
            roundedValue = Mathf.Round((timePassed - 60 * ((int)timePassed / 60)) * 10.0f) * 0.1f;
            string seconds = roundedValue.ToString();

            timer.text = minutes + ":" + seconds;

            if (((int)timePassed / 60) >= howManyMinutesToIncreaseScaling)
            {

                difficultyScaling = difficultyScaling + 1;
                howManyMinutesToIncreaseScaling = howManyMinutesToIncreaseScaling + scalingTimeHolder;
                asteroidStats.maxHealth = asteroidStats.maxHealth + asteroidHealthIncreasePerLevel;

                isGamePaused = true;
                
            }
        }


    }
}
