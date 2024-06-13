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
    [Header("NPC�� ��ȭ(�ܼ� ��ȭ)")]
    public GameObject npcTalk;
    [Header("NPC�� ����Ʈ(����Ʈ ������)")]
    public GameObject npcQuest;
    [Header("NPC����")]
    public GameObject npcLife;
    [Header("Item Ȯ��(����Ʈó�� ��,�ƴϿ����� ����)")]
    public GameObject itemChoice;
    [Header("���Ǵ޼��� �ٲ�� ��Ż��� �ε���(0���� ������ ������)")]
    public int portalIndex;
}

public class StoryCondition : MonoBehaviour
{
    [Header("��Ż��ΰ� ����Ǵ� ���ǵ�")]
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
