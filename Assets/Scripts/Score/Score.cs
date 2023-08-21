using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    public static float CurrentScore { private set; get; } = 0;


    private void Awake()
    {
        CurrentScore = 0;
        _scoreText.text = CurrentScore.ToString();
    }

    private void FixedUpdate()
    {
        CurrentScore += GameManager.ScoreReward * Time.fixedDeltaTime;
        _scoreText.text = ((int)CurrentScore).ToString();
    }
}
