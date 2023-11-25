using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Items/Artifact")]
public class Artifact : ItemObject
{
    public void Awake()
    {
        type = ItemType.Artifact;
    }
}
