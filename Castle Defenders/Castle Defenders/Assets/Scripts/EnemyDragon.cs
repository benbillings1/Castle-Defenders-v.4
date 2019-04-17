using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDragon : MonoBehaviour
{
    private float startHealth = 100f;

    public float damage = 10f;
    public float health;
    public Image healthBar;
  


    private void Start()
    {
        health = startHealth;
        healthBar.fillAmount = 1;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0f)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }


    }

    
    

}
