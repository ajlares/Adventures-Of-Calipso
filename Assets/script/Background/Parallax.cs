using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPosition;
    public GameObject parallaxCamera;
    public float parallaxEffect;


    private void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (parallaxCamera.transform.position.x * (1 - parallaxEffect));
        float distance = (parallaxCamera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (temp > startPosition + length) { startPosition += length; }
        else if (temp < startPosition - length) { startPosition -= length; }

    }
}
