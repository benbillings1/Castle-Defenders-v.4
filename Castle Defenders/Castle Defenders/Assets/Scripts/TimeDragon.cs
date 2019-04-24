using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDragon : MonoBehaviour
{
    public Transform target;
    public float dragonRange;
    public Transform dragonRotate;
    public float rotationSpeed = 10f;
    public AudioClip slowSound;


    void Start()
    {
        dragonRange = 25f;
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

            if (closestEnemy.GetComponent<dragonmovement>().isSlow == false)
            {
                target = closestEnemy.transform;
                closestEnemy.GetComponent<dragonmovement>().moveSpeed -= 5f;
                GetComponent<AudioSource>().PlayOneShot(slowSound);
                closestEnemy.GetComponent<dragonmovement>().isSlow = true;
            }
            else
            {
                return;
            }

        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, dragonRange);
    }
}
