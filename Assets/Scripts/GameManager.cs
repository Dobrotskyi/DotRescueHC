using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action<float> SpeedChanged;

    public static bool GameIsOver = false;
    public static int ScoreReward => _scoreRewardByLevel[s_currentLevel];
    private static int s_currentLevel { set; get; } = 0;


    [SerializeField] private static List<int> _scoreRewardByLevel = new() { 10, 20, 30, 40, 50 };

    [SerializeField] private List<float> _obstacleSpeedByLevel;
    [SerializeField] private List<float> _scoreToFinishLevel;
    [SerializeField] private AudioSource _audioSource;

    private bool _maxLevelReached = false;

    private void Start()
    {
        s_currentLevel = 0;
        SpeedChanged?.Invoke(_obstacleSpeedByLevel[s_currentLevel]);
        GameIsOver = false;
        Player.PlayerLost += GameOver;
    }

    private void OnDisable()
    {
        Player.PlayerLost -= GameOver;
    }

    private void LateUpdate()
    {
        if (!_maxLevelReached && _scoreToFinishLevel[s_currentLevel] <= Score.CurrentScore)
        {
            s_currentLevel++;
            if (s_currentLevel == _scoreToFinishLevel.Count)
            {
                _maxLevelReached = true;
                s_currentLevel--;
                return;
            }
            SpeedChanged?.Invoke(_obstacleSpeedByLevel[s_currentLevel]);
        }
    }

    private void GameOver()
    {
        GameIsOver = true;
        _audioSource.Play();
        StartCoroutine(GoBackToMenu());
        PlayerScoreTracker.Instance.UpdateScore();
    }

    private IEnumerator GoBackToMenu()
    {
        while (_audioSource.isPlaying)
            yield return new WaitForEndOfFrame();

        SceneManager.LoadScene("MainMenu");
    }
}
