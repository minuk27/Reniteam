using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [Header("NPC아이디")]
    public int id;
    [Header("대사")]
    public List<string> speechDB;
    [Header("시작대사(현재 말할 수 있는 시작 대사인덱스값)")]
    public int startSpeech;
    [Header("마지막대사(대사변경에서 사용할 인덱스)")]
    public int endSpeech;
    [Header("대사변경(현재 말할 수 있는 마지막 대사인덱스값)")]
    public List<int> speechIndex;
    [Header("스토리인덱스값(퀘스트인덱스를 변경해줄 값)")]
    public int startQuest;
    [Header("대사 중 퀘스트에 해당하는 인덱스")]
    public List<int> questIndex;
    [Header("퀘스트아이디")]
    public List<int> questID;
}

public class DialogDB : MonoBehaviour
{
    public List<Dialog> npcDialogDB;
    public void Setting()
    {
        foreach(Dialog i in npcDialogDB)
        {
            i.startSpeech = 0;
            i.endSpeech = 0;
        }
    }
}