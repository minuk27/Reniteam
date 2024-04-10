using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("인덱스값이 같으면 같은 퀘스트")]
    [Header("퀘스트 제공자 npc아이디")]
    public int npcID;
    [Header("퀘스트아이디(퀘스트중인지 아닌지를 판별해야하기 때문에 필요)")]
    public List<int> questID;
    [Header("퀘스트가 나올 대사(퀘스트자체 대사는 대사데이터베이스에 저장됨)")]
    public List<int> questSpeech;
    [Header("퀘스트 내용(퀘스트창을 만들때 사용하며 안만드면 삭제)")]
    public List<string> contents;
    [Header("퀘스트 수락시")]
    public List<string> acceptSpeech;
    [Header("퀘스트 거절시")]
    public List<string> rejectSppech;
    [Header("퀘스트 보상 종류(0: 없음(정보도 포함), 1: 아이템, 2: 2차퀘스트)")]
    public List<int> form;
    [Header("퀘스트 보상(아이템아이디, 2차퀘스트-퀘스트내용인덱스값)")]
    public List<int> compensation;
    [Header("퀘스트 완료시 대사 +  보상으로 정보가 있을시 여기에 추가")]
    public List<string> qespeech;
    [Header("퀘스트 강제성(반드시 수행인지 아닌지)")]
    public List<bool> certainly;
}

public class QuestDB : MonoBehaviour
{
    public List<Quest> quest;
}
