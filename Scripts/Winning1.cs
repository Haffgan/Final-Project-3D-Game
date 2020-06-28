using UnityEngine.SceneManagement;
using UnityEngine;

public class Winning1 : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("DryLandLevel");
    }

    public void Next()
    {
        SceneManager.LoadScene("WinterLevel");
    }

    public void MainMenu()
    {
        Debug.Log("Go to main menu");
        SceneManager.LoadScene("MainMenu");
    }
}
