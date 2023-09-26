using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject inventory;
    public Player player;
    public bool isInventoryActive;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!player.mouseItem.isHoldingObj)
            {
                isInventoryActive = !isInventoryActive;
                inventory.SetActive(isInventoryActive);
            }
        }
    }
}
