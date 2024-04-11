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
            expSteps.Add((int)(playerData.expToLevelCurve.Evaluate(0.8f) * playerData.maxExp));
            Debug.Log(expSteps[i]);
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

        expBar.GetComponent<RectTransform>().sizeDelta = new Vector2(playerData.GetExpBarLength(lvl, exp, expSteps) * 100, 10);
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