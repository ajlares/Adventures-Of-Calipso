using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteSpawner : MonoBehaviour
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
    [SerializeField] GameObject stalactiteTriggerPrefab;

    private void Start()
    {
        SpawnStalactite();
    }

    void SpawnStalactite()
    {
        float xPosition = Random.Range(minPosition.position.x, maxPosition.position.x);
        Vector3 spawnPosition = new Vector3(xPosition, minPosition.position.y, minPosition.position.z);
        GameObject instance = Instantiate(stalactiteTriggerPrefab, spawnPosition, stalactiteTriggerPrefab.transform.rotation);
        if (instance.TryGetComponent<StalactiteTrigger>(out StalactiteTrigger stalactiteTriggerInstance)) { stalactiteTriggerInstance.minSpeed = minSpeed; stalactiteTriggerInstance.minSpeed = maxSpeed; }
        StartCoroutine(SpawnDelay());
    }


    IEnumerator SpawnDelay()
    {
        float delay = Random.Range(minCooldown, maxCooldown);
        yield return new WaitForSeconds(delay);
        SpawnStalactite();
    }
}
