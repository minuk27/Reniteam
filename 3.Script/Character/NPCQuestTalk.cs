using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCQuestDialog
{
    [Header("퀘스트전대사")]
    public List<string> speech;
    [Header("퀘스트대상NPC(없으면 비우기)")]
    public List<int> questTargetNPC;
    [Header("퀘스트대상아이템(없으면 비우기)")]
    public List<int> questTargetItem;
    [Header("퀘스트대사")]
    public List<string> questSpeech;
    [Header("퀘스트수락, 수락 했을때")]
    public string acceptSpeech;
    [Header("퀘스트수락, 수락이후")]
    public string acceptSpeechAfter;
    [Header("퀘스트거절, 거절 했을때")]
    public string inAcceptSpeech;
    [Header("퀘스트 자동수락")]
    public bool autoAccept;
    [Header("스토리 영향")]
    public bool storyEffect;
}

public class NPCQuestTalk : MonoBehaviour
{
    [SerializeField] NPCQuestDialog questDialog;
    [SerializeField] StoryCondition storyCondition;
    int[] speechIndex;
    int[] endSpeechIndex;
    int step; //0: 퀘스트 전대사, 1: 퀘스트 대사, 2: 퀘스트 수락대사, 3: 퀘스트 거부대사, 4: 퀘스트 수락 후 대사
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