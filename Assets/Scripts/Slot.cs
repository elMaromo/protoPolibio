using System;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public string levelName;
    private LevelController _levelController;

    private void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.CompareTag("Player"))
        {
            _levelController.OnSlotTriggered(transform,levelName);
        }
    }
}