using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public TurretBase TurretOne;
	public TurretBase TurretTwo;
	//public TurretBase laserBeamer;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectTurretOne()
	{
		buildManager.SelectTurretToBuild(TurretOne);
	}

	public void SelectTurretTwo()
	{
		buildManager.SelectTurretToBuild(TurretTwo);
	}

}
