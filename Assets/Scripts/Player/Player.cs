using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action PlayerLost;

    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private GameObject _playersDot;
    [SerializeField] private AudioSource _audioSource;

    private float _rotationSpeed;
    private bool _antiClockwise = true;

    public void ChangeDirection()
    {
        _antiClockwise = !_antiClockwise;
        _audioSource.Play();
    }

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
        _rotationSpeed = newSpeed * 1.25f;
    }

    private void FixedUpdate()
    {
        int direction = _antiClockwise ? 1 : -1;
        transform.Rotate(0, 0, _rotationSpeed * direction, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            DestroySelf();
    }

    private void DestroySelf()
    {
        Instantiate(_explosionPrefab, _playersDot.transform.position, Quaternion.identity);
        _playersDot.SetActive(false);
        PlayerLost?.Invoke();
    }
}
