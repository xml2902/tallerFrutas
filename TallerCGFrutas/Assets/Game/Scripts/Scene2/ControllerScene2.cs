using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene2 : MonoBehaviour
{

    public Timer tiempoScene;
    public GameDataLoader dataLoader;
    public MissionManager missionManager;

    [Header("Panel de Misión Inicial")]
    public GameObject panelMision;
    public TextMeshProUGUI txtTituloPanel;
    public TextMeshProUGUI txtDescPanel;

    [Header("UI Contadores")]
    public TextMeshProUGUI txtCountVApple;
    public TextMeshProUGUI txtCountVOranges;
    public TextMeshProUGUI txtCountVBanana;
    public TextMeshProUGUI txtCountVCherries;
    public TextMeshProUGUI txtCountVKiwi;

    [Header("UI Misión")]
    public TextMeshProUGUI txtProgresoMision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowTimeGameManager();
        PrepararNivel();
    }

    // Update is called once per frame
    void Update()
    {
        GetCountItems();
        ActualizarTextoMision();
        ChequearAvanceDeNivel();
    }

    private void PrepararNivel()
    {
        if (dataLoader == null) return;

        dataLoader.ConfigurarEscena(1, missionManager);

        MostrarPanelMision();
    }

    private void MostrarPanelMision()
    {
        MisionData mision = missionManager.GetMisionActiva();

        if (mision != null && panelMision != null)
        {
            txtTituloPanel.text = mision.titulo;
            txtDescPanel.text = mision.descripcion;

            panelMision.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ComenzarNivel()
    {
        if (panelMision != null)
        {
            panelMision.SetActive(false);
            Time.timeScale = 1f;
            Debug.Log("¡Nivel 2 iniciado!");
        }
    }

    public void GetCountItems()
    {
        txtCountVApple.text = GameManager.Instance.TotalApple.ToString();
        txtCountVOranges.text = GameManager.Instance.TotalOrange.ToString();
        txtCountVBanana.text = GameManager.Instance.TotalBanana.ToString();
        txtCountVCherries.text = GameManager.Instance.TotalCherries.ToString();
        txtCountVKiwi.text = GameManager.Instance.TotalKiwi.ToString();
    }

    private void ActualizarTextoMision()
    {
        if (txtProgresoMision != null && missionManager != null)
        {
            txtProgresoMision.text = "Misión: " + missionManager.ObtenerTextoProgreso();
        }
    }

    private void ChequearAvanceDeNivel()
    {
        if (missionManager != null && missionManager.VerificarMision())
        {
            Debug.Log("¡Misión cumplida! Avanzando al Nivel 3...");
            GetTimePassGM();
            SceneManager.LoadScene("Scene3");
        }
    }

    public void ShowTimeGameManager()
    {
        Debug.Log("Tiempo que paso en escena 1 " + GameManager.Instance.GlobalTime);
    }

    public void GetTimePassGM()
    {
        float timeStop = tiempoScene.StopTime;
        GameManager.Instance.TotalTime(timeStop);
    }
}
