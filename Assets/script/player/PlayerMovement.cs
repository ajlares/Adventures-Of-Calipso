using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if(PlayerStats.instance.canMove)
        {
            float movimientoX = Input.GetAxis("Horizontal");
            float movimientoY = Input.GetAxis("Vertical"); 
            Vector2 movimiento = new Vector2(movimientoX, movimientoY);
            transform.Translate(movimiento * PlayerStats.instance.Speed * Time.deltaTime);
        }
    }
}