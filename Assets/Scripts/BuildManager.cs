using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TileNode selectedNode;
    public NodeUI nodeUI;
    public GameObject TurretPref;
    public GameObject TurretPref2;
    private TurretBase turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return Player.Money >= turretToBuild.cost; } }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
  

    public void SelectTurretToBuild(TurretBase turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBase GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(TileNode node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
