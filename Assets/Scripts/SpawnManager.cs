using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject asteroidPrefab;
    public GameObject powerupPrefab;

    private float allY = 0.7f;
    private float xSpawnEnemy = 12.0f;
    private float zLimitEnemy = 5.0f;
    private float startDelayEnemy = 1.0f;
    private float intervalEnemy = 3.0f;

    private float startDelayPowerup = 11.0f;
    private float intervalPowerup = 12.0f;

    private float zSpawnAsteroid = 7.0f;
    private float xLimitLeftAsteroid = -10.0f;
    private float xLimitRightAsteroid = -1.0f;
    private float startDelayAsteroid = 2.0f;
    private float intervalAsteroid = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelayEnemy, intervalEnemy);
        InvokeRepeating("SpawnPowerup", startDelayPowerup, intervalPowerup);
        InvokeRepeating("SpawnAsteroid", startDelayAsteroid, intervalAsteroid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        float randomZ = Random.Range(-zLimitEnemy, zLimitEnemy);
        Vector3 spawnPos = new Vector3(xSpawnEnemy, allY, randomZ);
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[randomEnemy], spawnPos, 
            enemyPrefabs[randomEnemy].transform.rotation);
    }

    private void SpawnPowerup()
    {
        float randomZ = Random.Range(-zLimitEnemy, zLimitEnemy);
        Vector3 spawnPos = new Vector3(xSpawnEnemy, allY, randomZ);

        Instantiate(powerupPrefab, spawnPos,
            powerupPrefab.transform.rotation);
    }

    private void SpawnAsteroid()
    {
        float randomX = Random.Range(xLimitLeftAsteroid, xLimitRightAsteroid);
        int upOrDown = Random.Range(0, 2);
        float startZ = zSpawnAsteroid;
        
        if (upOrDown == 0) {
            startZ = -startZ;
        }

        Vector3 spawnPos = new Vector3(randomX, allY, startZ);

        Instantiate(asteroidPrefab, spawnPos, 
            asteroidPrefab.transform.rotation);
    }
}
