using UnityEngine;

public class LevelLimit : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyParticles;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<BallControllerV2>(out var ball))
        {
            ball.DestroyBall(false);
            var particles=Instantiate(_destroyParticles, other.transform.position, Quaternion.identity);
            Destroy(particles,4);
        }
    }
}
