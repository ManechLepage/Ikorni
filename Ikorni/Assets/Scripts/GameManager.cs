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
    public List<GameObject> currentAbilities = new List<GameObject>();
    public AbilityDatabase abilityDatabase;
    void Start()
    {
        AddAbility(abilityDatabase.GetIdFromName("Dash"), "dash");
    }

    public void AddAbility(int id, string name)
    {
        GameObject abilityObject = Instantiate(abilityDatabase.GetAbilityFromId(id), abilityUI.transform);

        abilityUI.GetComponent<AbilityPlacementManager>().PlaceAbility(abilityObject);

        currentAbilities.Add(abilityObject);
    }

    public void ClearAbilities()
    {
        foreach (GameObject currentAbility in currentAbilities)
        {
            Destroy(currentAbility);
        }
        currentAbilities.Clear();
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
            foreach (GameObject ability in currentAbilities)
            {
                if (ability.GetComponent<Ability>() is Dash)
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

    public void UpdateAbilityList()
    {
        ClearAbilities();
        AddAbility(abilityDatabase.GetIdFromName("Dash"), "Dash");
        // foreach (AbilityItem item in player.playerData.abilityList)
        // {
        //     Debug.Log($"Adding {item.abilityName} to ability list...");
        //     AddAbility(abilityDatabase.GetIdFromName(item.abilityName), item.abilityName);
        // }
    }
}