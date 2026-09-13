using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void StartPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("GameWin");
    }

    public void LooseGame()
    {
        SceneManager.LoadScene("GameLoose");
    }

    public void GoToPreferences()
    {
        SceneManager.LoadScene("Preferences");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        // exit the game for real play
        Application.Quit();
        //does not work in Unity since it would  lose all settings. so:
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
