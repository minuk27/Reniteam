using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestInformation
{
    public bool nowQuest;
    public string questName;//����Ʈ �̸�
    public string questContent;//����Ʈ ����
    public string questGoal;//��ǥ
    public string questAmends;//����
    public string questPenalty;//���� �г�Ƽ

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
