using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public float speed;
    private void Start() 
    {
        Destroy(gameObject,5);    
    }
    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.left);
    }
}
