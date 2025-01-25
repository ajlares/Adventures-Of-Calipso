using UnityEngine;

public class MovimientoAleatorioSinRotacion : MonoBehaviour
{
    public float Speed = 5f;
    public float noiseTime = 2f;
    private Vector2 direccion;
    private float indexTime;

    void Start()
    {
        Noise();
        indexTime= Time.time + noiseTime;
    }

    void Update()
    {
        transform.position += (Vector3)(direccion * Speed * Time.deltaTime);
        if (Time.time >= indexTime)
        {
            Noise();
            indexTime = Time.time + noiseTime;
        }
    }

    void Noise()
    {
        direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}