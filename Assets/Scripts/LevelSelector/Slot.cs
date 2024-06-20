using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public TextMeshProUGUI textSlot;
    public string levelName;
    private LevelController _levelController;
    public float amountMoveUp;
    public float animChangeLevelduration;
    private bool changingLevels;

    private Vector3 originalPos;

    private void Start()
    {
        changingLevels = false;
        _levelController = FindObjectOfType<LevelController>();
        originalPos = transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.CompareTag("Player"))
        {
            _levelController.OnSlotTriggered(transform, levelName);
        }
    }



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeToNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeToPreviousLevel();
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
    }

    public string GetLast(string source, int numberOfCharacters)
    {
        if (numberOfCharacters >= source.Length)
            return source;
        return source.Substring(source.Length - numberOfCharacters);
    }
}