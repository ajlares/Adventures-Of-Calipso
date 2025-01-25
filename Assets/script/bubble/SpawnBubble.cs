using System.Collections;
using UnityEngine;

public class SpawnBubble : MonoBehaviour
{
    [SerializeField] private Transform maxPosition;
    [SerializeField]private Transform minPosition;
    [SerializeField] private float minCooldown;
    [SerializeField] private float maxCooldown;
    [SerializeField] private GameObject bubble;

    private void Start() 
    {
        Spawn();
    }
    private void Spawn()
    {
        float yPosition = Random.Range(minPosition.position.y,maxPosition.position.y);
        Vector3 spawnPosition = new Vector3(minPosition.position.x, yPosition, minPosition.position.z);
        GameObject instance = Instantiate(bubble, spawnPosition, bubble.transform.rotation);
        StartCoroutine(CoolDown());
    }
    IEnumerator CoolDown()
    {
        float RandomCooldown = Random.Range(minCooldown,maxCooldown);
        yield return new WaitForSeconds(RandomCooldown);
        Spawn();
    }
}
