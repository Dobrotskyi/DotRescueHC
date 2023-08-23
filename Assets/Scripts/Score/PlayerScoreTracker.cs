using UnityEngine;

public class PlayerScoreTracker : Singleton<PlayerScoreTracker>
{
    private const string HIGHSCORE_KEY = "HighScore";
    private const string LAST_SCORE_KEY = "LastScore";

    public int HighScore
    {
        get
        {
            if (PlayerPrefs.HasKey(HIGHSCORE_KEY) == false)
                PlayerPrefs.SetInt(HIGHSCORE_KEY, 0);

            return PlayerPrefs.GetInt(HIGHSCORE_KEY);
        }
    }

    public int LastScore
    {
        get
        {
            if (PlayerPrefs.HasKey(LAST_SCORE_KEY) == false)
                PlayerPrefs.SetInt(LAST_SCORE_KEY, 0);

            return PlayerPrefs.GetInt(LAST_SCORE_KEY);
        }
    }

    public void UpdateScore()
    {
        if (Score.CurrentScore > HighScore)
            PlayerPrefs.SetInt(HIGHSCORE_KEY, (int)Score.CurrentScore);
        PlayerPrefs.SetInt(LAST_SCORE_KEY, (int)Score.CurrentScore);
    }
}
