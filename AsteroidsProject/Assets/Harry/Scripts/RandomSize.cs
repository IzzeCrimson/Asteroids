using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSize : MonoBehaviour
{
    public Transform ownerOfSize;
    public float minSize;
    public float maxSize;

    // Start is called before the first frame update
    void Start()
    {
        float sizeHolder;
        Vector3 size = transform.position;


        sizeHolder = Random.Range(minSize, maxSize);

        size.x = sizeHolder;
        size.y = sizeHolder;
        size.z = sizeHolder;

        ownerOfSize.localScale = size;
    }

}
