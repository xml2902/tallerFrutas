using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public int itemValue=1;

}

public enum ItemType
{
    Apple,
    Bananas,
    Kiwi,
    Orange,
    Coins,
}