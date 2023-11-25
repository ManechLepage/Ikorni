using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{  
    [Header("Dash")] 
    private GameObject player;
    private PlayerMovement playerMovement;
    public float defaultRollSpeed;
    [HideInInspector]
    public float rollSpeed;
    public Vector3 rollDir;
    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        if (playerMovement.state == State.Rolling)
        {
            float rollSpeedMultiplier = 2f;
            rollSpeed -= rollSpeed * rollSpeedMultiplier * Time.deltaTime;

            float rollSpeedMinimum = 20f;
            if (rollSpeed < rollSpeedMinimum)
            {
                playerMovement.state = State.Normal;
            }
        }
    }

    void FixedUpdate()
    {
        if (playerMovement.state == State.Rolling)
        {
            player.GetComponent<Rigidbody2D>().velocity = rollDir * rollSpeed;
        }
    }

    public override void Use()
    {
        base.Use();
        playerMovement.state = State.Rolling;
    }
}
