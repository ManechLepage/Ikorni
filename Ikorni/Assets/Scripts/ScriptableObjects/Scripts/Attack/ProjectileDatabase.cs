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
    public int ID;
    public GameObject projectile;
}
