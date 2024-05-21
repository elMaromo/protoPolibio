using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoFromTVToChair : MonoBehaviour
{
    public Transform placeFromTV, placeChair;
    
    void Start()
    {
        if (GameManager.Instance.startFromTV)
        {
            Vector3 posInitPlayer = placeFromTV.position;
            transform.position = posInitPlayer;
            transform.rotation = placeFromTV.rotation;

            transform.DOMove(placeChair.position, GameManager.Instance.timeToMove);
            transform.DORotate(placeChair.eulerAngles, GameManager.Instance.timeToMove);
        }
    }
}
