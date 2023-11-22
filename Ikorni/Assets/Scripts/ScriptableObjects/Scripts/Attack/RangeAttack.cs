using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Range Attack", menuName = "Attack/Range Attack")]
public class RangeAttack : ScriptableObject
{
    public float timeWaveGap;
    public int bulletDamage;
    
    public List<Wave> waves = new List<Wave>();
}

[System.Serializable]
public class Wave
{
    public float rotationMultiplier;
    [Space]
    
    public List<ShotRange> shotRanges = new List<ShotRange>();
    [HideInInspector]
    public Vector2 origin;
    public void SetShotRange()
    {
        foreach (ShotRange shotRange in shotRanges)
        {
            shotRange.SetBulletDirection(origin, rotationMultiplier);
        }
    }
}

[System.Serializable]
public class ShotRange
{
    public Vector2 angleRange;
    [Space]
    public List<Bullet> bullets = new List<Bullet>();
    
    // [HideInInspector]
    
    // public List<int> bulletIndex = new List<int>();

    public void SetBulletDirection(Vector2 origin, float rotationMultiplier)
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.SetDirection(angleRange, bullets.Count, origin, rotationMultiplier, bullets.IndexOf(bullet));
        }
    }
}

[System.Serializable]
public class Bullet
{
    [Space]
    public int bulletIndex;

    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public float angle;
    public void SetDirection(Vector2 _angle, int bullets, Vector2 origin, float rotationMultiplier, int _bulletIndex)
    {
        angle = (Mathf.Abs(_angle.y - _angle.x) / (float) bullets) * _bulletIndex + Mathf.Min(_angle.x, _angle.y);
        // angle = (Mathf.Abs(_angle.y - _angle.x) / (float) bullets) * (deltaTime * rotationMultiplier);
        // direction = new Vector2(speed * speedMultiplier * Mathf.Cos(angle), speed * speedMultiplier * Mathf.Sin(angle));
        direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        direction = Vector3.Normalize(direction);
    }
}