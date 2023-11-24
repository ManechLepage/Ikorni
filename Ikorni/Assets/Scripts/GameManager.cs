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

    [Header("Variables")]
    public bool isInventoryActive;
    [Space]
    public Item playerWeapon;

    [Header("Abilities")]
    public AbilityDatabase abilityDatabase;
    public int dashID;
    [Space]
    public List<GameObject> abilitiesPrefabs;
    void Start()
    {
        GameObject dash = Instantiate(abilitiesPrefabs[dashID], player.transform);
    }

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
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (abilityDatabase.abilities[dashID].canUse)
            {
                abilityDatabase.abilities[dashID].Use();
                // Transform abilityDatabase.abilities[dashID] in a Dash object
                Dash dash = (Dash)abilityDatabase.abilities[dashID];
                dash.rollDir = playerMovement.moveDir;
            }
        }

        if (abilityDatabase.abilities[dashID].canUse)
        {
            playerMovement.canMove = true;
        }
        else
        {
            playerMovement.canMove = false;
        }
    }

    public void UpdateWeaponList()
    {
        weaponPreviewInterface.UpdateWeaponList(player.playerData.weaponList);
    }
}
