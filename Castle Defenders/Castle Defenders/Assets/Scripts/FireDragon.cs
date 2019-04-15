using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireDragon : MonoBehaviour
{
    public int fireDamage = 10;
    public int health = 100;
    private EnemyDragon enemyDragon;


    void Start()
    {
        GameObject enemyDragonObject = GameObject.FindWithTag("Enemy");

        if (enemyDragonObject != null)
        {
            enemyDragon = enemyDragonObject.GetComponent<EnemyDragon>();
        }
        if (enemyDragonObject == null)
        {
            Debug.Log("Cannot find 'EnemyDragon' script");
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        transform.LookAt(other.transform);
        if (other.CompareTag("Enemy"))
        {
            enemyDragon.TakeDamage(fireDamage);
        }
        

    }
    
        
   
    
}
