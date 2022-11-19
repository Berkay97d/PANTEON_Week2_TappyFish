using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float yRange;
    [SerializeField] private float xPos;
    [SerializeField] private float spawnRate;
    [SerializeField] private float minSpawnRate;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        int counter = 0;

        if (GameController.İsGameOver)
        {
            yield break;
        }
        
        while (true)
        {
            counter++;

            if (counter % 10 == 0 && spawnRate > minSpawnRate )
            {
                spawnRate -= (spawnRate / 10);
            }
            
            Instantiate(obstacle, RandomSpawnPosition(), obstacle.transform.rotation);

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private Vector2 RandomSpawnPosition()
    {
        float randomY = Random.Range(-yRange, yRange);
        return new Vector2(xPos, randomY);
    }
    
}
