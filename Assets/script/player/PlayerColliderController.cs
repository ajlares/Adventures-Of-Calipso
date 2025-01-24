using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if( other.gameObject.CompareTag("border"))
        {
            Debug.Log(" toco el borde parce");
        }    
        if( other.gameObject.CompareTag("Bubble"))
        {
            Debug.Log(" burbuja");
            PlayerStats.instance.AddOxigen(other.gameObject.GetComponent<bubble>().oxigenAcount);
            Destroy(other.gameObject);
        }    
        if( other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(" daño");
        }    
    }
}
