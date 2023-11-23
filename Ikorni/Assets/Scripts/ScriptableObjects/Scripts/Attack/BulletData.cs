using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Projectile", menuName = "Attack/ProjectileType")]
public class BulletData : ScriptableObject
{
    
    public GameObject projectile;
    public BulletType bulletType;
    [Space]
    public float size;
    public float sizeMultiplier;
    [Space]
    public float speed;
    public float speedMultiplier;
    [Space]
    public bool canBounce;
    [Space]
    public int ID;
}

[System.Serializable]
public enum BulletType
{
    Normal,
    Explosive,
    Healing,
    Poison
}
