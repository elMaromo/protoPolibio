using System;
using UnityEngine;

public class QuestsController : MonoBehaviour
{
    public int questsAmount = 3;
    public Quest quest1;
    public Quest quest2;
    public Quest quest3;

    public QuestsView questsView;

    private int _numberOfQuestsCompleted;
    private bool AreAllQuestsCompleted => NumberOfQuestsCompleted == questsAmount;
    public int NumberOfQuestsCompleted => Mathf.Clamp(_numberOfQuestsCompleted, 0, questsAmount);

    public event Action OnAllQuestsCompleted;

    private void Awake()
    {
        _numberOfQuestsCompleted = 0;

        quest1.OnQuestCompleted += Quest1Completed;
        quest2.OnQuestCompleted += Quest2Completed;
        quest3.OnQuestCompleted += Quest3Completed;

        questsView.Init(quest1, quest2, quest3);
    }

    private void CheckAllQuestsCompleted()
    {
        if (!AreAllQuestsCompleted) return;

        OnAllQuestsCompleted?.Invoke();
        print("All quests are completed");
    }

    private void Quest1Completed()
    {
        print("Quest 1 completed");
        questsView.MarkQuestAsCompleted(1);
        _numberOfQuestsCompleted++;
        CheckAllQuestsCompleted();
    }

    private void Quest2Completed()
    {
        print("Quest 2 completed");
        questsView.MarkQuestAsCompleted(2);
        _numberOfQuestsCompleted++;
        CheckAllQuestsCompleted();
    }

    private void Quest3Completed()
    {
        print("Quest 3 completed");
        questsView.MarkQuestAsCompleted(3);
        _numberOfQuestsCompleted++;
        CheckAllQuestsCompleted();
    }

    private void OnDestroy()
    {
        if (quest1) quest1.OnQuestCompleted -= Quest1Completed;
        if (quest2) quest2.OnQuestCompleted -= Quest2Completed;
        if (quest3) quest3.OnQuestCompleted -= Quest3Completed;
    }
}