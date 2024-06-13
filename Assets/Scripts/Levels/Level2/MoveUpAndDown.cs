using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float moveAmount;
    public float timeToMove;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.DOMoveY(moveAmount, timeToMove).SetLoops(-1, LoopType.Yoyo);
    }
}
