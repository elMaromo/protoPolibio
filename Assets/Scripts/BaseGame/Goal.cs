using System;
using DG.Tweening;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ParticleSystem particles;
    private BallControllerV2 _ball;
    private Vector3 initialCamPosition;
    public event Action OnGoalScored;
    private Camera cam;
    private void Awake()
    {
        cam=Camera.main;
        initialCamPosition = cam.transform.position;
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
        Camera.main.DOShakePosition(.5f, .77f,8,70,true,ShakeRandomnessMode.Harmonic)
            .OnComplete(() => cam.transform.position = initialCamPosition);
        particles.Play();
        _ball.DestroyBall();
    }
}