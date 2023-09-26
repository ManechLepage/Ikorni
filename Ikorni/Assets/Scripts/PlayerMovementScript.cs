using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    private bool facingRight = true; // Flag to track the direction the character is facing


    public float runSpeed = 20.0f;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>(); 
        }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
{
   if (horizontal != 0 && vertical != 0) // Check for diagonal movement
   {
      // limit movement speed diagonally, so you move at 70% speed
      horizontal *= moveLimiter;
      vertical *= moveLimiter;
   }
   // Flip the character if moving left or right
   if (horizontal > 0 && !facingRight)
   {
        FlipCharacter();
    }
    else if (horizontal < 0 && facingRight)
    {
        FlipCharacter();
    }
    body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
}

private void FlipCharacter()
   {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
   }
}
