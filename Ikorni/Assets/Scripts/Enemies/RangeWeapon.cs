using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    public RangeAttack data;
    public ProjectileDatabase projectileDatabase;
    private IEnumerator waveManager;
    public GameObject bulletParent;

    private int currentWaveIndex = 0;
    void Start()
    {
        waveManager = WaveManager();
        StartCoroutine(waveManager);
    }

    void Update()
    {

    }

    public IEnumerator WaveManager()
    {
        while (true)
        {
            GenerateNextWave();
            currentWaveIndex++;
            if (currentWaveIndex >= data.waves.Count)
            {
                currentWaveIndex = 0;
            }
            yield return new WaitForSeconds(data.timeWaveGap);
        }
    }

    public void GenerateNextWave()
    {
        Debug.Log($"Generating wave {currentWaveIndex}...", gameObject);
        
        data.waves[currentWaveIndex].origin = transform.position;
        data.waves[currentWaveIndex].SetShotRange();

        foreach (ShotRange shotRange in data.waves[currentWaveIndex].shotRanges)
        {
            foreach (Bullet bullet in shotRange.bullets)
            {
                ProjectilePrefab projectileData = projectileDatabase.projectiles[bullet.bulletIndex];
                GameObject _bullet = Instantiate(projectileData.projectile, transform.position, Quaternion.identity);
                _bullet.transform.SetParent(bulletParent.transform);
                _bullet.name = $"Wave {currentWaveIndex} | Angle {bullet.angle}";

                _bullet.GetComponent<Projectile>().direction = bullet.direction;
                _bullet.GetComponent<Projectile>().damage = data.bulletDamage;
                _bullet.GetComponent<Projectile>().size = new Vector2(projectileData.size, projectileData.sizeMultiplier);
                _bullet.GetComponent<Projectile>().speed = new Vector2(projectileData.speed, projectileData.speedMultiplier);
            }
        }
    }
}
