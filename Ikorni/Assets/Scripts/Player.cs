using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;
    public bool isInMenu;
    public GameObject canvas;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            GroundItem item = other.GetComponent<GroundItem>();
            if (item.isGrabable)
            {
                Item _item = new Item(item.item);
                inventory.AddItem(_item, 1);
                Destroy(other.gameObject);
            }
        }
    }
    public void CollideTree()
    {
        canvas.SetActive(true);
        isInMenu = true;
    }
    private void OnApplicationQuit()
    {
        // Clear inventory on application quit
        // inventory.container.Clear();
    }
    public void AcceptButtonPressed(){
         SceneManager.LoadScene("TutorialTree", LoadSceneMode.Single);
    }
    public void DeclineButtonPressed(){
        canvas.SetActive(false);
        isInMenu = false;
    }
}
