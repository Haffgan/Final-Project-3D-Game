using UnityEngine.SceneManagement;
using UnityEngine;

public class Winning : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("WinterLevel");
    }

    public void MainMenu()
    {
        Debug.Log("Go to main menu");
        SceneManager.LoadScene("MainMenu");
    }
}
