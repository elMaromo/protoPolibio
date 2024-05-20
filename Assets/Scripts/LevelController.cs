using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private string currentLevel;
    private Transform currentSlot;
    public bool Debug;
    public void OnSlotTriggered(Transform slotTransform, string levelName)
    {
        currentLevel = levelName;
        Invoke(nameof(ChangeScene), 1);
        if (currentSlot)
        {
            DeselectSlot(currentSlot);
        }
        SelectSlot(slotTransform);
    }

    private void ChangeScene()
    {
        if (Debug) return;
        SceneManager.LoadScene(currentLevel);
    }

    private void SelectSlot(Transform trans)
    {
        currentSlot = trans;
        trans.DOMoveX(2, .15f).SetRelative(true).SetEase(Ease.OutBack).Play();
    }
    private void DeselectSlot(Transform trans)
    {
        currentSlot = null;
        trans.DOMoveX(-2, .15f).SetRelative(true).SetEase(Ease.OutBack).Play();
    }
}