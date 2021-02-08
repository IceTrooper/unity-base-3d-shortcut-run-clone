using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    public float remainingTime = 10f;
    private bool isRunning;

    private void Start()
    {
        SetTimerText();
    }

    private void Update()
    {
        if(isRunning && remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;

            if(remainingTime < 0f)
            {
                remainingTime = 0f;
            }
            SetTimerText();
        }
    }

    public void SetTimer(float time)
    {
        remainingTime = time;
        SetTimerText();
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void SetTimerText()
    {
        timerText.text = remainingTime.ToString("F");
    }
}
