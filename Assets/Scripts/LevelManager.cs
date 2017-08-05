using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string sceneName)
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
            LoadNextLevel();
    }
}