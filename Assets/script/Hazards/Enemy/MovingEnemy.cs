using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.left);
    }
}
