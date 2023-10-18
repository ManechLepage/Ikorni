using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPreviewInterface : MonoBehaviour
{
    public InventoryObject equipment;
    [SerializeField]
    private GameManager gameManager;
    [Header("WeaponList")]
    private List<InventorySlot> weaponList = new List<InventorySlot>();
    public bool canGoUp;
    public bool canGoDown;


    [Header("UI")]
    public Image imagePreview;
    private int currentWeaponIndex = 0;

    public void UpdateWeaponList(List<InventorySlot> _weaponList)
    {
        weaponList = _weaponList;
        currentWeaponIndex = 0;
        canGoUp = false;
        canGoDown = true;

        if (weaponList.Count > 0)
        {
            UpdateWeapon(currentWeaponIndex);
        }
        else
        {
            imagePreview.sprite = null;
        }
        
    }

    public void MoveUp()
    {
        if (canGoUp)
        {
            currentWeaponIndex--;
            UpdateWeapon(currentWeaponIndex);
            canGoDown = true;
            if (currentWeaponIndex == 0)
            {
                canGoUp = false;
            }
        }
    }

    public void MoveDown()
    {
        if (canGoDown)
        {
            currentWeaponIndex++;
            UpdateWeapon(currentWeaponIndex);
            canGoUp = true;
            if (currentWeaponIndex == weaponList.Count - 1)
            {
                canGoDown = false;
            }
        }
    }

    public void UpdateWeapon(int index)
    {
        imagePreview.sprite = equipment.database.GetItem[weaponList[index].item.ID].uiDisplay;
        gameManager.playerWeapon = weaponList[index].item;
    }
}
