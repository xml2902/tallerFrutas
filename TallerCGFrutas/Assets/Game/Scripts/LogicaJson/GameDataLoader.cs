using System;
using System.IO;
using UnityEngine;

public class GameDataLoader : MonoBehaviour
{

    [SerializeField] private string FileName = "GameData.json";
    public GameData gameData;

    private void Awake()
    {
        LoadGameData();
    }

    private void LoadGameData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, FileName);
        if (!File.Exists(path))
        {
            Debug.LogError($"loading game data from: {path}" + "Error");

            return;

        }

        string json = File.ReadAllText(path);
        gameData = JsonUtility.FromJson<GameData>(json);
        Debug.Log("JSON Cargado correctamente.");

    }

    public MisionData ObtenerMisionPorId(int id)
    {
        if (gameData == null || gameData.misiones == null) return null;

        foreach (var mision in gameData.misiones)
        {
            if (mision.id == id) return mision;
        }
        return null;
    }

    public ColeccionableData ObtenerColeccionablePorNombre(string nombre)
    {
        if (gameData == null || gameData.coleccionables == null) return null;

        for (int i = 0; i < gameData.coleccionables.Length; i++)
        {
            if (gameData.coleccionables[i].nombre == nombre)
                return gameData.coleccionables[i];
        }

        return null;
    }

    public void ConfigurarEscena(int misionId, MissionManager manager)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TotalApple = 0;
            GameManager.Instance.TotalOrange = 0;
            GameManager.Instance.TotalBanana = 0;
            GameManager.Instance.TotalCherries = 0;
            GameManager.Instance.TotalKiwi = 0;
            Debug.Log("GameManager Reiniciado por el Loader.");
        }

        MisionData mision = ObtenerMisionPorId(misionId);
        if (mision != null && manager != null)
        {
            manager.AsignarMision(mision);
        }
    } 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
