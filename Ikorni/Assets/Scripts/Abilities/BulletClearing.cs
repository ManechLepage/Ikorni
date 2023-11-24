using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClearing : Ability
{
    [Header("Bullet Clearing")]
    public float clearingRadius;
    public GameObject clearingGameObject;
    public float clearingDuration;
    private GameObject player;

    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Use()
    {
        base.Use();
        Debug.Log("Clearing...");
    }
}
