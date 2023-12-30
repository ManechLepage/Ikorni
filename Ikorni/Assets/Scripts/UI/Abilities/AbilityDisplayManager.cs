using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDisplayManager : MonoBehaviour
{
    public AbilityDatabase database;
    public AbilityInventory inventory;

    public GameObject[] abilityPlacements = new GameObject[3];
    public GameObject[] abilityPrefabs = new GameObject[3];
    
    public void UpdateAbilities()
    {
        for (int i = 0; i < inventory.inventory.Length; i++)
        {
            if (inventory.inventory[i] != null)
            {
                GameObject ability = Instantiate(database.GetAbilityFromId(inventory.inventory[i].ID), abilityPlacements[i].transform);
            }
        }
    }
}
