using System.Collections;
using TMPro;
using UnityEngine;

public class TimerScriptMemoria : MonoBehaviour
{
    private TMP_Text timerText;
    private float currentTimer;
    private bool isCounting;

    public void Start()
    {
        timerText = GetComponent<TMP_Text>();
        currentTimer = 0;
        isCounting = true;
    }

    public void Update()
    {
        if (!isCounting)
        {
            return;
        }

        currentTimer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentTimer / 60f);
        int seconds = Mathf.FloorToInt(currentTimer % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public float GetTimerAndStop()
    {
        isCounting = false;
        return currentTimer;
    }
}
