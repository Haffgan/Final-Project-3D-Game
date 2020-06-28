using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool GamehasWon;

    public GameObject gameOverUI;
    public GameObject winningUI;

    WaveSpawner waveSpawner;
    PlayerHealth ph;

    void Start()
    {
        GameIsOver = false;
        GamehasWon = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if (GamehasWon)
            return;

        if (PlayerManager.Lives <= 0 || ph.currentHealth <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        SoundManager.PlaySound("gameOver");
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void Winning()
    {
        SoundManager.PlaySound("winning");
        GamehasWon = true;
        winningUI.SetActive(true);
    }
}
