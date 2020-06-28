using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    private TowerBluePrint towerToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;
    
    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasCrate { get { return PlayerManager.Crate >= towerToBuild.crateCost; } }

    public  void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        towerToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTowerToBuild(TowerBluePrint tower)
    {
        towerToBuild = tower;
        DeselectNode();
    }

    public TowerBluePrint GetTowerToBuild()
    {
        return towerToBuild;
    }
}
