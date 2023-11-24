using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{   
    private GameObject player;
    public float rollSpeed;
    public Vector3 rollDir;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (!canUse)
        {
            float rollSpeedMultiplier = 2f;
            rollSpeed -= rollSpeed * rollSpeedMultiplier * Time.deltaTime;

            float rollSpeedMinimum = 20f;
            if (rollSpeed < rollSpeedMinimum)
            {
                canUse = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!canUse)
        {
            player.GetComponent<Rigidbody2D>().velocity = rollDir * rollSpeed;
        }
    }

    public override void Use()
    {
        base.Use();
        Debug.Log("Dash used");
    }
}
