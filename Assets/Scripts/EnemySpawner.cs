using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnCooldown = 2f;
    private float timer;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnEnemy();
            timer = spawnCooldown;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 _position = CalculateSpawnPosition();

        _position += player.transform.position;

        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = _position;
    }

    private Vector3 CalculateSpawnPosition()
    {
        Vector3 generatedPosition;
        float f = Random.value > 0.5f ? -1f : 1f;
        if(Random.value > 0.5f)
        {
            generatedPosition.x = Random.Range(-spawnArea.x, spawnArea.x);
            generatedPosition.y = spawnArea.y * f;
        }
        else
        {
            generatedPosition.x = spawnArea.x * f;
            generatedPosition.y = Random.Range(-spawnArea.y, spawnArea.y);
        }
        generatedPosition.z = 0f;
        return generatedPosition;
    }
}
