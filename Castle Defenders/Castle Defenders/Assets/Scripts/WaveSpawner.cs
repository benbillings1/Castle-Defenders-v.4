using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text wave;

    private float timeBetweenWaves = 10f;
    private int enemyCount = 0;
    private int waveNumber = 0;

    private void Update()
    {
        wave.text = "Current Wave: " + waveNumber.ToString();

        if (timeBetweenWaves <= 0f)
        {
            StartCoroutine(spawnWaves());
            timeBetweenWaves = 15f;
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
            yield return new WaitForSeconds(1f);
        }

        
        
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
