using UnityEngine;

public class UIManager : MonoBehaviour
{
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

    }
    public void updateOxigen()
    {

    }
}
