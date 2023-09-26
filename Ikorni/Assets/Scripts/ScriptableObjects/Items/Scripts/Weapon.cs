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
    public DamageType damageType;

    public void Awake()
    {
        type = ItemType.Weapon;
    }

    public int inflictDamage()
    {
        return Random.Range(minDamageDealt, maxDamageDealt);
    }
}
