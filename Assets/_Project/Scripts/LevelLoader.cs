using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private string levelBaseName = "Level_";

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadLevel(int i)
    {
        GameManager.Instance.currentLevel = i;
        SceneManager.LoadScene(levelBaseName + i);
    }

    public void LoadNextLevel()
    {
        GameManager.Instance.currentLevel++;
        SceneManager.LoadScene(levelBaseName + GameManager.Instance.currentLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
