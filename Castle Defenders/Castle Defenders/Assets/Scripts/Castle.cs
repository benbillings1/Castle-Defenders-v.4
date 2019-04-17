using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    private float startHealth = 100f;

    public float health;

    public Image healthBar;
    public Transform endNode;


    private void Start()
    {
        health = startHealth;
    }

    public void Update()
    {
        if (health <= 0f)
            Destroy(gameObject);
    }


    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(other.gameObject.GetComponent<EnemyDragon>().damage * Time.deltaTime * .1f);
            
        }
        
    }    
}
