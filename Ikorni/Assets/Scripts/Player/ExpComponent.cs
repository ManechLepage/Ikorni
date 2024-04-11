using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExpComponent : MonoBehaviour
{
    public PlayerData playerData;

    public float exp = 0;
    private float localExp = 0;
    public int lvl = 0;

    [Space]
    public TextMeshProUGUI expLabel;
    public TextMeshProUI lvlLabel;
    public LevelUpgradeComponent levelUpgradeComponent;
    public GameObject expBar;

    void Start()
    {
        UpdateLevel();
    }

    public void UpdateLevel()
    {
        int _lvl = lvl;
        lvl = playerData.GetCurrentLevel(exp);
        lvlLabel.text = lvl.ToString();

        localExp = playerData.GetExpAtLevel(lvl, exp);
        expLabel.text = $"{localExp.ToString()} / {playerData.GetExpToNextLevel(lvl).ToString()}";

        expBar.GetComponent<RectTransform>().sizeDelta = new Vector2(playerData.GetExpBarLength(lvl, exp) * 100, 10);
        if (_lvl != lvl)
        {
            OnLevelUp(lvl);
        }
    }

    public void AddExp(float amount)
    {
        exp += amount;
        UpdateLevel();
    }

    public void OnLevelUp(int lvl)
    {
        playerData.health = playerData.HealPlayerByPercentage(0.2f);
        levelUpgradeComponent.Upgrade(lvl);
    }
}