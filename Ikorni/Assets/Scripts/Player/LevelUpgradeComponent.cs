using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelUpgradeComponent : MonoBehaviour
{
    public bool isUpgrading = false;
    [Space]
    public GameObject upgradePanel;
    [Space]
    public PlayerData playerData;
    public ItemDatabaseObject items;
    public InventoryObject inventory;
    public InventoryObject itemChoices;

    public void Upgrade(int lvl)
    {
        isUpgrading = true;
        upgradePanel.SetActive(true);
    }

    public void DeActivateUpgradePanel()
    {
        isUpgrading = false;
        upgradePanel.SetActive(false);
    }

    public void GenerateItems()
    {
        ItemObject[] itemChoices = new ItemObject[3];
        for (int i = 0; i < 3; i++)
        {
            itemChoices[i] = GenerateRandomItem();
        }
    }

    public ItemObject GenerateRandomItem()
    {
        // Uncommon: 75%, Rare: 20%, Legendary: 5%
        int rarityScore = Random.Range(0, 100);
        if (rarityScore < 75)
        {
            return GetRandomItemObjectByRarity(Rarity.Uncommon);
        }
        else if (rarityScore < 95)
        {
            return GetRandomItemObjectByRarity(Rarity.Rare);
        }
        else
        {
            return GetRandomItemObjectByRarity(Rarity.Legendary);
        }
    }

    public ItemObject GetRandomItemObjectByRarity(Rarity rarity)
    {
        List<ItemObject> itemsByRarity = new List<ItemObject>();
        itemsByRarity = items.GetItemsByRarity(rarity);
        return itemsByRarity[Random.Range(0, itemsByRarity.Count)];
    }
}