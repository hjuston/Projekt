using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Building  {

    public string Name;
    public int Cost;
    public int GenerateMoney;

    public GameObject Prefab;
    public GameObject ButtonPrefab;

    public BuildingType Type;
}
