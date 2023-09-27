using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    public float moveSpeed = 10f;
    private Vector3 rollDir;
    private float rollSpeed;
    private enum State{
        Normal,
        Rolling,
    }
    private State state;
    private void Awake(){
        state = State.Normal;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case State.Normal:
                float moveX = 0f;
                float moveY = 0f;
                if (Input.GetKey(KeyCode.W)){
                    moveY = 1f;
                }
                if (Input.GetKey(KeyCode.S)){
                    moveY = -1f;
                }
                if (Input.GetKey(KeyCode.A)){
                    moveX = -1f;
                }
                if (Input.GetKey(KeyCode.D)){
                    moveX = 1f;
                }
                moveDir = new Vector3(moveX, moveY).normalized;
                if(Input.GetKeyDown(KeyCode.Mouse1)){
                    rollDir = moveDir;
                    rollSpeed = 250f;
                    state = State.Rolling;
                }
                break;
            case State.Rolling:
                float rollSpeedMultiplier = 5f;
                rollSpeed -= rollSpeed * rollSpeedMultiplier * Time.deltaTime;

                float rollSpeedMinimum = 50f;
                if (rollSpeed < rollSpeedMinimum){
                    state = State.Normal;
                }
                break;
            }
    }
    void FixedUpdate(){
        switch (state) {
            case State.Normal:
                rigidbody2D.velocity = moveDir * moveSpeed;
                break;
            case State.Rolling:
                rigidbody2D.velocity = rollDir * rollSpeed;
                break;    
        }
    }
}