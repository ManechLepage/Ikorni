using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy
{
    public int attackSpeed;
    public int attackRange;
    [HideInInspector]
    public float timeBetweenAttack;
    public Transform player;
    public BoxCollider2D EnemyCollider;
    
    
    // Start is called before the first frame update
    void Start()
    {

        float resizedRange = 0.1111111f * attackRange + 0.8888888f;
       // Debug.Log(resizedRange);
        timeBetweenAttack = 10/attackSpeed;
    }
    public void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            Debug.Log("TOUCHE");
            hp -= 1;
            canMove = false;
        }
    }
    public void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            canMove = true;
        }
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update(); 
        calculateTarget(player.position);     
    }
}
