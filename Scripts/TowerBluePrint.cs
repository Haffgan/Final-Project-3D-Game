using System.Collections;
using UnityEngine;

[System.Serializable]
public class TowerBluePrint
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int crateCost;
    public int moneyCost;

    public int GetSellAmount()
    {
        return crateCost / 2;
    }
}
