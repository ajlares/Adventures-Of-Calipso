using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Spawn position")]
    [SerializeField] Transform maxPosition;
    [SerializeField] Transform minPosition;
    [Header("Spawn cooldown")]
    [SerializeField] float minCooldown;
    [SerializeField] float maxCooldown;    
    [Header("Spawn speed")]
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [Header("Spawn enemies prefabs")]
    [SerializeField] List<GameObject> enemies;

    private void Start()
    {
        SpawnEnemy();  
    }

    void SpawnEnemy()
    {
        int spawnEnemy = Random.Range(0, enemies.Count);
        float yPosition = Random.Range(minPosition.position.y,maxPosition.position.y);
        Vector3 spawnPosition = new Vector3(minPosition.position.x, yPosition, minPosition.position.z);
        GameObject instance = Instantiate(enemies[spawnEnemy], spawnPosition, enemies[spawnEnemy].transform.rotation);
        if (instance.TryGetComponent<MovingEnemy>(out MovingEnemy movingEnemy)) { movingEnemy.speed = Random.Range(minSpeed, maxSpeed); }
        StartCoroutine(SpawnDelay());
    }


    IEnumerator SpawnDelay()
    {
        float delay = Random.Range(minCooldown,maxCooldown);
        yield return new WaitForSeconds(delay);
        SpawnEnemy();
    }
}
