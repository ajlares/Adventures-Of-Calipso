using UnityEngine;

public class FallingStelactite : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.down);
    }
}
