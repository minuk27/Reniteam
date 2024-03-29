using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("퀘스트 아이디")]
    public int questID;
    [Header("퀘스트 제공자 npc아이디")]
    public int npcID;
    [Header("퀘스트 내용")]
    public string contents;
    [Header("퀘스트 보상 종류(1: 정보, 2: 아이템)")]
    public int form;
    [Header("퀘스트 보상(정보: 대화아이디, 아이템: 아이템아이디)")]
    public int compensation;
    [Header("퀘스트 성공 여부")]
    public bool succes;
    [Header("퀘스트 보상2여부")]
    public bool form2;//퀘스트 보상2여부 -> 2차퀘스트(선행퀘스트로 열리는 퀘스트) -> 보상2가 더 많을 시(예: 정보와 아이템 동시에 줄경우) int형으로 교체
    [Header("2차퀘스트 아이디(없으면 0)")]
    public int compensation2;
}

public class QuestDB : MonoBehaviour
{
    public List<Quest> quest;
}
