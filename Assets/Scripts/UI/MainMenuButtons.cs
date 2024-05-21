using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Transform placeToPlay;
    public Transform playerCamera;
    public string nextSceneName;
    public float timeToMove;
    public float howCloseToTv;

    public void MoveToPlayPlace()
    {
        Vector3 posFinalPlayer = placeToPlay.position;
        posFinalPlayer += placeToPlay.forward * howCloseToTv;
        playerCamera.DOMove(posFinalPlayer, timeToMove );
        playerCamera.DORotate(placeToPlay.eulerAngles, timeToMove);
        GameManager.Instance.LoadScenewithDelay(nextSceneName, timeToMove);
        this.gameObject.SetActive(false);
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }

}
