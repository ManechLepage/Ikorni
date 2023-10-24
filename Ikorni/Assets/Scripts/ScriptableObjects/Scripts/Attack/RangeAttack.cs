using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Range Attack", menuName = "Attack/Range Attack")]
public class RangeAttack : ScriptableObject
{
    public float timeWaveGap;
    public float bulletDamage;
    
    public List<Wave> waves = new List<Wave>();

    public List<Bullet> bullets = new List<Bullet>();
}

[System.Serializable]
public class Wave
{
    public float rotationMultiplier;
    [Space]
    
    public List<ShotRange> shotRanges = new List<ShotRange>();
    [HideInInspector]
    public Vector2 origin;
    public void UpdateShotRange(float deltaTime)
    {
        foreach (ShotRange shotRange in shotRanges)
        {
            shotRange.UpdateBulletPositions(origin, deltaTime, rotationMultiplier);
        }
    }
}

[System.Serializable]
public class ShotRange
{
    public Vector2 angleRange;
    [Space]
    public int nbrOfBullets;
    [HideInInspector]
    public List<Bullet> bullets = new List<Bullet>();
    [Space]
    public List<int> bulletIndex = new List<int>();

    public void UpdateBulletPositions(Vector2 origin, float deltaTime, float rotationMultiplier)
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.UpdatePosition(angleRange, nbrOfBullets, origin, deltaTime, rotationMultiplier);
        }
    }
}

[System.Serializable]
public class Bullet
{
    public BulletType bulletType;
    [Space]
    public float size;
    public float sizeMultiplier;
    [Space]
    public float speed;
    public float speedMultiplier;
    [Space]
    public bool canBounce;

    [HideInInspector]
    public Vector2 position;
    public void UpdatePosition(Vector2 angle, int nbrOfBullets, Vector2 origin, float deltaTime, float rotationMultiplier)
    {
        float bullet_angle = (Mathf.Abs(angle.y - angle.x) / (float) nbrOfBullets) * (deltaTime * rotationMultiplier);
        position = new Vector2(origin.x + (speed * speedMultiplier * deltaTime) * Mathf.Cos(bullet_angle), origin.y + (speed * speedMultiplier * deltaTime) * Mathf.Sin(bullet_angle));
    }
}

[System.Serializable]
public enum BulletType
{
    Normal,
    Explosive
}