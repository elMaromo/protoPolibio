using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class AbstractSwitch : MonoBehaviour
{
    public Transform activatedPos;
    public Transform deactivatedPos;
    public Transform switchTransform;
    public float timeToMove;

    protected bool activated;

    public virtual void ActivateSwitch()
    {
        activated = !activated;

        if (activated)
        {
            switchTransform.DOMove(activatedPos.position, timeToMove).SetRelative(true).SetEase(Ease.OutBack);
        }
        else
        {
            switchTransform.DOMove(deactivatedPos.position, timeToMove).SetRelative(true).SetEase(Ease.OutBack);
        }
    }
}
