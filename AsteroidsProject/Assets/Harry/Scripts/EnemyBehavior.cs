using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform castPoint;

    [SerializeField] Stats enemyStats;

    bool withinAttackRange = false;
    bool canAttack = true;

    Quaternion rotation;

    void Start()
    {
        enemyStats = enemy.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!withinAttackRange)
        {

            enemy.transform.position = Vector3.Lerp(enemy.transform.position, player.transform.position, Time.deltaTime * enemyStats.movementSpeed);

        }
        else
        {
            //rotate to player and shoot
            rotation = Quaternion.LookRotation(player.transform.position - enemy.transform.position);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, rotation, Time.deltaTime * enemyStats.rotationSpeed);

            if (canAttack)
            {
                
                Instantiate(projectile, castPoint.transform.position, castPoint.rotation);
                canAttack = false;

                StartCoroutine(Cooldown());

            }

        } 
    }

    IEnumerator Cooldown()
    {

        yield return new WaitForSeconds(5);
        canAttack = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            withinAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            withinAttackRange = false;
        }
    }
}
