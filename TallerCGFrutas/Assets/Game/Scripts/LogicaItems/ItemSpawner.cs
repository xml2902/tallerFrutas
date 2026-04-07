using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameDataLoader dataLoader;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private MissionManager missionManager;

    [Header("Modo de Funcionamiento")]
    public bool usarMisionParaSpawn = false;

    [Header("Configuración Manual (Escena 1)")]
    [SerializeField] private List<SpawnItemConfig> itemsASpawnear;

    [Header("Puntos de spawn")]
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        if (!usarMisionParaSpawn)
        {
            SpawnItemsManual();
        }
    }

    public void EjecutarSpawnMision()
    {
        if (missionManager == null || dataLoader == null)
        {
            Debug.LogError("ItemSpawner: Faltan referencias de MissionManager o DataLoader.");
            return;
        }

        MisionData mision = missionManager.GetMisionActiva();
        if (mision == null || mision.objetivos == null)
        {
            Debug.LogWarning("ItemSpawner: No hay misión activa detectada.");
            return;
        }

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("ItemSpawner: ¡No has asignado Puntos de Spawn!");
            return;
        }

        int spawnIndex = 0;
        foreach (var objetivo in mision.objetivos)
        {
            List<ColeccionableData> posiblesFrutas = new List<ColeccionableData>();

            if (objetivo.fruta == "Any")
            {
                if (dataLoader.gameData.coleccionables != null)
                {
                    posiblesFrutas.AddRange(dataLoader.gameData.coleccionables);
                }
            }
            else if (objetivo.fruta == "Raras")
            {
                foreach (var f in dataLoader.gameData.coleccionables)
                {
                    if (f.rareza == "Raro")
                    {
                        posiblesFrutas.Add(f);
                    }
                }
            }
            else
            {
                ColeccionableData dataCerrada = dataLoader.ObtenerColeccionablePorNombre(objetivo.fruta);
                if (dataCerrada != null) posiblesFrutas.Add(dataCerrada);
            }

            if (posiblesFrutas.Count == 0)
            {
                Debug.LogError($"ItemSpawner: No se encontró ninguna fruta válida para '{objetivo.fruta}' en el JSON.");
                continue;
            }

            for (int i = 0; i < objetivo.cantidad; i++)
            {
                if (spawnIndex >= spawnPoints.Length) break;

                int indiceAzar = Random.Range(0, posiblesFrutas.Count);
                ColeccionableData frutaElegida = posiblesFrutas[indiceAzar];

                InstanciarFruta(frutaElegida, spawnPoints[spawnIndex]);
                spawnIndex++;
            }
        }
        Debug.Log("ItemSpawner: Spawn de misión completado con éxito.");
    }

    void SpawnItemsManual()
    {
        int spawnIndex = 0;
        foreach (var config in itemsASpawnear)
        {
            ColeccionableData data = dataLoader.ObtenerColeccionablePorNombre(config.itemName);
            if (data == null) continue;

            for (int i = 0; i < config.cantidad; i++)
            {
                if (spawnIndex >= spawnPoints.Length) break;
                InstanciarFruta(data, spawnPoints[spawnIndex]);
                spawnIndex++;
            }
        }
    }

    private void InstanciarFruta(ColeccionableData data, Transform punto)
    {
        Debug.Log("Intentando spawnear: " + data.nombre); 
        GameObject obj = Instantiate(itemPrefab, punto.position, Quaternion.identity);
        ItemRecolectable_V2 item = obj.GetComponent<ItemRecolectable_V2>();

        Sprite[] sprites = Resources.LoadAll<Sprite>("Frutas/" + data.iconoId);
        Sprite sprite = (sprites.Length > 0) ? sprites[0] : null;

        item.Configurar(data, sprite);
    }
}

[System.Serializable]
public class SpawnItemConfig
{
    public string itemName;
    public int cantidad;
}