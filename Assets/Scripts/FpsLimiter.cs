using UnityEngine;

public class FpsLimiter : MonoBehaviour
{
    public bool UseTargetFramerate = true;
    public int FPS = 60;

    private void Start()
    {
        if (UseTargetFramerate)
            Application.targetFrameRate = FPS;
        else
            Application.targetFrameRate = -1;
    }
}
