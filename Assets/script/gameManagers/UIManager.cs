using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> BGImages;
    [SerializeField] private List<GameObject> bubbles;
    [SerializeField] private GameObject pausebuton;
    [SerializeField] private GameObject pausepanel;
    [SerializeField] private GameObject deathpanel;
    [SerializeField] private bool ispause;
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
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel();
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
    public void PausePanel()
    {
        Debug.Log("pause");
        if(ispause)
        {
            ispause = false;
            pausepanel.SetActive(false);
            Time.timeScale=1;
        }
        else
        {
            ispause = true;
            pausepanel.SetActive(true);
            Time.timeScale=0;
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene("MainLevel");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void deathPabel()
    {
        Time.timeScale = 0;
        deathpanel.SetActive(true);
        pausepanel.SetActive(false);
        pausebuton.SetActive(false);
    }
}
