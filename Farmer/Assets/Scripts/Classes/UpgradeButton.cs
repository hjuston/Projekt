using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
	// potrzebne?
	public BuildingType Type;

	void Start()
	{
		Button btn = gameObject.GetComponentInChildren<Button>();
		if(btn != null)
		{
			btn.onClick.AddListener(() => Helper.GetTileManager().SetBuildingOnCurrentTile(Type));
		}
	}
}
