using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 moveDir;
    public float moveSpeed = 10f;
    public float dashCooldown = 3f;
    private Vector3 rollDir;
    private bool canDash = true;
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
        rb = GetComponent<Rigidbody2D>();
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
                    if(canDash == true){
                        Debug.Log("mouse1");
                        rollDir = moveDir;
                        rollSpeed = 24f;
                        state = State.Rolling;
                        canDash = false;
                        StartCoroutine(DashTimer());
                    }
                    
                }
                break;
            case State.Rolling:
                float rollSpeedMultiplier = 2f;
                rollSpeed -= rollSpeed * rollSpeedMultiplier * Time.deltaTime;

                float rollSpeedMinimum = 20f;
                if (rollSpeed < rollSpeedMinimum){
                    state = State.Normal;
                }
                break;
            }
    }
    private IEnumerator DashTimer() {
        yield return new WaitForSeconds(3f); canDash = true;
        }
    
    void FixedUpdate(){
        switch (state) {
            case State.Normal:
                rb.velocity = moveDir * moveSpeed;
                break;
            case State.Rolling:
                rb.velocity = rollDir * rollSpeed;
                break;    
        }
    }
}