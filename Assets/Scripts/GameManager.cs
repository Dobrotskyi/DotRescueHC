using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<float> SpeedChanged;

    public static int CurrentLevel { private set; get; } = 0;
    public static int ScoreReward => _scoreRewardByLevel[CurrentLevel];

    [SerializeField] private static List<int> _scoreRewardByLevel = new() { 10, 20, 30, 40, 50 };

    [SerializeField] private List<float> _obstacleSpeedByLevel;
    [SerializeField] private List<float> _scoreToFinishLevel;
    private bool _maxLevelReached = false;

    private void Start()
    {
        CurrentLevel = 0;
        SpeedChanged?.Invoke(_obstacleSpeedByLevel[CurrentLevel]);
    }

    private void LateUpdate()
    {
        if (!_maxLevelReached && _scoreToFinishLevel[CurrentLevel] <= Score.CurrentScore)
        {
            CurrentLevel++;
            if (CurrentLevel == _scoreToFinishLevel.Count)
            {
                _maxLevelReached = true;
                CurrentLevel--;
                return;
            }
            SpeedChanged?.Invoke(_obstacleSpeedByLevel[CurrentLevel]);
        }
    }
}
