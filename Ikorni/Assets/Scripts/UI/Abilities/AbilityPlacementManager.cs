using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlacementManager : MonoBehaviour
{
    public List<Transform> abilityPlacementPoints;
    private int currentPlacementPointIndex = 0;

    public void PlaceAbility(GameObject ability)
    {
        ability.transform.position = abilityPlacementPoints[currentPlacementPointIndex].position;
        currentPlacementPointIndex++;
    }
}
