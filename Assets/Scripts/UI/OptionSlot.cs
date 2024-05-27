using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSlot : MonoBehaviour
{
    private OptionsController optionsController;
    public GameObject optionsThing;

    private void Start()
    {
        optionsController = FindObjectOfType<OptionsController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.CompareTag("Player"))
        {
            optionsController.OnSlotTriggered(this.gameObject);

            if( optionsThing )
            {
                optionsThing.SetActive(true);
            }
        }
    }
}
