using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text wave;
    public Transform[] waypoints;

    private float timeBetweenWaves = 20f;
    private int enemyCount = 0;
    private int waveNumber = 0;

    private void Update()
    {
        wave.text = "Current Wave: " + waveNumber.ToString();

        if (timeBetweenWaves <= 0f)
        {
            StartCoroutine(spawnWaves());
            timeBetweenWaves = 10f;
        }
        
        timeBetweenWaves -= Time.deltaTime;
    }

    IEnumerator spawnWaves()
    {
        waveNumber++;
        enemyCount++;

        for (int i = 0; i < enemyCount; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(2f);
        }

        
        
    }

    void spawnEnemy()
    {
        
        GameObject dragon = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation).gameObject;

        dragon.GetComponent<dragonmovement>().SetNodes(waypoints);
    }

}
