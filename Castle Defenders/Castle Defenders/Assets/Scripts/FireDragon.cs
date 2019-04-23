using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireDragon : MonoBehaviour
{
    public int fireDamage = 20;
    public int health = 100;
    public Transform target;
    public float dragonRange;
    public Transform dragonRotate;
    public float rotationSpeed = 10f;
    public AudioClip fireSounds;

    //private EnemyDragon enemyDragon;


    void Start()
    {
        //GameObject enemyDragonObject = GameObject.FindWithTag("Enemy");

        //if (enemyDragonObject != null)
        //{
        //enemyDragon = enemyDragonObject.GetComponent<EnemyDragon>();
        //}
        //if (enemyDragonObject == null)
        //{
        // Debug.Log("Cannot find 'EnemyDragon' script");
        //}

        dragonRange = 30f;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(dragonRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        dragonRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void UpdateTarget()
    {
        List<GameObject> enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        List<GameObject> myEnemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rock"));
        enemies.AddRange(myEnemies);
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies) 
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && closestDistance <= dragonRange)
        {
            target = closestEnemy.transform;
            if (closestEnemy.CompareTag("Rock"))
            {
                closestEnemy.GetComponent<EnemyRockDragon>().TakeDamage(fireDamage / 2);
                GetComponent<AudioSource>().PlayOneShot(fireSounds);

            }
            else
            {
                closestEnemy.GetComponent<EnemyDragon>().TakeDamage(fireDamage);
                GetComponent<AudioSource>().PlayOneShot(fireSounds);
            }
                
        }
        else
        {
            target = null;
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
        //if (other.CompareTag("Enemy"))
        //{
            //enemyDragon.TakeDamage(fireDamage);
        //}

        

    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, dragonRange);
    }



}
