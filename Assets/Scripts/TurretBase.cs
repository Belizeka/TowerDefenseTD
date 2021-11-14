using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBase
{
	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost = 10;

	public int GetSellAmount()
	{
		return cost / 2;
	}

}
