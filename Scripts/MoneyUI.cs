using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;
    public Text crateText;

    void Update()
    {
        moneyText.text = PlayerManager.Money.ToString();
        crateText.text = PlayerManager.Crate.ToString();
    }
}
