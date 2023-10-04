using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public abstract class UserInterface : MonoBehaviour
{

    public Player player;
    public InventoryObject inventory;

    public GameObject inventoryPrefab;
    [Space]

    public Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

    void Start()
    {
        for (int i = 0; i < inventory.container.items.Length; i++)
        {
            inventory.container.items[i].parent = this;
        }
        CreateSlots();
    }

    public abstract void CreateSlots();

    void Update()
    {
        UpdateSlots(); // Change system to prevent lag
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if (_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.ID].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);

                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1? "" : _slot.Value.amount.ToString("n0");
            }
            else 
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);

                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action) 
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        player.mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
        {
            player.mouseItem.hoverItem = itemsDisplayed[obj];
        }
    }
    public void OnExit(GameObject obj)
    {
        player.mouseItem.hoverObj =  null;
        player.mouseItem.hoverItem = null;
    }

    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(100, 100);
        mouseObject.transform.SetParent(transform.parent);
        if (itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            img.raycastTarget = false;
        }

        player.mouseItem.obj = mouseObject;
        player.mouseItem.item = itemsDisplayed[obj];
        player.mouseItem.isHoldingObj = true;
    }

    public void OnDragEnd(GameObject obj)
    {
        Destroy(player.mouseItem.obj);
        if (player.mouseItem.hoverObj != null)
        {
            MoveItem(obj);
        }
        player.mouseItem.item = null;
        player.mouseItem.isHoldingObj = false;
    }

    public void MoveItem(GameObject obj)
    {
        inventory.MoveItem(itemsDisplayed[obj], player.mouseItem.hoverItem.parent.itemsDisplayed[player.mouseItem.hoverObj]);
    }

    public void OnDrag(GameObject obj)
    {
        if (player.mouseItem.obj != null)
        {
            player.mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    public void OnClick(GameObject obj)
    {
        if (player.mouseItem.obj == null)
        {
            player.mouseItem.lastClickedObj = obj;
            player.mouseItem.lastClickedItem = itemsDisplayed[obj];
            if (player.mouseItem.lastClickedItem.ID >= 0)
            {
                gameObject.transform.parent.GetChild(2).GetComponent<ItemPreviewInterface>().UpdateItemPreview();
            }
            else
            {
                gameObject.transform.parent.GetChild(2).GetComponent<ItemPreviewInterface>().ClearItemPreview();
            }
        }
    }
    public bool canWeapon()
    {

        for (int i = 0; i < inventory.container.items.Length; i++)
        {
            if (inventory.container.items[i].item.ID >= 0)
            {
                if (inventory.database.GetItem[inventory.container.items[i].item.ID] is Weapon)
                {
                    Debug.Log("You already have a weapon");
                    return false;
                }
            }
            
        }

        Debug.Log("Weapon equiped");
        return true;
    }


    public bool checkForWeapons()
    {
        return false;
    }
}

public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;

    public bool isHoldingObj; 
    public GameObject lastClickedObj;
    public InventorySlot lastClickedItem;

}
