using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // #####################
    private int _currentMoney = 100;
    private int _generateMoneyCount = 0;
    private List<Building> currentBuildings = new List<Building>();
    // #####################

    void Start()
    {
        // Zliczanie gotówki
        InvokeRepeating("CollectMoney", 0f, 1f);
    }


    /// <summary>
    /// Metoda zlicza przychody z budynków i dodaje je do aktualnej gotówki
    /// </summary>
    void CollectMoney()
    {
        _currentMoney += _generateMoneyCount;

        Helper.GetGUIManager().SetMoneyInfo(_currentMoney);
    }

    /// <summary>
    /// Metoda dodaje do listy aktualnych budynków budynek przesłany w parametrze.
    /// Lista używana jest do zliczania gotówki.
    /// </summary>
    /// <param name="building"></param>
    public void AddBuildingToCurrentBuildingList(Building building)
    {
        _generateMoneyCount += building.GenerateMoney;
        Helper.GetGUIManager().SetMoneyGenerateInfo(_generateMoneyCount);
    }


    /// <summary>
    /// Metoda usuwa budynek z listy aktualnych budynków.
    /// Lista używana jest do zliczania gotówki.
    /// </summary>
    /// <param name="building"></param>
    public void RemoveBuildingFromCurrentBuildingList(Building building)
    {
        _generateMoneyCount -= building.GenerateMoney;
        Helper.GetGUIManager().SetMoneyGenerateInfo(_generateMoneyCount);
    }

    /// <summary>
    /// Metoda zwraca aktualną ilość gotówki.
    /// </summary>
    /// <returns></returns>
    public int GetCurrentMoney()
    {
        return _currentMoney;
    }


    /// <summary>
    /// Metoda powoduje zmniejszenie aktualnej gotówki (np. w wypadku kupna budynku).
    /// </summary>
    /// <param name="money"></param>
    public void SpendMoney(int money)
    {
        this._currentMoney -= money;
        Helper.GetGUIManager().SetMoneyInfo(_currentMoney);
    }
    

    /// <summary>
    /// Metoda oblicza cenę sprzedaży budynku.
    /// </summary>
    /// <param name="buildingPrice"></param>
    /// <returns></returns>
    public int CalculateSellPrice(int buildingPrice)
    {
        return Mathf.FloorToInt(buildingPrice / 2.54f);
    }


    /// <summary>
    /// Metoda, która powoduje sprzedanie budynku. Wywoływane przez przycisk SellButton
    /// </summary>
    public void SellBuilding()
    {
        // Przypisanie gotówki
        int sellPrice = CalculateSellPrice(Helper.GetTileManager().CurrentTile.Building.Cost);
        this._currentMoney += sellPrice;
        Helper.GetGUIManager().SetMoneyInfo(this._currentMoney);

        // Usuwanie budynku z listy budynków generujących gotówkę
        RemoveBuildingFromCurrentBuildingList(Helper.GetTileManager().CurrentTile.Building);

        // Wyczyszczenie Tile
        Helper.GetTileManager().CurrentTile.SetBuilding(null);
    }
}
