using UnityEngine;

public class ItemRecolectable_V2 : MonoBehaviour
{
    [Header("Datos del item cargados desde JSON")]
    [SerializeField] private string itemName;
    [SerializeField] private string rareza;
    [SerializeField] private int itemValue;
    [SerializeField] private string iconoId;

    [Header("Referencias")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Configurar(ColeccionableData data, Sprite sprite)
    {
        itemName = data.nombre;
        rareza = data.rareza;
        itemValue = data.valor;
        iconoId = data.iconoId;

        gameObject.name = data.nombre;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Log("Configurando " + itemName);
        Debug.Log("spriteRenderer encontrado: " + (spriteRenderer != null));
        Debug.Log("sprite recibido: " + (sprite != null ? sprite.name : "NULL"));

        if (spriteRenderer != null && sprite != null)
        {
            spriteRenderer.sprite = sprite;
            spriteRenderer.color = Color.white;

            Debug.Log("Sprite asignado a: " + gameObject.name);
            Debug.Log("Sprite actual en renderer: " + spriteRenderer.sprite.name);
        }
    }

    public string GetItemName() => itemName;
    public int GetItemValue() => itemValue;
    public string GetRareza() => rareza;
    public string GetIconoId() => iconoId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Recolectó: " + itemName + " | Valor: " + itemValue);

        // Ajusta esta línea a tu GameManager real
        GameManager.Instance.SumarItem(itemName, itemValue);

        Destroy(gameObject);
    }
}
