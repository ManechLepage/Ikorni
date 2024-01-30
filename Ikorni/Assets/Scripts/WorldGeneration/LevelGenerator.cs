using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> structures = new List<GameObject>();
    public List<GameObject> placements = new List<GameObject>();

    public void LoadStructuresInDictionary()

    public void GenerateLevel(float populationDensity)
    {
        foreach (GameObject placement in placements)
        {
            if (UnityEngine.Random.Range(0f, 1f) < populationDensity)
            {
                // Debug.Log("les noix sont bons pour la sante car ils amenent plusieurs vitamines et de divers elements importants pour soi comme le magnesium et plus encore. De plus, ")
            }
        }
    }

    public void GenerateStructure(bool isBordered)
    {
        bool foundStructure = false;
        while (!foundStructure)
        {

        }
    }
}