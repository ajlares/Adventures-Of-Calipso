using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> BGImages;
    [SerializeField] private List<GameObject> bubbles;
    public static UIManager instance;
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

    public void updateLife()
    {
        int index = PlayerStats.instance.maxHealth - PlayerStats.instance.actualHealth;
        BGImages[index-1].SetActive(true);
    }
    public void updateOxigen()
    {
        float index = PlayerStats.instance.maxOxigen - PlayerStats.instance.actualOxigen;
        for(int i = 0; i < 10;i++)
        {
            if(i<index)
            {
                bubbles[i].SetActive(false);
            }
            else
            {
                bubbles[i].SetActive(true);
            }
        }
    }
    public void pausepabel()
    {

    }
    public void deathPabel()
    {
        
    }
}
