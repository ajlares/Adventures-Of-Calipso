using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int actualHealth;
    [SerializeField] float maxOxigen;
    [SerializeField] float actualOxigen;
    [SerializeField] float useOxigenTime;
    [SerializeField] public float Speed;
    [SerializeField] public bool canTakeDamage;
    [SerializeField] private bool canDrown;
    [SerializeField] private bool canMove;
    [SerializeField] private float drownDelay;

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
            actualOxigen = 0;
            if(canDrown)
            {
                TakeDamage();
                StartCoroutine(DrownDelay());
            }
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

    public void TakeDamage()
    {
        canTakeDamage = false;;
        actualHealth--;
        UIManager.instance.updateLife();
        gameObject.GetComponent<Animator>().SetTrigger("Damage"); 
        if(actualHealth < 1)
        {
            // the player is death
            Time.timeScale =0;
        }
    }
    public void ResetDamage()
    {
        canTakeDamage = true;  
    }

    IEnumerator DrownDelay()
    {
        yield return new WaitForSeconds(drownDelay);
        canDrown = true;
    }

}
