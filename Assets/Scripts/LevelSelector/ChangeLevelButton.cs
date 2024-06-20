using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChangeLevelButton : MonoBehaviour
{
    public bool isUp;
    public float amountMove;
    public float animDuration;
    public Transform buttonTr;

    private bool duringActivation;

    public List<Slot> slots;

    public void Start()
    {
        duringActivation = false;

        if (!isUp)
        {
            amountMove = -amountMove;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!duringActivation)
        {
            duringActivation = true;
            buttonTr.DOMoveY(amountMove, animDuration).SetRelative(true).OnComplete(ActivateButton);
        }
    }

    public void ActivateButton()
    {
        buttonTr.DOMoveY(-amountMove, animDuration).SetRelative(true).OnComplete(ReactivateButton);

        for (int currSlot = 0; currSlot < slots.Count; currSlot++)
        {
            if (isUp)
            {
                slots[currSlot].ChangeToPreviousLevel();
            }
            else
            {
                slots[currSlot].ChangeToNextLevel();
            }
        }
    }

    public void ReactivateButton()
    {
        duringActivation = false;
    }
}
