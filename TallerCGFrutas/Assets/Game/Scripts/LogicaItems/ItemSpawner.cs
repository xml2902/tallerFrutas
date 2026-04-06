using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameDataLoader dataLoader;
    [SerializeField] private GameObject itemPrefab;

    //REFERENCIA PARA conectar la mision aleatoria con el spawn de los items
    [SerializeField] private MissionManager missionManager;

    [Header("Configuración de spawn")]
    [SerializeField] private List<SpawnItemConfig> itemsASpawnear;

    [Header("Puntos de spawn")]
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        int spawnIndex = 0;

        foreach (var config in itemsASpawnear)
        {
            // Buscar datos en el JSON
            ColeccionableData data = dataLoader.ObtenerColeccionablePorNombre(config.itemName);

            if (data == null)
            {
                Debug.LogWarning("No existe en JSON: " + config.itemName);
                continue;
            }

            for (int i = 0; i < config.cantidad; i++)
            {
                if (spawnIndex >= spawnPoints.Length)
                {
                    Debug.LogWarning("No hay más puntos de spawn disponibles.");
                    return;
                }

                Transform punto = spawnPoints[spawnIndex];

                GameObject obj = Instantiate(itemPrefab, punto.position, Quaternion.identity);

                ItemRecolectable_V2 item = obj.GetComponent<ItemRecolectable_V2>();

                Sprite sprite = null;

                //Debug.Log("Buscando: Frutas/" + data.iconoId);
                Sprite[] sprites = Resources.LoadAll<Sprite>("Frutas/" + data.iconoId);
                //Debug.Log("Sprites encontrados: " + sprites.Length);
                foreach (var s in sprites)
                {
                    //Debug.Log("Sprite: " + s.name);
                }

                if (sprites.Length > 0)
                {
                    sprite = sprites[0];
                }
                else
                {
                    Debug.LogWarning("No se encontraron sprites para: " + data.iconoId);
                }

                item.Configurar(data, sprite);

                spawnIndex++;
            }
        }
    }



    // Nueva versión de SpawnItems que se basa en la misión activa, pero hay un problema de que si utilizo esta version no corre el juego.

    //void SpawnItems()
    //{
    //    if (missionManager == null)
    //    {
    //        Debug.LogError("No hay MissionManager asignado.");
    //        return;
    //    }

    //    MisionData mision = missionManager.GetMisionActiva();

    //    if (mision == null || mision.objetivos == null)
    //    {
    //        Debug.LogError("No hay misión activa.");
    //        return;
    //    }

    //    int spawnIndex = 0;

    //    foreach (var objetivo in mision.objetivos)
    //    {
    //        // Buscar datos en JSON
    //        ColeccionableData data = dataLoader.ObtenerColeccionablePorNombre(objetivo.fruta);

    //        if (data == null)
    //        {
    //            Debug.LogWarning("No existe en JSON: " + objetivo.fruta);
    //            continue;
    //        }

    //        int cantidad = objetivo.cantidad + 2; // margen extra

    //        for (int i = 0; i < cantidad; i++)
    //        {
    //            if (spawnIndex >= spawnPoints.Length)
    //            {
    //                Debug.LogWarning("No hay más puntos de spawn disponibles.");
    //                return;
    //            }

    //            Transform punto = spawnPoints[spawnIndex];

    //            GameObject obj = Instantiate(itemPrefab, punto.position, Quaternion.identity);

    //            ItemRecolectable_V2 item = obj.GetComponent<ItemRecolectable_V2>();

    //            // Cargar sprite
    //            Sprite[] sprites = Resources.LoadAll<Sprite>("Frutas/" + data.iconoId);

    //            Sprite sprite = sprites.Length > 0 ? sprites[0] : null;

    //            if (sprite == null)
    //            {
    //                Debug.LogWarning("No se encontró sprite para: " + data.iconoId);
    //            }

    //            item.Configurar(data, sprite);

    //            spawnIndex++;
    //        }
    //    }
    //}
}

[System.Serializable]
public class SpawnItemConfig
{
    public string itemName;
    public int cantidad;
}