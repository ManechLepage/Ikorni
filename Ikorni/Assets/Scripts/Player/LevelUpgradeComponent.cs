using UnityEngine;

public class LevelUpgradeComponent : MonoBehaviour
{
    public bool isUpgrading = false;
    [Space]
    public GameObject upgradePanel;
    [Space]
    public PlayerData playerData;
    public ItemDataBase items;
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
        for (int i = 0; i < 3; i++)
        {
            
        }
    }

    public Item GenerateRandomItem()
    {
        // Load random item by rarity 

    }


}