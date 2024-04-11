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
    public List<int> expSteps = new List<int>();

    [Space]
    public TextMeshProUGUI expLabel;
    public TextMeshProUGUI lvlLabel;
    public LevelUpgradeComponent levelUpgradeComponent;
    public GameObject expBar;

    void Start()
    {
        for (int i = 0; i < playerData.maxLevels; i++)
        {
            float value = (i + 1) / (float)playerData.maxLevels;
            expSteps.Add((int)(playerData.expToLevelCurve.Evaluate(value) * playerData.maxExp));
        }
        UpdateLevel();
    }

    public void UpdateLevel()
    {
        int _lvl = lvl;
        lvl = playerData.GetCurrentLevel(exp, expSteps);
        lvlLabel.text = lvl.ToString();

        localExp = playerData.GetExpAtLevel(lvl, exp, expSteps);
        expLabel.text = $"{localExp.ToString()} / {playerData.GetExpStepOfLevel(lvl, expSteps).ToString()}";

        expBar.GetComponent<RectTransform>().localScale = new Vector3(localExp / playerData.GetExpStepOfLevel(lvl, expSteps), 1, 1);
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
        playerData.HealPlayerByPercentage(0.2f);
        levelUpgradeComponent.Upgrade(lvl);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Add levels");
            AddExp(10f);
        }
    }
}