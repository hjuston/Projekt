using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
	public Tile CurrentTile;


	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast(ray, out hitInfo))
			{
				if (hitInfo.collider.gameObject.tag == "BuildingTile")
				{
					SelectTile(hitInfo.collider.gameObject);
				}
			}
		}
	}

	void SelectTile(GameObject tile)
	{
		if (tile != null)
		{
			Tile buildingTile = tile.GetComponent<Tile>();
			if (buildingTile != null)
			{
				if (CurrentTile != buildingTile)
				{
					if (CurrentTile != null)
						CurrentTile.gameObject.GetComponent<Renderer>().material.color = Color.white;

					CurrentTile = buildingTile;
					CurrentTile.gameObject.GetComponent<Renderer>().material.color = Color.gray;
				}
			}

			Helper.GetGUIManager().SetBuildingInfo(CurrentTile.Building);
		}
	}

	public void SetBuildingOnCurrentTile(BuildingType type)
	{
		Building building = Helper.GetBuildingManager().GetBuildingByType(type);
		CurrentTile.SetBuilding(building);
		Helper.GetGUIManager().SetBuildingInfo(CurrentTile.Building);
	}
}
