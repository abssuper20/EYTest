using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Time in seconds to complete movement")]
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    private float finalSpeed;

    [SerializeField] private GameObject targetObject;

    [SerializeField] private Transform endPoint;

    private MeshCollider targetCollider;

    private Vector3 targetStartPos;

    private void Awake()
    {
        targetCollider = transform.GetComponentInChildren<MeshCollider>();
        targetCollider.enabled = false;
        targetStartPos = targetObject.transform.position;
    }

    private void OnEnable()
    {
        Timer.OnTimerComplete += DisableTarget;
        GameManager.OnDifficultyUpdated += SetDifficulty;
        GameManager.OnGameRestart += ResetTargetPos;
    }

    private void ResetTargetPos()
    {
        targetObject.transform.position = targetStartPos;
    }

    private void OnDisable()
    {
        Timer.OnTimerComplete -= DisableTarget;        
        GameManager.OnDifficultyUpdated -= SetDifficulty;
        GameManager.OnGameRestart -= ResetTargetPos;
    }

    public void EnableTarget()
    {
        finalSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        LeanTween.moveX(targetObject, endPoint.position.x, finalSpeed).setLoopPingPong();
        targetCollider.enabled = true;
    }

    public void DisableTarget()
    {
        LeanTween.cancel(targetObject);
        targetCollider.enabled = false;
    }

    private void SetDifficulty(DiffcultyLevel currentDiffcultyLevel)
    {
        minMoveSpeed = currentDiffcultyLevel.minSpeed;
        maxMoveSpeed = currentDiffcultyLevel.maxSpeed;
    }
}
