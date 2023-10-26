using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    [HideInInspector]
    public Vector2 size;
    public Vector2 speed;
    public int damage;
    // public float 

    public void Start()
    {
        transform.localScale = size;
    }

    public void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        transform.position += direction * Time.deltaTime;
    }
}
