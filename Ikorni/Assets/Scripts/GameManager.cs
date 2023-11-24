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
    public List<GameObject> abilitiesPrefabs = new List<GameObject>();
    [HideInInspector]
    public Dictionary<string, Ability> abilities = new Dictionary<string, Ability>();
    public int dashID;
    void Start()
    {
        GameObject dashObject = Instantiate(abilitiesPrefabs[dashID], abilityUI.transform);
        abilities.Add("dash", (Ability)dashObject.GetComponent<Dash>());
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
            if (abilities["dash"].canUse)
            {
                Dash dash = (Dash)abilities["dash"];
                dash.canUse = false;
                dash.rollSpeed = dash.defaultRollSpeed;
                dash.rollDir = playerMovement.moveDir;
                dash.Use();
            }
        }
    }

    public void UpdateWeaponList()
    {
        weaponPreviewInterface.UpdateWeaponList(player.playerData.weaponList);
    }
}
