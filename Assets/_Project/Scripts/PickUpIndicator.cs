using TMPro;
using UnityEngine;

public class PickUpIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text indicatorText;
    [SerializeField] private float fadeTime = 3f;
    private float remainingTime;
    private int pickUpCounter;

    private void Update()
    {
        if(remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            indicatorText.text = "+" + pickUpCounter.ToString();
            indicatorText.enabled = true;
        }
        else
        {
            pickUpCounter = 0;
            indicatorText.enabled = false;
        }
    }

    public void PickedUp()
    {
        pickUpCounter++;
        remainingTime = fadeTime;
    }
}
