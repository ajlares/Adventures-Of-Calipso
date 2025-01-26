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
    [SerializeField] public  bool canMove;
    [SerializeField] private float drownDelay;
    [SerializeField] PlayRandomSound soundPlayer;
    [SerializeField] SoundContainer bubblePopSoundContainer;

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
    private void UseOxigen()
    {
        actualOxigen--;
        soundPlayer.PlaySound(bubblePopSoundContainer);
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
        if(actualHealth < 1)
        {
            startDeath();
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("Damage"); 

        }
    }
    public void ResetDamage()
    {
        canTakeDamage = true;  
    }

    public void startDeath()
    {
        Debug.Log("isdeathh");
        gameObject.GetComponent<Animator>().SetTrigger("death"); 
        canMove = false;
        Timer.instance.SaveTime();

    }
    public void endGame()
    {
        UIManager.instance.deathPabel();
        Time.timeScale =0;
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
