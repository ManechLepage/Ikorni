using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject inventory;
    public GameObject weaponPreview;
    public GameObject abilityUI;

    [Header("Scripts")]
    public Player player;
    public PlayerMovement playerMovement;
    public WeaponPreviewInterface weaponPreviewInterface;

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
            foreach (Ability ability in abilityInventory.inventory)
            {
                if (ability is Dash)
                {
                    if (ability.GetComponent<Ability>().canUse)
                    {
                        Dash dash = (Dash)ability.GetComponent<Ability>();
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
}