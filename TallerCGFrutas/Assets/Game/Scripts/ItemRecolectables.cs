using UnityEngine;
using UnityEngine.UIElements;

public class ItemRecolectables : MonoBehaviour
{

    [SerializeField] private ItemData _itemData;

    public AudioSource audioSource;
    public AudioClip collisionSound;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        audioSource.PlayOneShot(collisionSound);
        
        GameManager.Instance.AddItem(_itemData);
        Debug.Log($"Item recolectado: {_itemData.itemName} "+ "\nValor Elemento: " + _itemData.itemValue);
        
        Destroy(gameObject);

        

    }

    



}
