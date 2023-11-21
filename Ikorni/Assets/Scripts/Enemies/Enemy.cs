using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public bool canMove = true;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    protected virtual void Update(){
        if(hp <= 0){
            gameObject.SetActive(false);
        }
    }

    void moveCharacter(Vector3 direction){
        // rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        gameObject.transform.position += direction * moveSpeed * Time.deltaTime;
    }
    public void calculateTarget(Vector3 target){
        Vector3 direction = target - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        //Debug.Log(movement);
        if(canMove == true){
            moveCharacter(movement);
        }
        
    }
}
