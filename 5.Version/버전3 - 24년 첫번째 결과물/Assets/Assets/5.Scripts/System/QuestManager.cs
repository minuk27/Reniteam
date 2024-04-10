using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Dictionary<int, Quest> questDictionary = new Dictionary<int, Quest>();
    private QuestDB questDB;
    private bool isQuest;

    public void Initialize()
    {
        SetQuest();
        isQuest = false;
    }   

    public void SetQuest()
    {
        questDB = Resources.Load<GameObject>("Quest").GetComponent<QuestDB>();
        for (int i = 0; i < questDB.quest.Count; i++)
        {
            questDictionary.Add(questDB.quest[i].npcID, questDB.quest[i]);
        }
    }

    public int GetQuest(int npcID)
    {
        return questDictionary[npcID].questSpeech[0];
    }

    public void IsStartQuest(int npcID)
    {
        //return questDictionary[npcID].questStory[0] == GameManager.Manager.GetStoryManager.CurrentStep();
    }

    public void StartQuest()
    {
        isQuest = true;
    }

    public bool IsQuest { get { return isQuest; } }
}
