using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject platform;
    public static bool isPlayerInShop;
    float teleportDistance;
    Vector3 newPlayerPosition;
    Vector3 newCameraPsoition;

    private void Awake()
    {
        isPlayerInShop = false;
        teleportDistance = 150;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            newPlayerPosition = player.transform.position;
            newCameraPsoition = playerCamera.transform.position;

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

                newPlayerPosition.x += teleportDistance;
                newPlayerPosition.z += platform.transform.lossyScale.z - 2.5f;
                player.transform.position = newPlayerPosition;

                newCameraPsoition.x += teleportDistance;
                playerCamera.transform.position = newCameraPsoition;

                isPlayerInShop = true;

            }
            else
            {

            
                newPlayerPosition.x -= teleportDistance;
                newPlayerPosition.z -= platform.transform.lossyScale.z - 2.5f;
                player.transform.position = newPlayerPosition;

                newCameraPsoition.x -= teleportDistance;
                playerCamera.transform.position = newCameraPsoition;

                isPlayerInShop = false;
            }

            

            //teleportDistance = teleportDistance * -1;
            //isPlayerInShop = !isPlayerInShop;

        }


    }


}
