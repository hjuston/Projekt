using UnityEngine;
using System.Collections;
using System;

public class BuildingManager : MonoBehaviour {

    public Building[] Buildings;
    
    public Building[] GetAllBuildings()
    {
        return Buildings;
    }

    public Building GetBuildingByType(BuildingType type)
    {
        foreach(Building building in Buildings)
        {
            if (building.Type == type) return building;
        }

        return null;
    }
}
