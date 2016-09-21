using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject BuildingManagerObj;
	public GameObject BuildingButtonPanel;
	public GameObject BuildingUpgradeButton;

	public GameObject TileManager;

	// #####################
	private int _currentMoney = 0;
	// #####################

	void Start()
	{
		InitializeBuildingButtons();
	}


	/// <summary>
	/// Tworzenie przycisków za pomocą których można umieszczać budynki.
	/// </summary>
	void InitializeBuildingButtons()
	{
		Building[] buildings = Helper.GetBuildingManager().GetAllBuildings();
		foreach (Building building in buildings)
		{
			GameObject buildingButton = Button.Instantiate(building.ButtonPrefab);
			buildingButton.transform.SetParent(BuildingButtonPanel.transform);

			// Ustawianie nazwy przycisku
			Text btnText = buildingButton.GetComponentInChildren<Text>();
			if (btnText != null)
			{
				btnText.text = building.Name;
			}
		}
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

		// Wyczyszczenie Tile
		Helper.GetTileManager().CurrentTile.SetBuilding(null);
	}
}
