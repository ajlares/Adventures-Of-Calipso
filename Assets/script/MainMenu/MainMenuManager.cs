using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestTimeDisplay;

    private void Awake()
    {
        float bestTime = PlayerPrefs.GetFloat(Timer.BestTimeKey, 0);
        bestTimeDisplay.text = Timer.SetTimeFormat(bestTime);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
