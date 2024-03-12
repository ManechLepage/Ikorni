using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public StructureDataSet structures;
    public List<GameObject> placements = new List<GameObject>();

    public void LoadStructuresInDictionary()
    {
        
    }

    public void GenerateLevel()
    {
        foreach (GameObject placement in placements)
        {
            GenerateStructure(placement.GetComponent<PlacementSettings>().isBorder, placement.transform.position);
        }
    }

    public void GenerateStructure(bool isBordered, Vector2 positionOfPlacement)
    {
        GameObject structure = null;
        while (structure != null)
        {
            structure = structures.structureArray[Random.Range(0, structures.structureArray.Length)];
            bool isStructureValid = false;
            if (structure.GetComponent<Structure>().isBorderStructure == isBordered)
            {
                if (structure.GetComponent<Structure>().rarity > Random.Range(0f, 1f))
                {
                    isStructureValid = true;
                }
            }
            if (!isStructureValid)
            {
                structure = null;
            }
        }
        GameObject newStructure = Instantiate(structure);
        newStructure.transform.position = positionOfPlacement;
    }

    private void Start() 
    {
        GenerateLevel();
    }
}