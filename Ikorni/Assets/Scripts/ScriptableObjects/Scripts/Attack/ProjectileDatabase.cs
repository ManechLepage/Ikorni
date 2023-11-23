using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Attack/ProjectileType")]
public class ProjectileDatabase : ScriptableObject
{
    public List<BulletData> projectiles = new List<BulletData>();
}