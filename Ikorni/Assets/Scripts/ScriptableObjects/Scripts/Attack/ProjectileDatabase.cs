using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New database", menuName = "Attack/ProjectileDatabase")]
public class ProjectileDatabase : ScriptableObject
{
    public List<Projectile> projectiles = new List<Projectile>();
}

[System.Serializable]
public class ProjectilePrefab
{
    public int ID;
    public GameObject projectile;
}
