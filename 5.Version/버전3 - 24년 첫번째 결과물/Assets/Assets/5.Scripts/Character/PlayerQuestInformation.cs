using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestInformation
{
    public bool nowQuest;
    public string questName;//퀘스트 이름
    public string questContent;//퀘스트 내용
    public string questGoal;//목표
    public string questAmends;//보상
    public string questPenalty;//실패 패널티

    public PlayerQuestInformation()
    {
        nowQuest = false;
        questName = null;
        questContent = null;
        questGoal = null;
        questAmends = null;
        questPenalty = null;
    }
}
