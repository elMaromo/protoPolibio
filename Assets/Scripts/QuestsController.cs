using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsController : MonoBehaviour
{
    public Quest _quest1;
    public Quest _quest2;
    public Quest _quest3;

    private void Start()
    {
        _quest1.OnQuestCompleted += Quest1Completed;
        _quest2.OnQuestCompleted += Quest2Completed;
        _quest3.OnQuestCompleted += Quest3Completed;
    }


    private void Quest1Completed()
    {
        print("Quest 1 completed");
    }

    private void Quest2Completed()
    {
        print("Quest 2 completed");
    }

    private void Quest3Completed()
    {
        print("Quest 3 completed");
    }

    private void OnDestroy()
    {
        if(_quest1)_quest1.OnQuestCompleted -= Quest1Completed;
        if(_quest2)_quest2.OnQuestCompleted -= Quest2Completed;
        if(_quest3)_quest3.OnQuestCompleted -= Quest3Completed;
    }
}