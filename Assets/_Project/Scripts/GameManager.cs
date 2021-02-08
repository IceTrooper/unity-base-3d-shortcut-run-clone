using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                //instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
                GameObject gameManager = new GameObject();
                gameManager.name = "GameManager";
                instance = gameManager.AddComponent<GameManager>();

            }
            return instance;
        }
    }

    public int currentLevel = -1;
    public LevelController levelController = null;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ResumeGame()
    {
        levelController.ResumeGame();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        levelController.GameOver();
    }

    public void LevelFinished()
    {
        levelController.LevelFinished();
    }
}
