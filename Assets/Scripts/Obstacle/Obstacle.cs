using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _rotationSpeed;
    private bool _antiClockwise = true;

    private void Awake()
    {
        GameManager.SpeedChanged += ChangeSpeed;
    }

    private void OnDisable()
    {
        GameManager.SpeedChanged -= ChangeSpeed;
    }

    private void ChangeSpeed(float newSpeed)
    {
        _rotationSpeed = newSpeed;
    }

    private void FixedUpdate()
    {
        int direction = _antiClockwise ? 1 : -1;
        transform.Rotate(0, 0, _rotationSpeed * direction, Space.Self);
    }

    private void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 3) + Random.value);
            _antiClockwise = !_antiClockwise;
        }
    }
}
