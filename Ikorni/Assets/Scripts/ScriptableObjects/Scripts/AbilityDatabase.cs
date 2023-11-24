using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityDatabase", menuName = "AbilityDatabase")]
public class AbilityDatabase : ScriptableObject
{
    public List<Ability> abilities;
}
