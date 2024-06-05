using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    private bool canSelect;
    public float moveAmount;
    public float timeToMove;

    private GameObject currentSlot;
    private GameObject previousSlot;

    private void Awake()
    {
        canSelect = true;
    }

    public void OnSlotTriggered(GameObject slot)
    {
        if (!canSelect) return;
        if (currentSlot == slot)
        {
            return;
        }
        UpdateSlots(slot);
        DeselectPrevious();
        SelectCurrent();
    }

    private void UpdateSlots(GameObject slot)
    {
        previousSlot = currentSlot;
        currentSlot = slot;
    }

    private void SelectCurrent()
    {
        canSelect = false;
        currentSlot.transform.DOMoveX(moveAmount, timeToMove).SetRelative(true).SetEase(Ease.OutBack).OnComplete(() => canSelect = true);
    }

    private void DeselectPrevious()
    {
        if (previousSlot)
        {
            previousSlot.transform.DOMoveX(-moveAmount, timeToMove).SetRelative(true).SetEase(Ease.OutBack).OnComplete(() => canSelect = true);
            GameObject optionsThingOptional = previousSlot.GetComponent<OptionSlot>().optionsThing;
            if (optionsThingOptional)
            {
                optionsThingOptional.SetActive(false);
            }
        }
    }
}
