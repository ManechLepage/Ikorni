using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Items/Weapon")]
public class Weapon : ItemObject
{
    [Space]
    [Header("Weapon Stats")]
    public int minDamageDealt;
    public int maxDamageDealt;
    public int critPercentage;
    public int critMultiplierPercentage = 200;

    public void Awake()
    {
        type = ItemType.Weapon;
    }

    public int inflictDamage()
    {
        if (Random.Range(0, 100) <= critPercentage)
        {
            return Random.Range(minDamageDealt, maxDamageDealt) * critMultiplierPercentage / 100;
        }
        return Random.Range(minDamageDealt, maxDamageDealt);
    }
}
