using Unity.Mathematics;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float actualHealth;
    [SerializeField] float maxOxigen;
    [SerializeField] float aCtualOxigen;
    [SerializeField] float useOxigenTime;
    [SerializeField] public float Speed;

    public static PlayerStats instance;
    private void Awake() 
    {
          if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy( this);
        }  
    }
    private void Start()
    {
        InvokeRepeating("UseOxigen",useOxigenTime,1);
    }
    private void Update() 
    {

    }
    private void UseOxigen()
    {
        aCtualOxigen--;
        if(aCtualOxigen < 0)
        {
            aCtualOxigen =0;
            actualHealth--;
        }
    }
}
