using DG.Tweening;
using UnityEngine;

public class BallControllerV2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BallSpawner2 _ballSpawner;
    private bool isAlive;
    [SerializeField] private float _destroySpeedThreshold = .1f;

    public void Init(BallSpawner2 ballSpawner, Vector2 force)
    {
        _ballSpawner = ballSpawner;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void Awake()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
    }

    public void DestroyBall(bool withVisuals=true)
    {
        if (!isAlive) return;
        isAlive = false;
        if (!withVisuals)
        {
            _ballSpawner.OnBallDestroyed();
            Destroy(gameObject);
        }
        else
        {
            transform.DOScale(Vector3.zero, 1)
                .SetEase(Ease.InBack)
                .Play()
                .OnComplete(() =>
                {
                    _ballSpawner.OnBallDestroyed();
                    Destroy(gameObject);
                });
        }
    }

    private void Update()
    {
        if (rb.velocity.magnitude < _destroySpeedThreshold)
        {
            DestroyBall();
        }
    }
}