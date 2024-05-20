using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLevelX : MonoBehaviour
{
    public string LevelName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if( col.transform.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(LevelName);
            transform.DOMoveX(1,.2f).SetRelative(true).SetEase(Ease.OutBack).Play();
        }
    }
}
