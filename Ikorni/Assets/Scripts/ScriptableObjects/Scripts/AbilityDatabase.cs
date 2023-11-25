using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Database", menuName = "Ability Database")]
public class AbilityDatabase : ScriptableObject
{
    public List<AbilityData> abilities = new List<AbilityData>();

    public int GetIdFromName(string name)
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            if (abilities[i].name == name)
            {
                return abilities[i].ID;
            }
        }
        return -1;
    }

    public GameObject GetAbilityFromId(int id)
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            if (abilities[i].ID == id)
            {
                return abilities[i].ability;
            }
        }
        return null;
    }
}

[System.Serializable]
public class AbilityData
{
    public int ID;
    public string name;
    public GameObject ability;
}