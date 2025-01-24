using Unity.Mathematics;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float actualHealth;
    [SerializeField] float maxOxigen;
    [SerializeField] float actualOxigen;
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
        actualOxigen = maxOxigen;
    }
    private void Update() 
    {

    }
    private void UseOxigen()
    {
        actualOxigen--;
        if(actualOxigen < 0)
        {
            actualOxigen =0;
            actualHealth--;
        }
    }
    public void AddOxigen(int valeu)
    {
        actualOxigen += valeu;
        if(actualOxigen > maxOxigen)
        {
            actualOxigen = maxOxigen;
        }
    }
}
