using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private Target[] targets;

    private bool roundBegan;

    private void OnEnable()
    {
        GameManager.OnGameBegin += StartGame;
    }

    private void OnDisable()
    {
        GameManager.OnGameBegin -= StartGame;        
    }

    public void ToggleTargets(bool val)
    {
        foreach (var target in targets)
        {
            if (val)
                target.EnableTarget();
            else
                target.DisableTarget();
        }
    }

    private void StartGame()
    {
        ToggleTargets(true);
    }
}
