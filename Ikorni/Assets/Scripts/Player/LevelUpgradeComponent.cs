using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class LevelUpgradeComponent : MonoBehaviour
{
    public bool isUpgrading = false;
    [Space]
    public GameObject upgradePanel;
    public TextMeshProUGUI[] rarityTexts = new TextMeshProUGUI[3];
    public TextMeshProUGUI displayText;
    public Color[] rarityColors = new Color[3];
    [Space]
    public PlayerData playerData;
    public ItemDatabaseObject items;

    public void Upgrade(int lvl)
    {
        isUpgrading = true;
        upgradePanel.SetActive(true);
        displayText.text = $"Level {lvl} Upgrade!";
        GenerateItems();
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
            rarityTexts[i].text = itemChoices[i].rarity.ToString();
            rarityTexts[i].color = rarityColors[(int)itemChoices[i].rarity];
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