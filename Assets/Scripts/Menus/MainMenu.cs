using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highScoreField;
    [SerializeField] private TextMeshProUGUI _lastScoreField;

    [SerializeField] private AnimationCurve _showScoreSpeedCurve;
    [SerializeField] private float _animationDuration = 1.6f;


    public void TryLaunchGameAfterAudio(AudioSource source)
    {
        StartCoroutine(LaunchGameAfterAudio(source));
    }

    private IEnumerator LaunchGameAfterAudio(AudioSource source)
    {
        while (source.isPlaying)
            yield return new WaitForEndOfFrame();

        SceneManager.LoadScene("Game");
    }

    private void Start()
    {
        StartCoroutine(ShowScore());
    }

    private IEnumerator ShowScore()
    {
        _highScoreField.text = 0.ToString();
        _lastScoreField.text = 0.ToString();

        float speed = 1 / _animationDuration;
        float elapsedTime = 0;

        float highScore = PlayerScoreTracker.Instance.HighScore;
        float lastScore = PlayerScoreTracker.Instance.LastScore;

        while (elapsedTime < _animationDuration)
        {
            elapsedTime += speed * Time.deltaTime;
            _highScoreField.text = ((int)(_showScoreSpeedCurve.Evaluate(elapsedTime) * highScore)).ToString();
            _lastScoreField.text = ((int)(_showScoreSpeedCurve.Evaluate(elapsedTime) * lastScore)).ToString();
            yield return null;
        }

        _highScoreField.text = highScore.ToString();
        _lastScoreField.text = lastScore.ToString();
    }
}
