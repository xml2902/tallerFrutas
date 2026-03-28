using UnityEngine;

public class ControllerScene2 : MonoBehaviour
{

    public Timer tiempoScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowTimeGameManager();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTimeGameManager()
    {
        Debug.Log("Tiempo que paso en esena 1 " + GameManager.Instance.GlobalTime);
    }

    public void GetTimePassGM()
    {
        float timeStop = tiempoScene.StopTime;
        GameManager.Instance.TotalTime(timeStop);
    }
}
