using UnityEngine;
using TMPro;
using System.Linq;

public class ControllerScene1 : MonoBehaviour
{
    public Timer tiempoScene;

    public TextMeshProUGUI txtCountVApple;
    public TextMeshProUGUI txtCountVOranges;

    public GameObject[] fruits;
    public int initialAmount = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetCountItems();
    }

    

    public void GetTimePassGM()
    {
        float timeStop = tiempoScene.StopTime;
        GameManager.Instance.TotalTime(timeStop);
    }


    public void GetCountItems()
    {
        txtCountVApple.text = GameManager.Instance.TotalApple.ToString();
        txtCountVOranges.text =  GameManager.Instance.TotalOrange.ToString();
    }
}
