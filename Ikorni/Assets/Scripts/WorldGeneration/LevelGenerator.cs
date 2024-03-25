using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [HideInInspector] public List<GameObject> structures = new List<GameObject>();
    [HideInInspector] public List<GameObject> placements = new List<GameObject>();

    public GameObject placementPrefab;
    public GameObject wallPrefab;
    public StructureDataSet structureDataSet;
    public GameObject placementParent;
    public GameObject structureParent;
    public GameObject wallParent;
    public float wallMargin = 1f;

    private Dictionary<GameObject, float> structureRarity;

    [Header("Generation Settings")]
    public int levelWidth;
    public int levelHeight;
    public int structureCount;

    public void Start()
    {
        GeneratePlacements();
        structureRarity = GenerateStructureRarity();
        GenerateLevel();
        GenerateWalls();
    }

    public Dictionary<GameObject, float> GenerateStructureRarity()
    {
        Dictionary<GameObject, float> structureRarity = new Dictionary<GameObject, float>();
        foreach (GameObject structure in structureDataSet.structureArray)
        {
            structureRarity.Add(structure, structure.GetComponent<Structure>().rarity);
        }
        return structureRarity;
    }
    public void GeneratePlacements()
    {
        for (int i = 0; i < structureCount; i++)
        {
            GameObject placement = Instantiate(placementPrefab, new Vector3(Random.Range(-levelWidth/2, levelWidth/2), Random.Range(-levelWidth/2, levelHeight/2), 0), Quaternion.identity);
            placement.transform.SetParent(placementParent.transform);
        }
    }

    public void GenerateWalls()
    {
        GameObject wallN = Instantiate(wallPrefab, new Vector3(0, levelHeight/2 + wallMargin, 0), Quaternion.identity);
        wallN.transform.localScale = new Vector3(levelWidth + wallMargin, 1, 1);
        wallN.transform.SetParent(wallParent.transform);

        GameObject wallS = Instantiate(wallPrefab, new Vector3(0, -levelHeight/2 - wallMargin, 0), Quaternion.identity);
        wallS.transform.localScale = new Vector3(levelWidth + wallMargin, 1, 1);
        wallS.transform.SetParent(wallParent.transform);

        GameObject wallE = Instantiate(wallPrefab, new Vector3(levelWidth/2 + wallMargin, 0, 0), Quaternion.identity);
        wallE.transform.localScale = new Vector3(1, levelHeight + wallMargin, 1);
        wallE.transform.SetParent(wallParent.transform);

        GameObject wallW = Instantiate(wallPrefab, new Vector3(-levelWidth/2 - wallMargin, 0, 0), Quaternion.identity);
        wallW.transform.localScale = new Vector3(1, levelHeight + wallMargin, 1);
        wallW.transform.SetParent(wallParent.transform);
    }

    public void GenerateLevel()
    {
        foreach (Transform placement in placementParent.GetComponentInChildren<Transform>())
        {
            GameObject structure = Instantiate(RandomStructure(), placement.position, Quaternion.identity); 
        }
    }

    public GameObject RandomStructure()
    {
        float totalRarity = 0f;
        foreach (var pair in structureRarity)
        {
            totalRarity += pair.Value;
        }

        float randomValue = Random.Range(0f, totalRarity);

        foreach (var pair in structureRarity)
        {
            randomValue -= pair.Value;
            if (randomValue <= 0)
            {
                return pair.Key;
            }
        }
        return null;
    }
}