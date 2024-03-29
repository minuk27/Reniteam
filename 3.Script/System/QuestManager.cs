using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Dictionary<int, Quest> questDictionary = new Dictionary<int, Quest>();
    private QuestDB questDB;

    public void Initialize()
    {
        SetQuest();
    }   

    public void SetQuest()
    {
        questDB = Resources.Load<GameObject>("Quest").GetComponent<QuestDB>();
        for (int i = 0; i < questDB.quest.Count; i++)
        {
            questDictionary.Add(questDB.quest[i].questID, questDB.quest[i]);
        }
    }
}
