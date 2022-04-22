using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject musicMenu;

    public void OnPressPlay()
    {

        SceneManager.LoadScene("WilliamScene", LoadSceneMode.Single);

    }

    public void OnPressQuit()
    {

        Application.Quit();
        Debug.Log("Quitting");

    }

    public void OnPressMusic()
    {

        mainMenu.SetActive(false);
        musicMenu.SetActive(true);
    }

    public void OnPressSelect()
    {

        mainMenu.SetActive(true);
        musicMenu.SetActive(false);
    }
}
