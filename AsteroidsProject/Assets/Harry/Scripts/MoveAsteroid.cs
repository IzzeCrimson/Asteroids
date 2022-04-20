using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    Vector3 movementDicrection;
    Stats stats;
    public AsteroidSpawner spawner;

    [SerializeField] float minMoveSpeed = 1;
    [SerializeField] float maxMoveSpeed = 5;
    [SerializeField] float maxRigth = 2;
    [SerializeField] float maxLeft = 2;


    [HideInInspector] public bool left;
    [HideInInspector] public bool right;
    [HideInInspector] public bool up;
    [HideInInspector] public bool down;

    void Start()
    {
        stats = gameObject.GetComponent<Stats>();
        if (spawner != null)
        {

            if (spawner.shootAsteroidsUp)
            {
                movementDicrection = new Vector3(Random.Range(minMoveSpeed, maxMoveSpeed),0, Random.Range(-maxLeft, maxRigth));
            }
            else if (spawner.shootAsteroidsDown)
            {
                movementDicrection = new Vector3(Random.Range(-maxMoveSpeed, -minMoveSpeed), 0, Random.Range(-maxRigth, maxLeft));
            }
            else if (spawner.shootAsteroidsLeft)
            {
                movementDicrection = new Vector3(Random.Range(-maxLeft, maxRigth), 0,Random.Range(minMoveSpeed, maxMoveSpeed));
            }
            else if (spawner.shootAsteroidsRight)
            {
                movementDicrection = new Vector3(Random.Range(-maxRigth, maxLeft), 0, Random.Range(-maxMoveSpeed, -minMoveSpeed));
            }

        }
        else
        {
            if (up)
            {
                movementDicrection = new Vector3(Random.Range(minMoveSpeed, maxMoveSpeed), 0, Random.Range(-maxLeft, maxRigth));
            }
            else if (down)
            {
                movementDicrection = new Vector3(Random.Range(-maxMoveSpeed, -minMoveSpeed), 0, Random.Range(-maxRigth, maxLeft));
            }
            else if (left)
            {
                movementDicrection = new Vector3(Random.Range(-maxLeft, maxRigth), 0, Random.Range(minMoveSpeed, maxMoveSpeed));
            }
            else if (right)
            {
                movementDicrection = new Vector3(Random.Range(-maxRigth, maxLeft), 0, Random.Range(-maxMoveSpeed, -minMoveSpeed));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementDicrection * stats.movementSpeed * Time.fixedDeltaTime;
    }
}
