using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene2 : MonoBehaviour
{
    [Header("Referencias de Lógica")]
    public Timer tiempoScene;
    public GameDataLoader dataLoader;
    public MissionManager missionManager;
    public ItemSpawner itemSpawner;

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

    void Start()
    {
        Time.timeScale = 1f;
        ShowTimeGameManager();
        StartCoroutine(PrepararEscena2());
    }

    void Update()
    {
        ActualizarTextoMision();
        GetCountItems();
    }

    IEnumerator PrepararEscena2()
    {
        while (dataLoader == null || dataLoader.gameData == null)
        {
            yield return null;
        }

        while (dataLoader.gameData.misiones == null)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        Debug.Log("ControllerScene2: Datos confirmados. Configurando misión...");

        dataLoader.ConfigurarEscenaAleatoria(missionManager);

        yield return new WaitForEndOfFrame();

        MisionData mision = missionManager.GetMisionActiva();

        if (mision != null)
        {
            Debug.Log("ControllerScene2: Misión obtenida: " + mision.titulo);

            if (itemSpawner != null)
            {
                itemSpawner.usarMisionParaSpawn = true; 
                itemSpawner.EjecutarSpawnMision();
            }

            if (txtTituloPanel != null) txtTituloPanel.text = mision.titulo;
            if (txtDescPanel != null) txtDescPanel.text = mision.descripcion;

            if (panelMision != null)
            {
                panelMision.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            Debug.LogError("ControllerScene2: No se encontró misión activa.");
        }
    }

    private void MostrarPanelMision(MisionData mision)
    {
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
            Debug.Log("¡Nivel 2 iniciado oficialmente!");
        }
    }

    public void GetCountItems()
    {
        if (GameManager.Instance != null)
        {
            if (txtCountVApple) txtCountVApple.text = GameManager.Instance.TotalApple.ToString();
            if (txtCountVOranges) txtCountVOranges.text = GameManager.Instance.TotalOrange.ToString();
            if (txtCountVBanana) txtCountVBanana.text = GameManager.Instance.TotalBanana.ToString();
            if (txtCountVCherries) txtCountVCherries.text = GameManager.Instance.TotalCherries.ToString();
            if (txtCountVKiwi) txtCountVKiwi.text = GameManager.Instance.TotalKiwi.ToString();
        }
    }

    private void ActualizarTextoMision()
    {
        if (txtProgresoMision != null && missionManager != null && missionManager.GetMisionActiva() != null)
        {
            txtProgresoMision.text = "Misión: " + missionManager.ObtenerTextoProgreso();
        }
    }

    public void ShowTimeGameManager()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("Tiempo acumulado: " + GameManager.Instance.GlobalTime);
        }
    }

    public void GetTimePassGM()
    {
        if (tiempoScene != null && GameManager.Instance != null)
        {
            float timeStop = tiempoScene.StopTime;
            GameManager.Instance.TotalTime(timeStop);
        }
    }
}
