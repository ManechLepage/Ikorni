using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicInterface : UserInterface
{
    [Space]
    [Header("Inventory Placement")]
    public Vector2 INV_START;
    public Vector2 MARGIN_BETWEEN_ITEMS;
    public int NBR_OF_COLS;
    public override void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        
        for (int i = 0; i < inventory.container.items.Length; i++)
        {
            GameObject obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnClick(obj); });
            
            itemsDisplayed.Add(obj, inventory.container.items[i]);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(INV_START.x + (MARGIN_BETWEEN_ITEMS.x * (i % NBR_OF_COLS)), INV_START.y + (-MARGIN_BETWEEN_ITEMS.y * (i / NBR_OF_COLS)), 0f);
    }
}
