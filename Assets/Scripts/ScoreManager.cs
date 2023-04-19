using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int currentScore;

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        currentScore = 0;
        SetScore();
        GameManager.OnGameRestart += ResetScore;
    }

    private void OnDisable()
    {
        GameManager.OnGameRestart -= ResetScore;        
    }

    private void SetScore()
    {
        scoreText.text = $"Score : {currentScore}";
    }

    public void IncrementScore()
    {
        currentScore++;
        SetScore();
    }

    private void ResetScore()
    {
        currentScore = 0;
        SetScore();
    }
}
