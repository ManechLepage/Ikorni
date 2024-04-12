using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int health;
    public PlayerData playerData;
    public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;
    public bool isInMenu;
    public GameObject canvas;
    public GameObject UI;
    public GameObject end_screen;
    public RectTransform healthBar;
    public TextMeshProUGUI healthText;

    void Start()
    {
        health = playerData.maxHealth;
        UpdateHealthBar();
    }
    
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
    void Update()
    {
        // if(hp <= 0){
        //     gameObject.SetActive(false);
        //     UI.SetActive(false);
        //     end_screen.SetActive(true);
        // }
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthText.text = $"{health.ToString()} / {playerData.maxHealth.ToString()}";
        healthBar.localScale = new Vector3((float)health / (float)playerData.maxHealth, 1, 1);
    }

    public void HealPlayerByPercentage(float percentageAmount)
    {
        health += (int)(playerData.maxHealth * percentageAmount);
        if (health > playerData.maxHealth)
        {
            health = playerData.maxHealth;
        }
    }
}
