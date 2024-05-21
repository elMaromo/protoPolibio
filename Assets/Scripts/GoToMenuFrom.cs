using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuFrom : MonoBehaviour
{
    public Transform tvButton;
    public float animationTime;
    public string menuSceneName;

    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Vector3 buttonPressedPosition = tvButton.position;
            buttonPressedPosition.z += 0.02f;
            tvButton.DOMove(buttonPressedPosition, animationTime/2 ).SetLoops(2, LoopType.Yoyo);
            GameManager.Instance.startFromTV = true;
            Invoke("LoadMenuScene", animationTime);
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}



