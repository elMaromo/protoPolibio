using UnityEngine;

public class LevelLimit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<BallControllerV2>(out var ball))
        {
            ball.DestroyBall(false);
        }
    }
}
