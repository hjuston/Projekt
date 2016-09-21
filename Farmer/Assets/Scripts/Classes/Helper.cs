using UnityEngine;
using System.Collections;

public static class Helper {

	/// <summary>
	/// Metoda zwraca obiekt BuildingManager
	/// </summary>
	/// <returns></returns>
	public static BuildingManager GetBuildingManager()
	{
		BuildingManager result = null;

		GameObject buildingManagerObject = GameObject.FindGameObjectWithTag("BuildingManager");
		if (buildingManagerObject != null)
		{
			result = buildingManagerObject.GetComponent<BuildingManager>();
		}

		return result;
	}


	/// <summary>
	/// Metoda zwraca obiekt TileManager.
	/// </summary>
	/// <returns></returns>
	public static TileManager GetTileManager()
	{
		TileManager result = null;

		GameObject tileManagerObject = GameObject.FindGameObjectWithTag("TileManager");
		if (tileManagerObject != null)
		{
			result = tileManagerObject.GetComponent<TileManager>();
		}

		return result;
	}


	/// <summary>
	/// Metoda zwraca obiekt GameManager
	/// </summary>
	/// <returns></returns>
	public static GameManager GetGameManager()
	{
		GameManager result = null;

		GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
		if (gameManagerObject != null)
		{
			result = gameManagerObject.GetComponent<GameManager>();
		}

		return result;
	}


	/// <summary>
	/// Metoda zwraca obiekt GUIManager
	/// </summary>
	/// <returns></returns>
	public static GUIManager GetGUIManager()
	{
		GUIManager result = null;

		GameObject guiManagerObject = GameObject.FindGameObjectWithTag("GUIManager");
		if (guiManagerObject != null)
		{
			result = guiManagerObject.GetComponent<GUIManager>();
		}

		return result;
	}
}
