using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CustomCamera:MonoBehaviour
{
    [SerializeField] float interpolationSpeed = 1.0f;
    private Vector3 _initialCamPosition;
    private Camera _cam;
    private bool _isResettingPosition;
    private void Awake()
    {
        _cam = GetComponentInChildren<Camera>();
        _initialCamPosition = _cam.transform.position;
    }

    private void Update()
    {
        if (_isResettingPosition)
        {
            ResetCameraPos();
        }
    }

    public void Shake()
    {
        _cam.DOShakePosition(.5f, .77f, 8, 70, true, ShakeRandomnessMode.Harmonic)
            .OnComplete(() => _isResettingPosition = true);
    }
    private void ResetCameraPos()
    {
        _cam.transform.position = Vector3.Lerp(transform.position,_initialCamPosition,interpolationSpeed*Time.deltaTime);
        if (Vector3.Distance(transform.position, _initialCamPosition) < 0.01f)
        {
            transform.position = _initialCamPosition;
            _isResettingPosition = false;
        }
    }
}