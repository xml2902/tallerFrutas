using UnityEngine;

public class Muerte : MonoBehaviour
{
    public GameObject panelMuerte;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muerte"))
        {
            Morir();
        }
    }

    void Morir()
    {
        panelMuerte.SetActive(true);
        Time.timeScale = 0f; // pausa el juego (opcional)
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelMuerte.SetActive(false); // oculto al inicio
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
