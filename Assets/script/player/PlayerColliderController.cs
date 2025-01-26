using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if( other.gameObject.CompareTag("border"))
        {
            if(PlayerStats.instance.canTakeDamage)
            {
                PlayerStats.instance.TakeDamage();
            }
        }    
        if( other.gameObject.CompareTag("Bubble"))
        {
            Debug.Log(" burbuja");
            PlayerStats.instance.AddOxigen(other.gameObject.GetComponent<bubble>().oxigenAcount);
            other.gameObject.GetComponent<bubble>().setanim();
        }    
        if( other.gameObject.CompareTag("Obstacle"))
        {
            if(PlayerStats.instance.canTakeDamage)
            {
                other.gameObject.GetComponent<Collider2D>().enabled = false;
                PlayerStats.instance.TakeDamage();
            }
        }    
    }
}
