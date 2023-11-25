using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color Database", menuName = "Inventory System/Items/Color Database")]
public class ColorDatabase : ScriptableObject
{
    public List<Color> color = new List<Color>();
    public List<Colors> colors = new List<Colors>();
}

public enum Colors
{
    Black,
    Blue,
    Red,
    Green1,
    AbilityYellow
}
