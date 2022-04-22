using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(!DoorScript.isPlayerInShop);
    }
}
