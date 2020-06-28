using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public static int Money;
    public int startMoney = 100;

    public static int Crate;
    public int startCrate = 100;

    public static int Lives;
    public int startLives = 10;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Crate = startCrate;
    }
}
