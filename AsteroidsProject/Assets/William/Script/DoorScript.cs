using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject platform;
    [SerializeField] Transform teleportLocation;
    [SerializeField] Transform cameraLocation;
    public static bool isPlayerInShop;
    float teleportDistance;
    Vector3 newPlayerPosition;
    Vector3 shopCamera;
    Vector3 oldCameraPosition;

    private void Awake()
    {
        isPlayerInShop = false;
        teleportDistance = 150;
        //shopCamera = new Vector3(151, 24, 0);
        //oldCameraPosition = new Vector3(0, 43, 0);

        //gameObject.SetActive(DifficultyIncrease.isGamePaused);
    }

    private void Update()
    {
        gameObject.SetActive(DifficultyIncrease.isGamePaused);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            //newPlayerPosition = player.transform.position;
            //shopCamera = playerCamera.transform.position;

            #region ???

            //if (!isPlayerInShop)
            //{
            //    teleportDistance = 150;
            //}

            //if (isPlayerInShop)
            //{
            //    teleportDistance = -150;
            //}
            #endregion
            if (!isPlayerInShop)
            {
                isPlayerInShop = true;

                //newPlayerPosition.x += teleportDistance;
                //newPlayerPosition.z += platform.transform.lossyScale.z - 2.5f;
                //player.transform.position = newPlayerPosition;
                player.transform.position = teleportLocation.position;

                playerCamera.transform.position = cameraLocation.position;


            }
            else
            {
                isPlayerInShop = false;

                //newPlayerPosition.x -= teleportDistance;
                //newPlayerPosition.z -= platform.transform.lossyScale.z - 2.5f;
                //player.transform.position = newPlayerPosition;
                player.transform.position = teleportLocation.position;

                playerCamera.transform.position = cameraLocation.position;

                DifficultyIncrease.isGamePaused = false;

            }

            

            //teleportDistance = teleportDistance * -1;
            //isPlayerInShop = !isPlayerInShop;

        }


    }


}
