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

    public GameObject expBar;

    void Start()
    {
        UpdateLevel();
    }

    public void UpdateLevel()
    {
        lvl = playerData.GetCurrentLevel(exp);
        lvlLabel.text = lvl.ToString();

        localExp = playerData.GetExpAtLevel(lvl, exp);
        expLabel.text = $"{localExp.ToString()} / {playerData.GetExpToNextLevel(lvl).ToString()}";

        expBar.GetComponent<RectTransform>().sizeDelta = new Vector2(playerData.GetExpBarLength(lvl, exp) * 100, 10);
    }
}
