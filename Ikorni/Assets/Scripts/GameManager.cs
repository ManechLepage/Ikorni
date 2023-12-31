using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject inventory;
    public GameObject weaponPreview;

    [Header("Scripts")]
    public Player player;
    public PlayerMovement playerMovement;
    public WeaponPreviewInterface weaponPreviewInterface;
    public AbilityDisplayManager abilityManager;

    [Header("Variables")]
    public bool isInventoryActive;
    [Space]
    public Item playerWeapon;

    [Header("Abilities")]
    public AbilityInventory abilityInventory;
    public AbilityDatabase abilityDatabase;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!player.mouseItem.isHoldingObj)
            {
                isInventoryActive = !isInventoryActive;
                inventory.SetActive(isInventoryActive);
                weaponPreview.SetActive(!isInventoryActive);
                UpdateWeaponList();
                UpdateAbilityList();
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponPreviewInterface.MoveUp();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponPreviewInterface.MoveDown();
        }
        else if (Input.GetKeyDown("up"))
        {
            weaponPreviewInterface.MoveUp();
        }
        else if (Input.GetKeyDown("down"))
        {
            weaponPreviewInterface.MoveDown();
        }
        
        // Abilities
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Mouse 1 pressed");
            foreach (Ability ability in abilityInventory.inventory)
            {
                if (ability != null && ability.ID == 0)
                {
                    Debug.Log($"There is Dash in inventory {ability.canUse}");
                    if (ability.canUse)
                    {
                        Debug.Log("Dashing...");
                        Dash dash = (Dash)ability;
                        dash.canUse = false;
                        dash.rollSpeed = dash.defaultRollSpeed;
                        dash.rollDir = playerMovement.moveDir;
                        dash.Use();
                    }
                }
            }
        }
    }

    public void UpdateWeaponList()
    {
        weaponPreviewInterface.UpdateWeaponList(player.playerData.weaponList);
    }

    public void UpdateAbilityList()
    {
        abilityManager.UpdateAbilities();
    }
}