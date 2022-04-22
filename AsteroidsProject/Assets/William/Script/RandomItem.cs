using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public GameObject[] items;
    [SerializeField] Transform itemSpawn;
    GameObject clone;
    int randomNumber;
    bool haveAlreadySpawned;

    private void Awake()
    {
        //InstantiateItem();
        haveAlreadySpawned = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (DoorScript.isPlayerInShop && !haveAlreadySpawned)
        {
            InstantiateItem();
        }

        if (!DoorScript.isPlayerInShop)
        {
            haveAlreadySpawned = false;
        }

    }

    void InstantiateItem()
    {

        randomNumber = Random.Range(0, items.Length);
        //Debug.Log(randomNumber);
        Instantiate(items[randomNumber], itemSpawn.position, itemSpawn.rotation);

        haveAlreadySpawned = true;
    }


}
