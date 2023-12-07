using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum State
{
    Normal,
    Rolling
}
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 moveDir;
    public float moveSpeed = 10f;
    public int hp = 10;
    public State state;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (state == State.Normal)
        {
            float moveX = 0f;
            float moveY = 0f;
            if (Input.GetKey(KeyCode.W))
            {
                moveY = 1f;
                RollDir = (0, 1, 0)
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveY = -1f;
                RollDir = (0, -1, 0)
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -1f;
                RollDir = (-1, 0, 0)
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveX = 1f;
                rollDir = new Vector3(1, 0, 0)
            }
            moveDir = new Vector3(moveX, moveY).normalized;
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
        if (state == State.Normal)
        {
            rb.velocity = moveDir * moveSpeed;
        }
    }

}