using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public PlayerData playerData;
    public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;
    public bool isInMenu;
    public GameObject canvas;
    public int hp = 10;
    public GameObject UI;
    public GameObject end_screen;

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
        if (other.CompareTag("bullet")){
            Debug.Log("hit");
            
            hp -= other.GetComponent<Projectile>().damage;
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
    void Update()
    {
        if(hp <= 0){
            gameObject.SetActive(false);
            UI.SetActive(false);
            end_screen.SetActive(true);
        }
    }
}
