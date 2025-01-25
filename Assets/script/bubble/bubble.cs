using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class bubble : MonoBehaviour
{
    [SerializeField] public int oxigenAcount;
    [SerializeField] private Animator anim;
    [SerializeField] CircleCollider2D CC;
    public void setanim()
    {
        CC.enabled = false;
        anim.SetTrigger("explote");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
