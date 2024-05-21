using System;
using DG.Tweening;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ParticleSystem particles;
    private BallControllerV2 _ball;
    public event Action OnGoalScored;

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
        Camera.main.DOShakePosition(.5f, .77f);
        particles.Play();
        _ball.DestroyBall();
    }
}