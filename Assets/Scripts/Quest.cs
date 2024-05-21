using System;
using UnityEngine;

[Serializable]
public abstract class Quest : MonoBehaviour
{
    protected bool isCompleted;
    
    public Action OnQuestCompleted;
    public abstract void CheckCompleted();
    
    protected void CompleteQuest()
    {
        isCompleted = true;
        OnQuestCompleted?.Invoke();
    }
}