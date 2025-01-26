using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int actualHealth;
    [SerializeField] public float maxOxigen;
    [SerializeField] public float actualOxigen;
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
        actualOxigen = maxOxigen;
        StartCoroutine(oxigenDelay());
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
        StartCoroutine(oxigenDelay());
        UIManager.instance.updateOxigen();
    }
    public void AddOxigen(int valeu)
    {
        actualOxigen += valeu;
        if(actualOxigen > maxOxigen)
        {
            actualOxigen = maxOxigen;
        }
        UIManager.instance.updateOxigen();
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
            Timer.instance.SaveTime();
            Time.timeScale =0;
        }
    }
    public void ResetDamage()
    {
        canTakeDamage = true;  
    }

    IEnumerator oxigenDelay()
    {
        yield return new WaitForSeconds(useOxigenTime);
        UseOxigen();
    }
    IEnumerator DrownDelay()
    {
        yield return new WaitForSeconds(drownDelay);
        canDrown = true;
    }


}
