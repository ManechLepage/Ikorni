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
    public void SetShotRange(float deltaTime)
    {
        foreach (ShotRange shotRange in shotRanges)
        {
            shotRange.SetBulletDirection(origin, deltaTime, rotationMultiplier);
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

    public void SetBulletDirection(Vector2 origin, float deltaTime, float rotationMultiplier)
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.SetDirection(angleRange, bullets.Count, origin, deltaTime, rotationMultiplier);
        }
    }
}

[System.Serializable]
public class Bullet
{
    public int bulletIndex;
    [Space]
    public float size;
    public float sizeMultiplier;
    [Space]
    public float speed;
    public float speedMultiplier;
    [Space]
    public bool canBounce;

    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public float angle;
    public void SetDirection(Vector2 _angle, int nbrOfBullets, Vector2 origin, float deltaTime, float rotationMultiplier)
    {
        angle = (Mathf.Abs(_angle.y - _angle.x) / (float) nbrOfBullets) * (deltaTime * rotationMultiplier);
        direction = new Vector2(speed * speedMultiplier * deltaTime * Mathf.Cos(angle), speed * speedMultiplier * deltaTime * Mathf.Sin(angle));
        direction = Vector3.Normalize(direction);
    }
}

[System.Serializable]
public enum BulletType
{
    Normal,
    Explosive
}