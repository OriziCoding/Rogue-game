using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public float spawnInterval = 2f; // Interval between each enemy spawn
    public float spawnRadius = 5f; // Radius around the player where enemies will spawn
    public float spawnRateIncrease = 0.1f; // Rate at which spawn interval decreases (increase spawn rate)
    public Transform player; // Reference to the player's transform

    private float nextSpawnTime; // Time when the next enemy should spawn

    void Start()
    {
        // Set the initial next spawn time
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Check if it's time to spawn a new enemy
        if (Time.time >= nextSpawnTime)
        {
            // Spawn a new enemy
            SpawnEnemy();

            // Update the next spawn time for the next enemy
            nextSpawnTime = Time.time + spawnInterval;

            // Decrease spawn interval to increase spawn rate over time
            spawnInterval -= spawnRateIncrease;
            // Ensure spawn interval does not go below a minimum value (e.g., 0.1f)
            spawnInterval = Mathf.Max(spawnInterval, 0.1f);
        }
    }

    void SpawnEnemy()
    {
        // Calculate a random position around the player within the spawn radius
        Vector2 randomOffset = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = player.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

        // Instantiate an enemy at the calculated position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
