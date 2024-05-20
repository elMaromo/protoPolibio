using System;
using DG.Tweening;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ParticleSystem particles;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<BallControllerV2>(out var ball))
        {
            ball.DestroyBall();
            Camera.main.DOShakePosition(.5f,.77f);
            particles.Play();
        }
    }

}
