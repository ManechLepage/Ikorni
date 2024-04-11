using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory/ItemDatabase" )]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] items;
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    public void OnAfterDeserialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < items.Length; i++)
        {
            items[i].ID = i;
            GetItem.Add(i, items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }

    public List<ItemObject> GetItemsByRarity(Rarity rarity)
    {
        List<ItemObject> itemsByRarity = new List<ItemObject>();
        foreach (ItemObject item in items)
        {
            if (item.rarity == rarity)
            {
                itemsByRarity.Add(item);
            }
        }
        return itemsByRarity;
    }
}
