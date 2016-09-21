using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public Text MoneyLabel;

	public Text BuildingNameLabel;

	public Button SellButton;

	/// <summary>
	/// Metoda ustawia informacje o budynku w panelu informacji.
	/// </summary>
	/// <param name="building"></param>
	public void SetBuildingInfo(Building building)
	{
		if (building == null)
		{
			BuildingNameLabel.text = "none";
			SetSellButtonAvailable(false);
		}
		else
		{
			BuildingNameLabel.text = building.Name;
			SetSellButtonAvailable(true);
		}
	}

	/// <summary>
	/// Metoda ustawia informacje o aktualnej gotówce.
	/// </summary>
	/// <param name="building"></param>
	public void SetMoneyInfo(int money)
	{
		MoneyLabel.text = money.ToString();
	}

	/// <summary>
	/// Metoda aktywuje lub dezaktywuje przycisk SellButton. W przypadku wyświetlenia zmieniany jest jego opis
	/// uwzględniając cenę sprzedaży budynku.
	/// </summary>
	/// <param name="available"></param>
	/// <param name="buildingCost"></param>
	public void SetSellButtonAvailable(bool available)
	{
		SellButton.gameObject.SetActive(available);
		if(available)
		{
			Building building = Helper.GetTileManager().CurrentTile.Building;

			int sellPrice = Helper.GetGameManager().CalculateSellPrice(building.Cost);
			SellButton.GetComponentInChildren<Text>().text = string.Format("Sprzedaj za {0}", sellPrice);
		}
	}
}
