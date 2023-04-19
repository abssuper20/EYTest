using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyProfile", menuName = "Difficulty/DifficultyProfile")]
public class DiffcultyLevel : ScriptableObject
{
    public string difficultyProfileName;

    [Header("For target variant 1")]
    public int minSpeed;
    public int maxSpeed;

    [Header("For target variant 2")]
    public int targetSpeed;
}
