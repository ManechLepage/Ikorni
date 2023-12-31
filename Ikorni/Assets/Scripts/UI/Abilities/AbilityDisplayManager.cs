using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDisplayManager : MonoBehaviour
{
    public AbilityDatabase database;
    public AbilityInventory inventory;

    public GameObject[] abilityPlacements = new GameObject[3];
    public GameObject[] abilityGameObjects = new GameObject[3];
    
    public void UpdateAbilities()
    {
        for (int i = 0; i < inventory.inventory.Length; i++)
        {
            if (inventory.inventory[i] != null)
            {
                if (abilityGameObjects[i] == null)
                {
                    GameObject ability = Instantiate(database.GetAbilityFromId(inventory.inventory[i].ID), abilityPlacements[i].transform);
                    abilityGameObjects[i] = ability;
                }
                else if (inventory.inventory[i].ID != abilityGameObjects[i].GetComponent<Ability>().ID)
                {
                    Destroy(abilityGameObjects[i]);
                    GameObject ability = Instantiate(database.GetAbilityFromId(inventory.inventory[i].ID), abilityPlacements[i].transform);
                    abilityGameObjects[i] = ability;
                }
            }
            else
            {
                if (abilityGameObjects[i] != null)
                {
                    Destroy(abilityGameObjects[i]);
                }
            }
        }
    }
}
