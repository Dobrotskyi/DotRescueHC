using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static float CurrentScore { private set; get; } = 0;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        CurrentScore = 0;
        _scoreText.text = CurrentScore.ToString();
    }

    private void FixedUpdate()
    {
        if (GameManager.GameIsOver)
            return;
        CurrentScore += GameManager.ScoreReward * Time.fixedDeltaTime;
        _scoreText.text = ((int)CurrentScore).ToString();
    }
}
