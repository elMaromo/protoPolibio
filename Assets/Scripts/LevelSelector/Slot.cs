using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public float amountMoveUp;
    public float animChangeLevelduration;
    public string levelName;
    public List<GameObject>stars;
    public TextMeshProUGUI textSlot;

    private bool changingLevels;
    private int numStars;
    private Vector3 originalPos;
    private LevelController _levelController;

    private void Start()
    {
        changingLevels = false;
        _levelController = FindObjectOfType<LevelController>();
        originalPos = transform.position;
        numStars = GameManager.Instance.levelStars[Int32.Parse(textSlot.text)];
        ActivateStars();
    }


    private void ActivateStars()
    {
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);

        if( numStars > 0 )
        {
            stars[0].SetActive(true);
        }

        if( numStars > 1 )
        {
            stars[1].SetActive(true);
        }

        if( numStars > 2 )
        {
            stars[2].SetActive(true);
        }
    }





    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.CompareTag("Player"))
        {
            _levelController.OnSlotTriggered(transform, levelName);
        }
    }

    public void ChangeToNextLevel()
    {
        if (!changingLevels)
        {
            changingLevels = true;
            transform.DOMoveY(amountMoveUp, animChangeLevelduration).SetRelative(true).SetEase(Ease.OutExpo).OnComplete(NextLevel);
        }
    }

    private void NextLevel()
    {
        changingLevels = false;
        transform.position = originalPos;
        int currentLevel = Int32.Parse(textSlot.text);
        currentLevel++;
        textSlot.text = currentLevel.ToString();
        levelName = "Level" + currentLevel.ToString();
        numStars = GameManager.Instance.levelStars[Int32.Parse(textSlot.text)];
        ActivateStars();
    }

    public void ChangeToPreviousLevel()
    {
        if (!changingLevels)
        {
            changingLevels = true;
            transform.DOMoveY(-amountMoveUp, animChangeLevelduration).SetRelative(true).SetEase(Ease.OutExpo).OnComplete(PreviousLevel);
        }
    }

    private void PreviousLevel()
    {
        changingLevels = false;
        transform.position = originalPos;
        int currentLevel = Int32.Parse(textSlot.text);
        currentLevel--;
        textSlot.text = currentLevel.ToString();
        levelName = "Level" + currentLevel.ToString();
        numStars = GameManager.Instance.levelStars[Int32.Parse(textSlot.text)];
        ActivateStars();
    }

    public string GetLast(string source, int numberOfCharacters)
    {
        if (numberOfCharacters >= source.Length)
            return source;
        return source.Substring(source.Length - numberOfCharacters);
    }
}