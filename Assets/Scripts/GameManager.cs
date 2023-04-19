using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DiffcultyLevel[] difficultyLevels;

    private DiffcultyLevel currentDifficultyLevel;

    private bool hasGameBegun;

    public static GameManager instance;

    public static event Action OnGameBegin;
    public static event Action OnGameRestart;
    public static event Action<DiffcultyLevel> OnDifficultyUpdated;

    private void Awake()
    {
        instance = this;
        currentDifficultyLevel = difficultyLevels[0];
    }

    private void OnEnable()
    {
        CountdownText.OnCountDownComplete += BeginGame;
    }

    private void OnDisable()
    {
        CountdownText.OnCountDownComplete -= BeginGame;        
    }

    public void BeginGame()
    {
        if (hasGameBegun) return;
        hasGameBegun = true;
        OnDifficultyUpdated?.Invoke(currentDifficultyLevel);
        OnGameBegin?.Invoke();
    }

    public void RestartGame()
    {
        hasGameBegun = false;
        OnGameRestart?.Invoke();
    }

    public void SetDifficulty(int index)
    {
        currentDifficultyLevel = difficultyLevels[index];
        OnDifficultyUpdated?.Invoke(currentDifficultyLevel);
    }
}
