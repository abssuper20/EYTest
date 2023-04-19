using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TargetPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int count;
    [SerializeField] private TargetMoveAxis targetMoveAxis;

    private List<MovingTarget> targetList;

    [SerializeField] private DiffcultyLevel currentDifficulty;

    private void Awake()
    {
        targetList = new List<MovingTarget>(count);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            InitTargets();
    }

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(targetPrefab, transform);
            obj.transform.position = spawnPoint.position;
            obj.GetComponent<MovingTarget>().SetDirection(targetMoveAxis);
            obj.GetComponent<MovingTarget>().SetSpeed(currentDifficulty.targetSpeed);
            targetList.Add(obj.GetComponent<MovingTarget>());
        }
    }

    private void OnEnable()
    {
        GameManager.OnGameBegin += InitTargets;
        GameManager.OnGameRestart += ResetTargets;
        Timer.OnTimerComplete += ResetTargets;
        GameManager.OnDifficultyUpdated += SetDifficulty;
    }

    private void OnDisable()
    {
        GameManager.OnGameBegin -= InitTargets;
        GameManager.OnGameRestart -= ResetTargets;
        Timer.OnTimerComplete -= ResetTargets;
        GameManager.OnDifficultyUpdated -= SetDifficulty;
    }

    private async void InitTargets()
    {
        foreach (var target in targetList)
        {
            target.enabled = true;
            if (currentDifficulty.difficultyProfileName.Equals("Easy"))
                await Task.Delay(1000);
            else
                await Task.Delay(500);

        }
    }

    private void ResetTargets()
    {
        foreach (var target in targetList)
        {
            target.enabled = false;
            target.transform.position = spawnPoint.position;
            target.gameObject.SetActive(true);
        }
    }

    private void SetDifficulty(DiffcultyLevel currentDiffcultyLevel)
    {
        foreach (var target in targetList)
        {
            target.SetSpeed(currentDiffcultyLevel.targetSpeed);
        }
    }
}

public enum TargetMoveAxis
{
    X = 1,
    XMinus = -1,
}