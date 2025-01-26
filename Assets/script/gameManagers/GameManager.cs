using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float globalSpeed;
    [SerializeField] private float speedUpdateTime;
    private float indexTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale =1;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        if(speedUpdateTime <= indexTime)
        {
            UpdateSpeed();
            indexTime = 0;
        }
        else
        
        {
            indexTime += Time.deltaTime;
        }
    }

    private void CameraMove()
    {   
        if(PlayerStats.instance.canMove)
        {
            float movimientoX = globalSpeed * Time.deltaTime;
            transform.Translate(movimientoX, 0, 0);
        }
    }
    private void UpdateSpeed()
    {
        globalSpeed++;
        PlayerStats.instance.Speed++;
    }
    public void stopTime()
    {
        Time.timeScale = 0;
    }
}
