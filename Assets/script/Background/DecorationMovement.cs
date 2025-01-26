using UnityEngine;

public class DecorationMovement : MonoBehaviour
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);   
    }

    private void Update()
    {
        transform.Translate( Time.deltaTime * speed * Vector3.left );
    }
}
