using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver1 : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("DryLandLevel");
    }

    public void MainMenu()
    {
        Debug.Log("Go to main menu");
        SceneManager.LoadScene("MainMenu");
    }
}
