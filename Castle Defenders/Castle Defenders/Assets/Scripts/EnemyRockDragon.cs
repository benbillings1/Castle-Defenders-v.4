using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRockDragon : MonoBehaviour
{
    private float startHealth = 120f;
    private int loot = 50;

    public float damage = 20f;
    public float health;
    public Image healthBar;

    private void Start()
    {
        health = startHealth;
        healthBar.fillAmount = 1;
    }

    public void TakeBombDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0f)
        {

            Currency.gold += loot;
            gameObject.SetActive(false);
            Destroy(gameObject);

        }


    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0f)
        {

            Currency.gold += loot;
            gameObject.SetActive(false);
            Destroy(gameObject);

        }


    }

}
