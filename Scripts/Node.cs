using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public TowerBluePrint towerBluePrint;
    [HideInInspector]
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

        if (tower != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTower(buildManager.GetTowerToBuild());
    }

    void BuildTower (TowerBluePrint blueprint)
    {
        if (PlayerManager.Crate < blueprint.crateCost)
        {
            Debug.Log("Not enough money.");
            return;
        }

        PlayerManager.Crate -= blueprint.crateCost;
        SoundManager.PlaySound("upgrade");
        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        towerBluePrint = blueprint;

        Debug.Log("Tower build!");
    }

    public void UpgradeTower()
    {
        if (PlayerManager.Money < towerBluePrint.moneyCost)
        {
            Debug.Log("Not enough money to upgrade.");
            return;
        }

        PlayerManager.Money -= towerBluePrint.moneyCost;
        SoundManager.PlaySound("upgrade");
        Destroy(tower);

        GameObject _tower = (GameObject)Instantiate(towerBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        isUpgraded = true;

        Debug.Log("Tower build!");
    }

    public void SellTower()
    {
        PlayerManager.Crate += towerBluePrint.GetSellAmount();
        Destroy(tower);
        isUpgraded = false;
        towerBluePrint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasCrate)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
