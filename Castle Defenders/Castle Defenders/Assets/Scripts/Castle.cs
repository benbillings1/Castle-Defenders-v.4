using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    private float startHealth = 100f;

    public float health;

    public Image healthBar;
    public Transform endNode;
    public GameObject gameOver;
    public GameObject startMessage;

    private bool dead = false;


    private void Start()
    {
        health = startHealth;
        gameOver.SetActive(false);
        StartCoroutine(spawnStartMessage());
    }

    public void Update()
    {
        if (health <= 0f && !dead)
        {
            dead = true;
            StartCoroutine(spawnGameOver());


        }



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
        else
        {
            TakeDamage(other.gameObject.GetComponent<EnemyRockDragon>().damage * Time.deltaTime * .1f);
        }

    }

    public void MakeActive(GameObject text)
    {
        text.SetActive(true);
    }

    IEnumerator spawnGameOver()
    {


        MakeActive(gameOver);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Scene1");


    }

    IEnumerator spawnStartMessage()
    {
        yield return new WaitForSeconds(4f);
        startMessage.SetActive(false);
    }
}
