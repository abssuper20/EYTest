using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownText : MonoBehaviour
{
    private TMP_Text countdownText;
    private int currentTime;

    public static event Action OnCountDownComplete;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject inGamePanel;

    private void Awake()
    {
        countdownText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        currentTime = 3;
        SetTimerText();
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(BeginCountdown());
    }

    private IEnumerator BeginCountdown()
    {
        yield return new WaitForSeconds(1f);
        while (currentTime > 1)
        {
            currentTime -= 1;
            SetTimerText();
            yield return new WaitForSeconds(1f);
        }
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(true);
        OnCountDownComplete?.Invoke();
        gameObject.SetActive(false);
    }

    private void SetTimerText()
    {
        countdownText.text = currentTime.ToString();
    }
}
