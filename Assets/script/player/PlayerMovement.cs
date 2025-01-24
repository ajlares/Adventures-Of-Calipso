using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        // Obtener el input del teclado en los ejes horizontal y vertical
        float movimientoX = Input.GetAxis("Horizontal"); // Eje X (A/D o Flechas Izquierda/Derecha)
        float movimientoY = Input.GetAxis("Vertical");   // Eje Y (W/S o Flechas Arriba/Abajo)
        // Crear un vector de movimiento
        Vector2 movimiento = new Vector2(movimientoX, movimientoY);

        // Mover al GameObject multiplicando por la velocidad y el tiempo entre frames
        transform.Translate(movimiento * PlayerStats.instance.Speed * Time.deltaTime);
    }
}
