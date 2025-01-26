using UnityEngine;

public class clearDecoration : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Decoration"))
        {
            Destroy(other.gameObject);
        }    
    }
}
