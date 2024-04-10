using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Main Player Stats")]
    public float speed;
    public int health;
    public int maxHealth;

    [Space]
    [Header("Player Defense Stats")]
    public int defensePercentage;

    [Space]
    [Header("Equipment Inventory")] 
    public InventoryObject equipmentInventory;
    public List<InventorySlot> weaponList;
    public AbilityInventory abilityInventory;
    
    [Space]
    [Header("Exp Level system")]
    public AnimationCurve expToLevelCurve;
    public int maxLevels;
    private List<int> levels = new List<int>();

    private float defaultSpeed;
    private int defaultHealth;
    private int defaultMaxHealth;
    private GameManager gameManager;
    
    public void Awake()
    {
        defaultSpeed = speed;
        defaultHealth = health;
        defaultMaxHealth = maxHealth;
        levels = GetLevelSteps();
    }

    public List<int> GetLevelSteps()
    {
        List<int> steps = new List<int>();
        for (int i = 0; i < maxLevels; i++)
        {
            steps.Add(expToLevelCurve[i + 1]);
        }
        return steps;
    }
    
    public int GetCurrentLevel(float exp)
    {
        for (int i = 0; i < maxLevels - 1; i++)
        {
            if (levels[i] < exp)
            {
                if (levels[i + 1 > exp])
                {
                    return i;
                }
            }
        }
        return null;
    }

    public float GetLevelProgression(int lvl, float exp)
    {
        float expInLvl = exp - levels[lvl];
        // todo
    }

    public void CheckEquipment()
    {
        ResetStats();

        for (int i = 0; i < equipmentInventory.container.items.Length; i++)
        {
            if (equipmentInventory.container.items[i].item.ID >= 0)
            {
                ItemBuff[] buffs = equipmentInventory.database.GetItem[equipmentInventory.container.items[i].item.ID].buffs;

                if (buffs.Length >= 0)
                {
                    for (int j = 0; j < buffs.Length; j++)
                    {
                        if (buffs[j].attribute == Attribute.Speed)
                        {
                            speed += buffs[j].value;
                        }
                        else if (buffs[j].attribute == Attribute.Defense)
                        {
                            defensePercentage += buffs[j].value;
                        }
                        else if (buffs[j].attribute == Attribute.MaxHealth)
                        {
                            maxHealth += buffs[j].value;
                        }
                    }
                }

                // ResistanceBuff[] itemResistanceBonus = equipmentInventory.database.GetItem[equipmentInventory.container.items[i].item.ID].resistance;
                // for (int j = 0; j < itemResistanceBonus.Length; j++)
                // {
                //     ResistanceBuff buff = new ResistanceBuff();
                //     buff.damageType = itemResistanceBonus[j].damageType;
                //     buff.value = itemResistanceBonus[j].value + itemResistanceBonus[j].stackValue * equipmentInventory.container.items[i].amount;
                //     buff.stackValue = -1;
                //     resistanceBonus.Add(buff);
                // }
            }
            
            if (equipmentInventory.container.items[i].item.ID >= 0)
            {
                if (equipmentInventory.database.GetItem[equipmentInventory.container.items[i].item.ID] is Weapon)
                {
                    weaponList.Add(equipmentInventory.container.items[i]);
                    // Debug.Log($"Added {equipmentInventory.container.items[i].item.Name} to weapon list");
                }
                else if (equipmentInventory.database.GetItem[equipmentInventory.container.items[i].item.ID] is AbilityItem)
                {
                    AbilityItem abilityItem = (AbilityItem)equipmentInventory.database.GetItem[equipmentInventory.container.items[i].item.ID];
                    Ability ability = abilityItem.ability.GetComponent<Ability>();
                    abilityInventory.AddItem(ability);
                    // if (!abilities.Contains(ability))
                    //     abilities.Add(ability);
                }
            }
        }
    }

    public void ResetStats()
    {
        speed = defaultSpeed;
        health = defaultHealth;
        maxHealth = defaultMaxHealth;
        defensePercentage = 0;
        weaponList = new List<InventorySlot>();
        abilityInventory.ClearInventory();

        // resistanceBonus.Clear();
    }
}
