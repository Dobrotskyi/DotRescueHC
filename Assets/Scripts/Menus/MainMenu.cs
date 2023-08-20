using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void TryLaunchGameAfterAudio(AudioSource source)
    {
        StartCoroutine(LaunchGameAfterAudio(source));
    }

    private IEnumerator LaunchGameAfterAudio(AudioSource source)
    {
        while (source.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene("Game");
    }
}
