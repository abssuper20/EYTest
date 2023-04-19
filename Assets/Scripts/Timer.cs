using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private int currentTime;

    [Header("Time in seconds")]
    [SerializeField] private int totalTime;

    public static event Action OnTimerComplete;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameOverPanel;

    private void OnEnable()
    {
        GameManager.OnGameBegin += StartTimer;
        GameManager.OnGameRestart += ResetTimer;
    }
    private void OnDisable()
    {
        GameManager.OnGameBegin -= StartTimer;
        GameManager.OnGameRestart -= ResetTimer;
    }

    private void Start()
    {
        currentTime = totalTime;
        SetTimerText();
    }

    public void StartTimer()
    {
        StartCoroutine(BeginCountdown());
    }

    private IEnumerator BeginCountdown()
    {
        yield return new WaitForSeconds(1f);
        while (currentTime > 0)
        {
            currentTime -= 1;
            SetTimerText();
            yield return new WaitForSeconds(1f);
        }
        gameOverPanel.SetActive(true);
        mainMenuPanel.SetActive(true);
        OnTimerComplete?.Invoke();
    }

    private void SetTimerText()
    {
        timerText.text = $"Time remaining : {currentTime}";
    }

    private void ResetTimer()
    {
        currentTime = totalTime;
        SetTimerText();
    }
}
