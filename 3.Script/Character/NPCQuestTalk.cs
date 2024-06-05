using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCQuestDialog
{
    [Header("����Ʈ�����")]
    public List<string> speech;
    [Header("����Ʈ���NPC(������ ����)")]
    public List<int> questTargetNPC;
    [Header("����Ʈ��������(������ ����)")]
    public List<int> questTargetItem;
    [Header("����Ʈ���")]
    public List<string> questSpeech;
    [Header("����Ʈ����, ���� ������")]
    public string acceptSpeech;
    [Header("����Ʈ����, ��������")]
    public string acceptSpeechAfter;
    [Header("����Ʈ����, ���� ������")]
    public string inAcceptSpeech;
    [Header("����Ʈ �ڵ�����")]
    public bool autoAccept;
    [Header("���丮 ����")]
    public bool storyEffect;
}

public class NPCQuestTalk : MonoBehaviour
{
    [SerializeField] NPCQuestDialog questDialog;
    [SerializeField] StoryCondition storyCondition;
    int[] speechIndex;
    int[] endSpeechIndex;
    int step; //0: ����Ʈ �����, 1: ����Ʈ ���, 2: ����Ʈ �������, 3: ����Ʈ �źδ��, 4: ����Ʈ ���� �� ���
    int nowStep;
    bool isQuestSpeech;
    private void Awake()
    {
        speechIndex = new int[2] { 0, 0};
        endSpeechIndex = new int[2];
        endSpeechIndex[0] = questDialog.speech.Count - 1;
        endSpeechIndex[1] = questDialog.questSpeech.Count - 1;
        step = 0;
        if (questDialog.speech.Count == 0)
            step = 1;
        nowStep = 0;
        isQuestSpeech = false;
    }
    public string getSpeech { get { return returnSpeech(); } }

    string returnSpeech()
    {
        string speechValue = "";
        switch (step)
        {
            case 0:
                nowStep = 0;
                speechValue = questDialog.speech[speechIndex[0]];
                speechIndex[0] += 1;
                if (speechIndex[0] > endSpeechIndex[0])
                    step = 1;
                break;
            case 1:
                nowStep = 1;
                speechValue = questDialog.questSpeech[speechIndex[1]];
                speechIndex[1] += 1;
                isQuestSpeech = true;
                if (speechIndex[1] > endSpeechIndex[1])
                {
                    speechIndex[1] = endSpeechIndex[1];
                    isQuestSpeech = false;
                }
                break;
            case 2:
                nowStep = 2;
                speechValue = questDialog.acceptSpeech;
                step = 4;
                if (questDialog.storyEffect)
                    storyCondition.conditionType(ConditionType.NPCQuest, this.gameObject);
                break;
            case 3:
                nowStep = 3;
                speechValue = questDialog.inAcceptSpeech;
                if (questDialog.autoAccept)
                {
                    step = 4;
                    if (questDialog.storyEffect)
                        storyCondition.conditionType(ConditionType.NPCQuest, this.gameObject);
                }
                else
                {
                    step = 1;
                }
                break;
            case 4:
                nowStep = 4;
                speechValue = questDialog.acceptSpeechAfter;
                break;
        }
        return speechValue;
    }

    public void acceptQuest() { step = 2; }
    public void failureQuest() { step = 3; }
    public int getNowStep { get { return nowStep; } }
    public bool getIsQuestSpeech { get { return isQuestSpeech; } }
}