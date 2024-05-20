using System.Collections;
using System.Collections.Generic;
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
        }
    }
}
