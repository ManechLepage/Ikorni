using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Object", menuName = "Items/Ability")]
public class AbilityItem : ItemObject
{
    [Header("Ability Stats")]
    public string abilityName;
    public void Awake()
    {
        type = ItemType.Ability;
    }
}
