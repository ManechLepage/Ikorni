using UnityEngine;

public class LevelUpgradeComponent : MonoBehaviour
{
    public GameObject upgradePanel;
    public PlayerData playerData;
    public bool isUpgrading = false;

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
}