using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public Vector2 size;
    public Vector2 speed;
    public int damage;
    public float rotationMultiplier;
    public float timeToDespawn;
    private float startTime;
    public Vector3 origin;
    // public float 

    public void Start()
    {
        transform.localScale = new Vector3(size.x, size.x, 1);
        timeToDespawn = Time.time;
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

        transform.RotateAround(origin, Vector3.forward, rotationMultiplier);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, origin);
    }
}
