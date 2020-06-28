using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBluePrint arrowTower;
    public TowerBluePrint cannonTower;
    public TowerBluePrint magicTower;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectArrowTower()
    {
        Debug.Log("Arrow Tower Purchased");
        buildManager.SelectTowerToBuild(arrowTower);
    }

    public void SelectCannonTower()
    {
        Debug.Log("Cannon Tower Purchased");
        buildManager.SelectTowerToBuild(cannonTower);
    }

    public void SelectMagicTower()
    {
        Debug.Log("Magic Tower Purchased");
        buildManager.SelectTowerToBuild(magicTower);
    }
}
