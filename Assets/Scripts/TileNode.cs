using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileNode : MonoBehaviour
{
	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 positionOffset;

	public GameObject turret;
	public TurretBase turretBlueprint;
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

		if (!buildManager.CanBuild)
            return;
  
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBase blueprint)
    {
        if (Player.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        Player.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

    }

    public void UpgradeTurret()
	{
		if (Player.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("Not enough money to upgrade that!");
			return;
		}

		Player.Money -= turretBlueprint.upgradeCost;

		Destroy(turret);

		GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		isUpgraded = true;
	}

	public void SellTurret()
	{
		Player.Money += turretBlueprint.GetSellAmount();
		Destroy(turret);
		turretBlueprint = null;
	}


	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
