using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 moveDir;
    public float moveSpeed = 10f;
    public int hp = 1;
    public bool canMove = true;
    [HideInInspector]
    public float rollSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            float moveX = 0f;
            float moveY = 0f;
            if (Input.GetKey(KeyCode.W))
            {
                moveY = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveY = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveX = 1f;
            }
            moveDir = new Vector3(moveX, moveY).normalized;
        }

        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    void FixedUpdate()
    {
        // switch (state) {
        //     case State.Normal:
        //         rb.velocity = moveDir * moveSpeed;
        //         break;
        //     case State.Rolling:
        //         rb.velocity = rollDir * rollSpeed;
        //         break;    
        // }
        if (canMove)
        {
            rb.velocity = moveDir * moveSpeed;
        }
    }
}