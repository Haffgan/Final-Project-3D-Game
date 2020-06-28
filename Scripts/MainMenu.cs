using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("DryLandLevel");
    }

    public void Help()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
