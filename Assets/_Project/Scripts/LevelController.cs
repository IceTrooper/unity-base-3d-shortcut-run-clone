using System.Collections;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static bool GamePaused = false;
    [SerializeField] private float timeForLevel = 60f;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject levelFinishedPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Player player;
    [SerializeField] private Timer timer;
    //private static LevelController instance;
    //public static LevelController Instance
    //{
    //    get
    //    {
    //        if(instance == null)
    //        {
    //            instance = FindObjectOfType<LevelController>();
    //        }
    //        return instance;
    //    }
    //}

    //public void LevelFinished()
    //{
    //    Debug.Log("Level Finished");
    //}
    private void Start()
    {
        GameManager.Instance.levelController = this;
        StartCoroutine(StartLevel());
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameOverPanel.activeSelf && !levelFinishedPanel.activeSelf)
        {
            if(pausePanel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private IEnumerator StartLevel()
    {
        timer.SetTimer(timeForLevel);
        yield return new WaitForSeconds(3f);
        player.movingEnabled = true;
        timer.StartTimer();
    }

    public void PauseGame()
    {
        GamePaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(GamePaused);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(GamePaused);
    }

    public void LevelFinished()
    {
        timer.StopTimer();
        player.movingEnabled = false;
        levelFinishedPanel.SetActive(true);
        scoreText.text = CalculateScore().ToString("F");
    }

    public void GameOver()
    {
        timer.StopTimer();
        gameOverPanel.SetActive(true);
    }

    private float CalculateScore()
    {
        return player.planksCount * 100f + timer.remainingTime/timeForLevel * 500f;
    }
}
