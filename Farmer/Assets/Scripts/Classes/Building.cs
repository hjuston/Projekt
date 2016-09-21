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
    public int UpgradeNumber = 0;


    /// <summary>
    /// Metoda oblicza koszt budowli na podstawie poziomu ulepszenia
    /// </summary>
    /// <returns></returns>
    public int GetCost()
    {
        return Mathf.FloorToInt((float)Math.Pow(Math.E, UpgradeNumber) * Cost);
    }


    /// <summary>
    /// Metoda oblicza generowany przychód na podstawie poziomu ulepszenia
    /// </summary>
    /// <returns></returns>
    public int GetGenerateMoney()
    {
        return Mathf.FloorToInt((float)Math.Pow(Math.E, UpgradeNumber) * GenerateMoney);
    }


    /// <summary>
    /// Metoda oblicza kwotę, za którą można sprzedać budynek
    /// </summary>
    /// <returns></returns>
    public int GetSellPrice()
    {
        return Mathf.FloorToInt(Cost / 2.54f);
    }

    /// <summary>
    /// Metoda ulepsza budynek
    /// </summary>
    public void Upgrade()
    {
        UpgradeNumber++;
    }

    public Building GetCopy()
    {
        return this.MemberwiseClone() as Building;
    }
}
