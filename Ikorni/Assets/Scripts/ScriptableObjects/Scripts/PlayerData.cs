using System.Diagnostics;
using System;
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
    [Header("Player Damage Stats")]
    public ItemObject weapon;

    [Space]
    [Header("Player Defense Stats")]
    public int defensePercentage;

    [Space]
    [Header("Equipment Inventory")] 
    public InventoryObject equipmentInventory;

    private float defaultSpeed;
    private int defaultHealth;
    private int defaultMaxHealth;
    public void Awake()
    {
        defaultSpeed = speed;
        defaultHealth = health;
        defaultMaxHealth = maxHealth;
    }

    public void CheckEquipment()
    {
        ResetStats();
        bool isWeapon = false;

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
                    weapon = equipmentInventory.database.GetItem[equipmentInventory.container.items[i].item.ID];
                    isWeapon = true;
                }
            }
        }

        if (!isWeapon)
        {
            weapon = null;
        }
    }

    public void ResetStats()
    {
        speed = defaultSpeed;
        health = defaultHealth;
        maxHealth = defaultMaxHealth;
        defensePercentage = 0;

        // resistanceBonus.Clear();
    }
}
