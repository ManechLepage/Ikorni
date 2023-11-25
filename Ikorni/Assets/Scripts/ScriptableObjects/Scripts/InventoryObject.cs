using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    public ItemDatabaseObject database;
    public PlayerData playerData;
    public Inventory container;

    public void AddItem(Item _item, int _amount)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].ID == _item.ID)
            {
                container.items[i].AddAmount(_amount);
                playerData.CheckEquipment();
                return;
            }
        }
        SetEmptySlot(_item, _amount);
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].ID <= -1)
            {
                container.items[i].UpdateSlot(_item.ID, _item, _amount);
                playerData.CheckEquipment();
                return container.items[i];
            }
        }
        
        //No place in inventory
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        bool canSwap = true;

        // if (item1.parent is EquipmentInferface)
        // {
        //     canSwap = item1.parent.checkForWeapons();
        // }
        // else if (item2.parent is EquipmentInferace)
        // {
        //     canSwap = item2.parent.checkForWeapons();
        // }
        
        if (canSwap)
        {
            InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount);
            item2.UpdateSlot(item1.ID, item1.item, item1.amount);
            item1.UpdateSlot(temp.ID, temp.item, temp.amount);
            playerData.CheckEquipment();
        }   
    }
}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] items = new InventorySlot[20];
}

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;
    public int ID = -1;
    public UserInterface parent;

    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }

    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
}
