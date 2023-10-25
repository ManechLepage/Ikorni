using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    public RangeAttack data;
    public ProjectileDatabase projectileDatabase;

    private int currentWaveIndex = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public IEnumerator GenerateNextWave()
    {
        yield return new WaitForSeconds(data.timeWaveGap);
    }
}
