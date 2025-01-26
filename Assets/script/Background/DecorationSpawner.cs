using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> decorations;
    [SerializeField] Transform minPosition;
    [SerializeField] Transform maxPosition;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObject());
    }


    IEnumerator SpawnObject()
    {
        int i = Random.Range(0, decorations.Count);
        Vector3 spanwPosition = new Vector3(minPosition.position.x, Random.Range(minPosition.position.y, maxPosition.position.y), 5);
        Instantiate(decorations[i],spanwPosition, decorations[i].transform.rotation);
        yield return new WaitForSeconds(Random.Range(minTime,maxTime));
        StartCoroutine(SpawnObject());
    }
}
