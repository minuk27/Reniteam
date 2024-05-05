using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("퀘스트아이디")]
    public int questID;
    [Header("퀘스트 수락시")]
    public string acceptSpeech;
    [Header("퀘스트 거절시")]
    public string rejectSppech;
    [Header("퀘스트 보상 종류(0: 없음(정보도 포함), 1: 아이템, 2: 2차퀘스트)")]
    public int form;
    [Header("스토리분기(대사변경, 스토리변경등)")]
    public bool change;
    [Header("퀘스트 강제성(반드시 수행인지 아닌지)")]
    public bool certainly;
}

public class QuestDB : MonoBehaviour
{
    public List<Quest> quest;
}
