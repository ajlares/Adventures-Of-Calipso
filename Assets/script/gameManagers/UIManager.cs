using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> BGImages;
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

    }
}
