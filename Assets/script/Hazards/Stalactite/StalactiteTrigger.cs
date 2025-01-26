using UnityEngine;

public class StalactiteTrigger : MonoBehaviour
{
    [SerializeField] GameObject stalactite;
    public float minSpeed;
    public float maxSpeed;
    bool hasFallen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasFallen && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
            hasFallen = true;
            stalactite.AddComponent<FallingStelactite>().speed = Random.Range(minSpeed,maxSpeed);
        }
    }
}
