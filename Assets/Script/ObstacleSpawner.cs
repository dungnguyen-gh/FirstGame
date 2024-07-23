using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // an array of obstacle game objects to spawn
    public float spawnInterval; // time interval between spawns
    public float spawnRadius; // maximum distance from spawner where obstacles can spawn

    private float timer; // keeps track of time elapsed since last spawn

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            // generate a random position within spawn radius
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;

            // pick a random obstacle to spawn from the obstacles array
            int obstacleIndex = Random.Range(0, obstacles.Length);
            GameObject obstacle = obstacles[obstacleIndex];

            // spawn the obstacle at the random position
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }
}
