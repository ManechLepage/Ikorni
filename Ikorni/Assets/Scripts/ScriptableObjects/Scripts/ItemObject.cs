using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Artifact,
    Ability
}

public enum Attribute
{
    Speed,
    MaxHealth,
    Defense,
    Damage
}

public enum Rarity
{
    Uncommon,
    Rare,
    Legendary
}

public abstract class ItemObject : ScriptableObject
{
    [Header("Item Stats")]
    public int ID;
    public Sprite uiDisplay;
    public ItemType type;
    public string itemName;
    public bool isStackable;
    public Rarity rarity;
    
    [Header("Buffs")]
    public ItemBuff[] buffs;

    [Header("Enchantments")]
    public Enchantment[] enchantments;
    
    [Space]
    [Header("Description")]
    [TextArea(15, 20)]
    public string description;
    public List<RichText> richText = new List<RichText>();

    public CustomItemEffect customItemEffect;
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
    public int stackValue;
}

public enum EnchantmentRegionType
{
    All,
    NeighboringWithDiagonal,
    NeighboringWithoutDiagonal,
    AllRight,
    AllLeft,
    AllUp,
    AllDown
}

[System.Serializable]
public class Enchantment
{
    public int value;
    public EnchantmentRegionType regionType;
    public List<Vector2> enchantmentRange = new List<Vector2>();
}