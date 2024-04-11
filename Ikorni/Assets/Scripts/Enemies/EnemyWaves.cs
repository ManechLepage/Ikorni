using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyWaves")]
public class EnemyWaves : ScriptableObject
{
    public List<WaveWithCooldown> waves = new List<WaveWithCooldown>();
}

[System.Serializable]
public class WaveWithCooldown
{
    public EnemyWave wave;
    public float cooldown;
}
