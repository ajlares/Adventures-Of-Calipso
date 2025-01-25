using System.Collections;
using UnityEngine;

public class bubble : MonoBehaviour
{
    [SerializeField] public int oxigenAcount;
    [SerializeField] private Animator anim;
    [SerializeField] CircleCollider2D CC;
    private void Start() 
    {
        destroyDelay();
    }
    public void setanim()
    {
        CC.enabled = false;
        anim.SetTrigger("explote");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if( other.gameObject.CompareTag("border"))
        {
            setanim();
        }
        if( other.gameObject.CompareTag("bubleBorder"))
        {
            setanim();
        }
    }
    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(3);
        setanim();
    }
}
