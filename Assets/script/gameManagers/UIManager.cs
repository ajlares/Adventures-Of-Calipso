using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Image> BGImages;
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
        BGImages[index-1].enabled = true;
    }
    public void updateOxigen()
    {

    }
}
