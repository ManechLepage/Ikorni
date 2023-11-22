using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New database", menuName = "Attack/ProjectileDatabase")]
public class ProjectileDatabase : ScriptableObject
{
    public List<ProjectilePrefab> projectiles = new List<ProjectilePrefab>();
}

[System.Serializable]
public class ProjectilePrefab
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