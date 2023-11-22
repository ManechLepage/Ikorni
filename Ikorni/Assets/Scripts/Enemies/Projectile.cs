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
    public Transform origin;
    // public float 

    public void Start()
    {
        transform.localScale = new Vector3(size.x, size.x, 1);
    }

    public void Update()
    {
        UpdateBullet();
    }

    public void UpdateBullet()
    {
        transform.position += direction * Time.deltaTime * speed.x;
        speed.x += speed.y * 0.01f;

        transform.localScale = new Vector3(size.x, size.x, 1);
        size.x += size.y * 0.01f;
        
    }
}
