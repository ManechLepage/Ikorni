using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Inventory", menuName = "Ability Inventory")]
public class AbilityInventory : ScriptableObject
{
    public Ability[] inventory = new Ability[2];
    public AbilityDisplayManager abilityDisplayManager;

    public void AddItem(Ability ability)
    {
        int slot = GetLastSlot();
        if (slot == -1)
        {
            return;
        }
        inventory[slot] = ability;
    }

    public void ClearInventory()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = null;
        }
    }

    public int GetLastSlot()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

}
