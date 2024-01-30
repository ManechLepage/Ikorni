using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public enum State
{
    Idle,
    Rolling,
    Running
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
        //Debug.Log(state);
        if (state == State.Running || state == State.Idle)
        {
            float moveX = 0f;
            float moveY = 0f;
            if (Input.GetKey(KeyCode.W))
            {
                moveY = 1f;
                state = State.Running;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveY = -1f;
                state = State.Running;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -1f;
                state = State.Running;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveX = 1f;
                state = State.Running;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if(moveX == 0f && moveY == 0f)
            state = State.Idle;
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
        if (state == State.Running || state == State.Idle)
        {
            rb.velocity = moveDir * moveSpeed;
        }
    }

}