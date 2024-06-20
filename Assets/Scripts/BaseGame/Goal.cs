using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ParticleSystem particles;
    private BallControllerV2 _ball;
    private CustomCamera cam;
    public event Action OnGoalScored;

    private void Awake()
    {
        cam = Camera.main.GetComponentInChildren<CustomCamera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<BallControllerV2>(out _ball))
        {
            ScoreGoal();
        }
    }

    private void ScoreGoal()
    {
        OnGoalScored?.Invoke();
        _ball.DestroyBall();
        particles.Play();
        cam.Shake();
    }
}