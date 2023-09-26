using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Artifact
}

public enum Attribute
{
    Speed,
    MaxHealth,
    Defense
}

public enum DamageType
{
    Melee,
    Range,
    Fire,
    Poison
}

public abstract class ItemObject : ScriptableObject
{
    [Header("Item Stats")]
    public int ID;
    public Sprite uiDisplay;
    public ItemType type;
    public string itemName;
    public bool isStackable;
    
    [Header("Buffs & Resistances")]
    public ItemBuff[] buffs;
    public ResistanceBuff[] resistance;
    // public List<
    
    [Space]
    [Header("Description")]
    [TextArea(15, 20)]
    public string description;
    public List<RichText> richText = new List<RichText>();
}

[System.Serializable]
public class RichText
{
    public string text;
    public Colors color;
    public bool isBold;
    RichText(string _text, Colors _color, bool _isBold)
    {
        text = _text;
        color = _color;
        isBold = _isBold;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int ID;
    public Item()
    {
        Name = "";
        ID = -1;
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.ID;
    }
}


[System.Serializable]
public class ItemBuff
{
    public Attribute attribute;
    public int value;
}

[System.Serializable]
public class ResistanceBuff
{
    public DamageType damageType;
    public int value;
}