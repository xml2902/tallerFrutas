using UnityEngine;

public class ControllerScene3 : MonoBehaviour
{
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
        Debug.Log("Tiempo total " + GameManager.Instance.GlobalTime);
    }
}
