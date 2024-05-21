using System;
using UnityEngine;

public class ScoreGoalQuest : Quest
{
    private Goal _goalRef;
    [SerializeField] private int goalsRequired;
    private int _currentGoals;
    private void Start()
    {
        _goalRef = FindObjectOfType<Goal>();
        if(_goalRef==null) Debug.LogError("Portería no encontrada");
        _goalRef.OnGoalScored += GoalScored;
    }

    private void GoalScored()
    {
        _currentGoals++;
        CheckCompleted();
    }
    public override void CheckCompleted()
    {
        if(isCompleted)return;
        if (_currentGoals >= goalsRequired)
        {
            CompleteQuest();
        }
    }

    private void OnDestroy()
    {
        if(_goalRef)_goalRef.OnGoalScored -= GoalScored;
    }
}
