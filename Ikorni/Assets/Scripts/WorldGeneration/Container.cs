using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Structure
{
    [Space]
    public GameObject[] lootPlacement;
    public float lootRarity;
    public List<LootType> lootTypes = new List<LootType>();
}