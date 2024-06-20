using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoToChair : MonoBehaviour
{
    public Transform placeFromTV, placeFarAway;

    public void Start()
    {
        if (GameManager.Instance.startFromTV)
        {
            Vector3 posInitPlayer = placeFromTV.position;
            posInitPlayer += placeFromTV.forward;
            transform.position = posInitPlayer;
            transform.rotation = placeFromTV.rotation;

            transform.DOMove(placeFarAway.position, GameManager.Instance.timeToMove);
            transform.DORotate(placeFarAway.eulerAngles, GameManager.Instance.timeToMove);
        }
    }
}
