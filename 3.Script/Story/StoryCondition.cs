using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConditionType
{
    NPCTalk, NPCQuest, NPCLife, ItemChoice
}

[System.Serializable]
public class Condition
{
    [Header("NPC와 대화(단순 대화)")]
    public GameObject npcTalk;
    [Header("NPC의 퀘스트(퀘스트 수락시)")]
    public GameObject npcQuest;
    [Header("NPC생존")]
    public GameObject npcLife;
    [Header("Item 확인(퀘스트처럼 네,아니오에서 조건)")]
    public GameObject itemChoice;
    [Header("조건달성시 바뀌는 포탈경로 인덱스(0번을 제외한 나머지)")]
    public int portalIndex;
}

public class StoryCondition : MonoBehaviour
{
    [Header("포탈경로가 변경되는 조건들")]
    [SerializeField] List<Condition> condition;
    Dictionary<int, List<bool>> isSuccess;
    ScreenPortal portal;
    private void Awake()
    {
        portal = GetComponent<ScreenPortal>();
        isSuccess = new Dictionary<int, List<bool>>();
        foreach(Condition con in condition)
        {
            isSuccess[con.portalIndex] = new List<bool>();
            isSuccess[con.portalIndex].Add(con.npcTalk == null ? true : false);
            isSuccess[con.portalIndex].Add(con.npcQuest == null ? true : false);
            isSuccess[con.portalIndex].Add(con.npcLife == null ? true : false);
            isSuccess[con.portalIndex].Add(con.itemChoice == null ? true : false);
        }
    }

    private void OnEnable()
    {
        portal = GetComponent<ScreenPortal>();
        isSuccess = new Dictionary<int, List<bool>>();
        foreach (Condition con in condition)
        {
            isSuccess[con.portalIndex] = new List<bool>();
            isSuccess[con.portalIndex].Add(con.npcTalk == null ? true : false);
            isSuccess[con.portalIndex].Add(con.npcQuest == null ? true : false);
            isSuccess[con.portalIndex].Add(con.npcLife == null ? true : false);
            isSuccess[con.portalIndex].Add(con.itemChoice == null ? true : false);
        }
    }

    public void conditionType(ConditionType type, GameObject target)
    {
        switch (type)
        {
            case ConditionType.NPCTalk:
                npcTalkCondtion(target);
                break;
            case ConditionType.NPCQuest:
                npcQuestCondition(target);
                break;
            case ConditionType.NPCLife:
                npcIsLife(target);
                break;
            case ConditionType.ItemChoice:
                itemChoiceCondition(target);
                break;
        }
    }
    void npcTalkCondtion(GameObject target)
    {
        foreach (Condition con in condition)
        {
            if (con.npcTalk == target)
            {
                isSuccess[con.portalIndex][0] = true;
            }
            clearCondition(con.portalIndex);
        }
    }

    void npcQuestCondition(GameObject target)
    {
        foreach (Condition con in condition)
        {
            if (con.npcQuest == target)
            {
                isSuccess[con.portalIndex][1] = true;
            }
            clearCondition(con.portalIndex);
        }
    }

    void npcIsLife(GameObject target)
    {
        foreach (Condition con in condition)
        {
            if (con.npcLife == target)
            {
                isSuccess[con.portalIndex][2] = true;
            }
            clearCondition(con.portalIndex);
        }
    }
    void itemChoiceCondition(GameObject target)
    {
        foreach (Condition con in condition)
        {
            if (con.itemChoice == target)
            {
                isSuccess[con.portalIndex][3] = true;
            }
            clearCondition(con.portalIndex);
        }
    }

    void clearCondition(int index)
    {
        bool success = true;
        for(int i = 0; i < 4; i++)
        {
            if (!isSuccess[index][i])
                success = false;
        }
        if (success)
        {
            portal.changeStory(index);
        }
    }
}
