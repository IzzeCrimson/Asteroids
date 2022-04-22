using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    MyInputManager myInputManager;
    bool isMenuActive;
    [SerializeField] GameObject inGameMenu;
    Scene currentScene;

    private void Awake()
    {
        myInputManager = new MyInputManager();
        isMenuActive = false;
        currentScene = SceneManager.GetActiveScene();
    }


    void Update()
    {

        if (currentScene.name == "WilliamScene" && myInputManager.PlayerController.OpenMenu.triggered)
        {
            isMenuActive = !isMenuActive;
            //inGameMenu.SetActive(isMenuActive);
            Debug.Log("Hi");
        }

        //if (isMenuActive)
        //{
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}
    }

    private void OnEnable()
    {

        myInputManager.PlayerController.Enable();

    }

    private void OnDisable()
    {

        myInputManager.PlayerController.Disable();

    }
}
