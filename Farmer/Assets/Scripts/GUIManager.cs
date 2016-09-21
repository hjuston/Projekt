using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public Text MoneyLabel;
    public Text MoneyGenerateText;

	public Text BuildingNameLabel;
    public GameObject BuildingButtonPanel;

    public Button SellButton;


    void Start()
    {
        // Tworzenie przycisków do tworzenia farm
        InitializeBuildingButtons();
    }

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
    /// Metoda wyświetla informacje o gotówce generowanej w ciągu jednej sekundy.
    /// </summary>
    /// <param name="money"></param>
    public void SetMoneyGenerateInfo(int money)
    {
        MoneyGenerateText.text = money.ToString();
    }


	/// <summary>
	/// Metoda ustawia informacje o aktualnej gotówce.
	/// </summary>
	/// <param name="building"></param>
	public void SetMoneyInfo(int money)
	{
		MoneyLabel.text = money.ToString();

        // Ukrywanie/wyświetlanie przycisków w zależności od gotówki
        DisplayAvailableBuildingButtons(money);
	}


    /// <summary>
    /// Metoda ukrywa lub wyświetla przycisku w zależności od ilości gotówki
    /// </summary>
    void DisplayAvailableBuildingButtons(int money)
    {
        Button[] upgradeButtons = BuildingButtonPanel.GetComponentsInChildren<Button>(true);
        foreach(Button upgradeButton in upgradeButtons)
        {
            UpgradeButton script = GetButtonScript(upgradeButton);
            if(script != null)
            {
                upgradeButton.gameObject.SetActive(script.GetBuildingCost() > money ? false : true);
            }
        }
    }

    UpgradeButton GetButtonScript(Button btn)
    {
        UpgradeButton result = null;

        if (btn != null)
        {
            result = btn.GetComponentInParent<UpgradeButton>();
        }

        return result;
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
