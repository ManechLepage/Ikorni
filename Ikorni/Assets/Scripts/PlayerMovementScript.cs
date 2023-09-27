using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D body;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLenght = .5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    private bool facingLeft = true; // Flag to track the direction the character is facing


    public float runSpeed = 20.0f;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>(); 
        activeMoveSpeed = runSpeed;
        }

    void Update ()
    {
             if(Input.GetKeyDown(KeyCode.Mouse1)){
        Debug.Log("sapce");
        if(dashCoolCounter <=0 && dashCounter <=0){
            Debug.Log("dash");
            // activeMoveSpeed = dashSpeed;
            // dashCounter = dashLenght;
            body.velocity *= new Vector2(dashSpeed, dashSpeed);
        }
    }
    if(dashCounter > 0){
        dashCounter -= Time.deltaTime;
        if(dashCounter <= 0){
            activeMoveSpeed = runSpeed;
            dashCoolCounter = dashCooldown;
        }
    }
    if (dashCoolCounter > 0){
        dashCoolCounter -= Time.deltaTime;
    }
    }

    private void FixedUpdate()
{
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical");
   if (horizontal != 0 && vertical != 0) // Check for diagonal movement
   {
      // limit movement speed diagonally, so you move at 70% speed
      horizontal *= moveLimiter;
      vertical *= moveLimiter;
   }
   if (horizontal > 0 && facingLeft){
    FlipCharacter();
   }
    if (horizontal < 0 && !facingLeft){
    FlipCharacter();
   }
    body.velocity = new Vector2(horizontal, vertical) * activeMoveSpeed;



}

private void FlipCharacter()
   {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
   }


}