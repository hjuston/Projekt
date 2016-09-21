using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public Text MoneyLabel;
    public Text MoneyGenerateText;

	public Text BuildingNameLabel;
    public GameObject BuildingButtonPanel;

    public Text UpgradeNumberText;

    public Button SellButton;
    public Button UpgradeButton;

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
            UpgradeNumberText.text = "";
			SetSellButtonAvailable(false);
            SetUpgradeButtonAvailable(false);
		}
		else
		{
			BuildingNameLabel.text = building.Name;
            UpgradeNumberText.text = building.UpgradeNumber.ToString();
			SetSellButtonAvailable(true);
            SetUpgradeButtonAvailable(true);
		}
	}

    /// <summary>
    /// Metoda wyświetla informacje o gotówce generowanej w ciągu jednej sekundy.
    /// </summary>
    /// <param name="money"></param>
    public void SetMoneyGenerateInfo(float money)
    {
        MoneyGenerateText.text = money.ToString();
    }


	/// <summary>
	/// Metoda ustawia informacje o aktualnej gotówce.
	/// </summary>
	/// <param name="building"></param>
	public void SetMoneyInfo(float money)
	{
		MoneyLabel.text =  Mathf.FloorToInt(money).ToString();

        // Ukrywanie/wyświetlanie przycisków w zależności od gotówki
        DisplayAvailableBuildingButtons(money);
	}


    /// <summary>
    /// Metoda ukrywa lub wyświetla przycisku w zależności od ilości gotówki
    /// </summary>
    void DisplayAvailableBuildingButtons(float money)
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
            int sellPrice = Helper.GetTileManager().CurrentTile.Building.GetSellPrice();
			SellButton.GetComponentInChildren<Text>().text = string.Format("Sprzedaj za {0}", sellPrice);
		}
	}


    /// <summary>
    /// Metoda aktywuje lub dezaktywuje przycisk UpgradeButton. W przypadku wyświetlenia zmieniany jest jego opis
    /// uwzględniając cenę ulepszenia budynku.
    /// </summary>
    /// <param name="available"></param>
    public void SetUpgradeButtonAvailable(bool available)
    {
        UpgradeButton.gameObject.SetActive(available);
        if(available)
        {
            int upgradePrice = Helper.GetTileManager().CurrentTile.Building.GetCost();
            UpgradeButton.GetComponentInChildren<Text>().text = string.Format("Ulepsz za {0}", upgradePrice);
        }
    }
}
